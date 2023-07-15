using Application.Features.User.Query.GetAll;
using Application.Features.User.Query.Login;
using Application.Features.User.Command.Add;
using Microsoft.AspNetCore.Mvc;
using WebUI.Helpers;
using WebUI.Interfaces;
using Domain.Common;
using MediatR;
using Application.Features.User.Query.GetById;
using Application.Features.User.Command.Update;
using Application.Features.User.Command.Delete;
using WebUI.Filters;
using Domain.Enums;

namespace WebUI.Controllers
{
    [AuthorizationFilter(new UserType[] { UserType.FirmUser })]
    public class UserController : BaseController
    {
        public UserController(IRequestHelper requestHelper, IWebHostEnvironment env) : base(requestHelper, env)
        {
        }

        public IActionResult Index()
        {
            var response = _requestHelper.SendRequest<List<UserGetAllDto>>("/User/GetAll", new UserGetAllQuery());

            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new UserAddCommand());
        }

        [HttpPost]
        public IActionResult Add(UserAddCommand model)
        {
            var response = _requestHelper.SendRequest<Response<Guid?>>("/User/Add", model);

            if (response.Data == null)
            {
                TempData["ErrorMessage"] = response.Message;
                return View(model);
            }

            TempData["SuccessMessage"] = response.Message;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var response = _requestHelper.SendRequest<UserGetByIdDto>("/User/GetById", new UserGetByIdQuery(id));

            return View(response);
        }

        [HttpPost]
        public IActionResult Edit(UserGetByIdDto model)
        {
            var response = _requestHelper.SendRequest<Response<bool>>("/User/Update", new UserUpdateCommand()
            {
                Email = model.Email,
                NameSurname = model.NameSurname,
                Username = model.Username,
                UserType = model.UserType,
                UserId = model.Id
            });

            if (response.Data == false)
            {
                TempData["ErrorMessage"] = response.Message;
                return View(model);
            }

            TempData["SuccessMessage"] = response.Message;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var response = _requestHelper.SendRequest<Response<bool>>("/User/Delete", new UserDeleteCommand()
            {
                UserId = id
            });

            if (response.Data == false)
            {
                TempData["ErrorMessage"] = response.Message;
                return RedirectToAction("Index");
            }

            TempData["SuccessMessage"] = response.Message;
            return RedirectToAction("Index");
        }
    }
}
