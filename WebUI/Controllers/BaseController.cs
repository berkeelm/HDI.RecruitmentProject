using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using WebUI.Interfaces;

namespace WebUI.Controllers
{
    public class BaseController : Controller
    {
        public IRequestHelper _requestHelper;
        public IWebHostEnvironment _env;

        public BaseController(IRequestHelper requestHelper, IWebHostEnvironment env)
        {
            _requestHelper = requestHelper;
            _env = env;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var username = Request.Cookies["user_info"];
            ViewBag.Username = username == null ? "" : username;

            var usertype = Request.Cookies["user_type"];
            ViewBag.UserType = usertype == null ? null : (UserType?)Convert.ToInt32(usertype);

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
