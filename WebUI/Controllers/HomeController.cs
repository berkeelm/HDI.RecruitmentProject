using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Interfaces;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IRequestHelper requestHelper) : base(requestHelper)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}