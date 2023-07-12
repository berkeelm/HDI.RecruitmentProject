using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebUI.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string token = Request.Cookies["auth_token"];

            if (token == null && !filterContext.HttpContext.Request.Path.Value.ToLower().Contains("login"))
            {
                filterContext.Result = new RedirectResult("/Login/Index");
                return;
            }

            if (token != null && filterContext.HttpContext.Request.Path.Value.ToLower().Contains("login"))
            {
                filterContext.Result = new RedirectResult("/Home/Index");
                return;
            }
        }
    }
}
