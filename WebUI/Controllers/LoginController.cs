using Application.Features.Users.Query.Login;
using Microsoft.AspNetCore.Mvc;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class LoginController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            var response = RequestHelper.SendRequest<UsersLoginDto>("/User/Login", new UsersLoginQuery(username, password));

            if (response == null)
            {
                ViewBag.LastUsername = username;
                ViewBag.Error = "Kullanıcı adınız veya şifreniz yanlış!";
                return View();
            }

            CookieOptions options = new CookieOptions();
            options.Expires = response.Expire;
            Response.Cookies.Append("auth_token", response.Token, options);

            return RedirectToAction("Index", "Home");
        }
    }
}
