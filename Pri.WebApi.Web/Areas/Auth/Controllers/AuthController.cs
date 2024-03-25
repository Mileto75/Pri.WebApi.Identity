using Microsoft.AspNetCore.Mvc;

namespace Pri.WebApi.Web.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
