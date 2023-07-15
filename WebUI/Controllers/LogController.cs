using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using WebUI.Filters;
using WebUI.Interfaces;

namespace WebUI.Controllers
{
    [AuthorizationFilter(new UserType[] { UserType.FirmUser })]
    public class LogController : BaseController
    {
        public LogController(IRequestHelper requestHelper, IWebHostEnvironment env) : base(requestHelper, env)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
