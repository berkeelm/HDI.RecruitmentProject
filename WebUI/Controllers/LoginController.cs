using Application.Features.Users.Query.Login;
using Microsoft.AspNetCore.Mvc;
using WebUI.Helpers;
using WebUI.Interfaces;

namespace WebUI.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(IRequestHelper requestHelper) : base(requestHelper)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UsersLoginQuery());
        }

        [HttpPost]
        public IActionResult Index(UsersLoginQuery model)
        {
            var response = _requestHelper.SendRequest<UsersLoginDto>("/User/Login", model);

            if (response == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı adınız veya şifreniz yanlış!";
                return View(model);
            }

            CookieOptions options = new CookieOptions();
            options.Expires = response.Expire;
            Response.Cookies.Append("auth_token", response.Token, options);

            return RedirectToAction("Index", "Home");
        }
    }
}
