using Core_Proje.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AdminUser> _userManager;
        private readonly SignInManager<AdminUser> _signInManager;

		public RegisterController(UserManager<AdminUser> userManager, SignInManager<AdminUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
        public IActionResult Index()
        {
			if (_signInManager.IsSignedIn(User))
			{
				return RedirectToAction("Home", "Default");
			}
			return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
			if (_signInManager.IsSignedIn(User))
			{
				return RedirectToAction("Home", "Default");
			}

			if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AdminUser w = new AdminUser()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    UserName = p.UserName,
                    Email = p.Email
                };
            if(p.Password == p.ConfirmPassword) {
                var result= await _userManager.CreateAsync(w,p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Admin");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View();
        }
    }
}
