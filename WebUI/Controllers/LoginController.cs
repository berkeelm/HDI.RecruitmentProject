using Application.Features.User.Query.GetById;
using Application.Features.User.Query.Login;
using Microsoft.AspNetCore.Mvc;
using WebUI.Helpers;
using WebUI.Interfaces;

namespace WebUI.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(IRequestHelper requestHelper, IWebHostEnvironment env) : base(requestHelper, env)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserLoginQuery());
        }

        [HttpPost]
        public IActionResult Index(UserLoginQuery model)
        {
            var response = _requestHelper.SendRequest<UserLoginDto>("/User/Login", model);

            if (response == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı adınız veya şifreniz yanlış!";
                return View(model);
            }

            CookieOptions options = new CookieOptions();
            options.Expires = response.Expire;
            Response.Cookies.Append("auth_token", response.Token, options);
            Response.Cookies.Append("user_info", response.NameSurname, options);
            Response.Cookies.Append("user_type", Convert.ToInt32(response.UserType).ToString(), options);

            return RedirectToAction("Index", "Home");
        }
    }
}
