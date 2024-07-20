using Core_Proje.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AdminUser> _signInManager;

        public LoginController(SignInManager<AdminUser> signInManager)
        {
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
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
			if (_signInManager.IsSignedIn(User))
			{
				return RedirectToAction("Home", "Default");
			}
			if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, true, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Home", "Default");
                }
                else
                {
                    ModelState.AddModelError("","Wrong Username or Password");
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "admin");
        }
    }
}
