using BusinessLogicLayer.Users;
using DataAccessLayer.Users;
using Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApp.Controllers
{
    public class UserController : Controller
    {
        #region Private Members
        //private readonly ICommon _common;
        private readonly IConfiguration _configuration;
        private readonly string _connString;
        private IUser _user
        {
            get
            {
                return new UserDAL(_connString);
            }
        }
        #endregion Private Members

        #region Constructors
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = _configuration.GetConnectionString("InventoryDevDB");
        }
        #endregion Constructors

        #region Common Web APIs     
        
        // Action methods
        [HttpGet]
        public IActionResult Users()
        {
            // Business Logic
           return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            try
            {
                int statusCode = _user.Add(user);
                return new JsonResult(statusCode);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        #endregion Common Web APIs
    }
}
