using Core_Proje.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Concrete;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Linq;
using Core_Proje.Areas.Helpers;

namespace Core_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SalController : Controller
    {
        private readonly UserManager<AdminUser> _userManager;
        private readonly Context _dbContext;

        public SalController(UserManager<AdminUser> userManager, Context dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserSalViewModel model = new UserSalViewModel();
            model.ImageUrl = values.ImageUrl;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSalViewModel p)
        {
            if (p.Image != null)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                stream.Dispose();
                //+++++++++++++++++++++++++++++++++++++++++++++++
                PoseDetector poseDetector = new PoseDetector();
                bool isPoseDetected = poseDetector.DetectBody(savelocation);
                //+++++++++++++++++++++++++++++++++++++++++++++++

                if (!isPoseDetected)
                {
                    //-----------------------------------------------
                    using (var image = Image.Load(savelocation))
                    {
                        int cropWidth = Math.Min(image.Width, image.Height);
                        int cropHeight = cropWidth;
                        int cropX = (image.Width - cropWidth) / 2;
                        int cropY = (image.Height - cropHeight) / 2;
                        image.Mutate(x => x.Crop(new Rectangle(cropX, cropY, cropWidth, cropHeight)));
                        image.Mutate(x => x.Resize(new ResizeOptions
                        {
                            Size = new Size(500, 500),
                            Mode = ResizeMode.Max,
                        }));

                        image.Save(savelocation);
                    }
                    //-----------------------------------------------
                    var sal = new Sal
                    {
                        Image = imagename,
                        UserId = user.Id,
                        Category = p.Category,
                        City = p.City,
                    };

                    _dbContext.Homes.Add(sal);

                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("home", "default");
                }
                else
                {
                    //ModelState.AddModelError("", "body detected");

                    ViewBag.Script = "<script>alert('Body detected in the image. Please select a different image.');</script>";
                }
                //return RedirectToAction("home","default");
            }

            return View();
        }
    }
}