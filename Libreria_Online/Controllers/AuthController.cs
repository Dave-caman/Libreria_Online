using Microsoft.AspNetCore.Mvc;

namespace Libreria_Online.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
            {
                return View();
            }
        [HttpPost]
        public IActionResult Login(string Usuario, string password)
            {
            if (string.IsNullOrEmpty(Usuario)) 
            { }
            return View();
            }
        public IActionResult Register() {
            return View();
        }
    }

}
