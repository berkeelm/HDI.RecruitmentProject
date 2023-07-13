using Application.Features.Customer.Command.Add;
using Application.Features.Customer.Command.Delete;
using Application.Features.Customer.Command.Update;
using Application.Features.Customer.Query.GetAll;
using Application.Features.Customer.Query.GetById;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using WebUI.Interfaces;

namespace WebUI.Controllers
{
    public class CustomerController : BaseController
    {
        public CustomerController(IRequestHelper requestHelper, IWebHostEnvironment env) : base(requestHelper, env)
        {
        }

        public IActionResult Index()
        {
            var response = _requestHelper.SendRequest<List<CustomerGetAllDto>>("/Customer/GetAll", new CustomerGetAllQuery());

            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new CustomerAddCommand());
        }

        [HttpPost]
        public IActionResult Add(CustomerAddCommand model)
        {
            var response = _requestHelper.SendRequest<Response<int>>("/Customer/Add", model);

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
            var response = _requestHelper.SendRequest<CustomerGetByIdDto>("/Customer/GetById", new CustomerGetByIdQuery(id));

            return View(response);
        }

        [HttpPost]
        public IActionResult Edit(CustomerGetByIdDto model)
        {
            var response = _requestHelper.SendRequest<Response<bool>>("/Customer/Update", new CustomerUpdateCommand()
            {
                CustomerId = model.Id,
                Address = model.Address,
                Mail = model.Mail,
                NameSurname = model.NameSurname,
                Phone = model.Phone
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
            var response = _requestHelper.SendRequest<Response<bool>>("/Customer/Delete", new CustomerDeleteCommand()
            {
                CustomerId = id
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
