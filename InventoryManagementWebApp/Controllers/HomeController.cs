using InventoryManagementWebApp.Models;
using InventoryWebApp.Commons;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InventoryManagementWebApp.Controllers
{
    [SessionTimeOut]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            
            int a = 10;
            Console.WriteLine(a);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}