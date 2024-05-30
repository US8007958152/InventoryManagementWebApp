using Entities.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InventoryWebApp.Commons
{
    public class SessionTimeOutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            UserProfile userProfile = SessionHelper.GetSession(context.HttpContext.Session);
            if(userProfile == null)
            {
                context.Result = new RedirectResult("/Authenticate/Login");
                return;
            }
        }
    }
}
