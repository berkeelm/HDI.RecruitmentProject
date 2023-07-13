using Application.Features.Users.Query.GetAll;
using Application.Features.Users.Query.Login;
using Application.Features.Users.Command.Add;
using Microsoft.AspNetCore.Mvc;
using WebUI.Helpers;
using WebUI.Interfaces;
using Domain.Common;
using MediatR;
using Application.Features.Users.Query.GetById;
using Application.Features.Users.Command.Update;
using Application.Features.Users.Command.Delete;

namespace WebUI.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IRequestHelper requestHelper) : base(requestHelper)
        {
        }

        public IActionResult Index()
        {
            var response = _requestHelper.SendRequest<List<UsersGetAllDto>>("/User/GetAll", new UsersGetAllQuery());

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
            var response = _requestHelper.SendRequest<Response<int>>("/User/Add", model);

            if (response.Data == 0)
            {
                TempData["ErrorMessage"] = response.Message;
                return View(model);
            }

            TempData["SuccessMessage"] = response.Message;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var response = _requestHelper.SendRequest<UsersGetByIdDto>("/User/GetById", new UsersGetByIdQuery(id));

            return View(response);
        }

        [HttpPost]
        public IActionResult Edit(UsersGetByIdDto model)
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
        public IActionResult Delete(int id)
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
