using InventoryWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApp.Controllers
{
    public class AuthenticateController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginUser loginUser)
        {
            return View();
        }
    }
}
