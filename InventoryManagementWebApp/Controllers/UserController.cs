using BusinessLogicLayer.Users;
using DataAccessLayer.Users;
using Entities.Users;
using InventoryWebApp.Commons;
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
        [SessionTimeOut]
        // Action methods
        [HttpGet]
        public IActionResult Users()
        {
            List<UserViewModel> users = _user.GetUsers();
            return View(users);
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
                string statusMessage = string.Empty;
                int statusCode = _user.Add(user);

                switch(statusCode)
                {
                    case -301:
                        statusMessage = "Email Id already exists";
                        break;
                    case -302:
                        statusMessage = "Mobile number already exists";
                        break;
                    default:
                        statusMessage = "User has been registred successfully!";
                        break;
                }
                return new JsonResult(new { StatusCode = statusCode,StatusMessage = statusMessage});
            }
            catch(Exception ex)
            {
                return BadRequest(new { StatusCode = -500, StatusMessage = ex.Message } );
            }            
        }

        #endregion Common Web APIs
    }
}
