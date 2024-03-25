using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pri.WebApi.Core.Entities;
using Pri.WebApi.Web.Areas.Auth.ViewModels;

namespace Pri.WebApi.Web.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class AuthController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AuthLoginViewModel authLoginViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(authLoginViewModel);
            }
            //authenticate user
            var result = await _signInManager.PasswordSignInAsync(authLoginViewModel.Username,
                authLoginViewModel.Password,false,false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home",new {Area=""});
            }
            //not authenticated
            ModelState.AddModelError("", "Wrong credentials!");
            return View(authLoginViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
