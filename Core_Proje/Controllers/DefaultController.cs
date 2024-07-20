using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace Core_Proje.Controllers
{
    public class DefaultController : Controller
    {
        private HomeManager postManager = new HomeManager(new EfHomeDal());

        [AllowAnonymous]
        public IActionResult Index() => View();

        public IActionResult Home()
        {
            var values = postManager.TGetPostWithUser(null, null);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> Home(string category, string city)
        {
            var values = postManager.TGetPostWithUser(category, city);
            return View(values);
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
    }
}