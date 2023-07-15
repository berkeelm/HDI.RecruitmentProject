using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Domain.Enums;
using Application.Features.User.Query.GetById;
using Domain.Common;
using WebUI.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace WebUI.Filters
{
    public class AuthorizationFilter : ActionFilterAttribute
    {
        private UserType[] userTypes;

        public AuthorizationFilter(UserType[] _userTypes)
        {
            this.userTypes = _userTypes;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var svc = filterContext.HttpContext.RequestServices;
                var _requestHelper = svc.GetService<IRequestHelper>();

                var user = _requestHelper.SendRequest<UserGetByIdDto>("/User/GetById", new UserGetByIdQuery());

                if (!userTypes.Contains(user.UserType))
                {
                    filterContext.Result = new RedirectResult("/NotFound404");
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("/Home/NotFoundPage");
            }

        }
    }
}
