using BusinessLogicLayer.Users;
using DataAccessLayer.Users;
using Entities.Users;
using InventoryWebApp.Commons;
using InventoryWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApp.Controllers
{
    public class AuthenticateController : Controller
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
        private IAuthenticate _authenticate
        {
            get
            {
                return new AuthenticateDAL(_connString);
            }
        }
        #endregion Private Members

        #region Constructors
        public AuthenticateController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = _configuration.GetConnectionString("InventoryDevDB");
        }
        #endregion Constructors
        [HttpGet]
        public IActionResult Login(string returnurl)
        {
           TempData["ReturnUrl"] = returnurl;
            LoginUser loginUser = new LoginUser();
            loginUser.UserName = HttpContext.Session.GetString("UserName");
            loginUser.Password = HttpContext.Session.GetString("Password");
            loginUser.IsRemember = Convert.ToBoolean(HttpContext.Session.GetString("IsRemember"));
            return View(loginUser);
        }
        [HttpPost]
        public IActionResult Login(LoginUser loginUser)
        {
            if(ModelState.IsValid)
            {
                string statusMessage = string.Empty;
                int statusCode = _authenticate.Validate(loginUser.UserName, loginUser.Password);

                if (statusCode > 0)
                {
                     UserProfile userProfile = _user.GetUserProfile(statusCode);
                    if (loginUser.IsRemember)
                    {
                        HttpContext.Session.SetString("UserName", loginUser.UserName);
                        HttpContext.Session.SetString("Password", loginUser.Password);
                        HttpContext.Session.SetString("IsRemember", loginUser.IsRemember.ToString());
                        
                    }
                    else
                    {
                        HttpContext.Session.Remove("UserName");
                        HttpContext.Session.Remove("Password");
                        HttpContext.Session.Remove("IsRemember");
                    }

                    SessionHelper.SetSession(HttpContext.Session, userProfile);
                    if(TempData["ReturnUrl"] != null)
                        return Redirect(TempData["ReturnUrl"] as string);

                    return RedirectToAction("Index", "Home");
                }
                else if (statusCode == -401)
                    statusMessage = "UserName does not exists!";
                else if (statusCode == -402)
                    statusMessage = "Invalid credentials!";

                TempData["ErrorMessage"] = statusMessage;
            }

            return View();
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            SessionHelper.RemoveSession(HttpContext.Session);
            return RedirectToAction("Login");
        }
    }
}
