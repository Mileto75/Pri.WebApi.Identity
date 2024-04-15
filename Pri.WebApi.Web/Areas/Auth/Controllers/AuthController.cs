using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
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
        public IActionResult Login(string returnUrl)
        {
            AuthLoginViewModel authLoginViewModel = new AuthLoginViewModel();
            authLoginViewModel.ReturnUrl = "/Products";
            //check if returnurl
            if (!string.IsNullOrEmpty(returnUrl))
            {
                authLoginViewModel.ReturnUrl = returnUrl;
            }
            return View(authLoginViewModel);
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
                return Redirect(authLoginViewModel.ReturnUrl);
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
        [HttpGet]
        public IActionResult Register() 
        {
            AuthRegisterViewModel authRegisterViewModel = new AuthRegisterViewModel();
            authRegisterViewModel.DateOfBirth = DateTime.Now;
            return View(authRegisterViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Register(AuthRegisterViewModel authRegisterViewModel)
        {
            //validate form data
            if(!ModelState.IsValid)
            {
                return View(authRegisterViewModel);
            }
            //create the new user
            var newUser = new ApplicationUser
            {
                Firstname = authRegisterViewModel.Firstname,
                Lastname = authRegisterViewModel.Lastname,
                Email = authRegisterViewModel.Username,
                UserName = authRegisterViewModel.Username,
                DateOfBirth = authRegisterViewModel.DateOfBirth,
            };
            //use the usermanager to create the user
            var result = await _userManager.CreateAsync(newUser, authRegisterViewModel.Password);
            if(!result.Succeeded)
            { 
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(authRegisterViewModel);
            }
            //user created
            //generate the email confirmation token
            ViewBag.EmailConfirmationToken
                = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            ViewBag.UserId = newUser.Id;
            //Show emailconfirmation
            return View("Confirmation");
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string id, string emailConfirmationToken)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                return RedirectToAction("login");
            }
            var result = await _userManager.ConfirmEmailAsync(user, emailConfirmationToken);
            if(result.Succeeded)
            {
                return View("Success");
            }
            return RedirectToAction("login");
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
