using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
