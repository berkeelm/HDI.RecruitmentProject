using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using WebUI.Interfaces;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IRequestHelper requestHelper, IWebHostEnvironment env) : base(requestHelper, env)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("auth_token");
            Response.Cookies.Delete("user_info");
            Response.Cookies.Delete("user_type");
            return RedirectToAction("Index");
        }
    }
}