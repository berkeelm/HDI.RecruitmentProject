using Application.Features.WarrantyType.Command.Add;
using Application.Features.WarrantyType.Command.Delete;
using Application.Features.WarrantyType.Command.Update;
using Application.Features.WarrantyType.Query.GetAll;
using Application.Features.WarrantyType.Query.GetById;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using WebUI.Interfaces;

namespace WebUI.Controllers
{
    public class WarrantyTypeController : BaseController
    {
        public WarrantyTypeController(IRequestHelper requestHelper, IWebHostEnvironment env) : base(requestHelper, env)
        {
        }

        public IActionResult Index()
        {
            var response = _requestHelper.SendRequest<List<WarrantyTypeGetAllDto>>("/WarrantyType/GetAll", new WarrantyTypeGetAllQuery());

            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new WarrantyTypeAddCommand());
        }

        [HttpPost]
        public IActionResult Add(WarrantyTypeAddCommand model)
        {
            var response = _requestHelper.SendRequest<Response<Guid>>("/WarrantyType/Add", model);

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
            var response = _requestHelper.SendRequest<WarrantyTypeGetByIdDto>("/WarrantyType/GetById", new WarrantyTypeGetByIdQuery(id));

            return View(response);
        }

        [HttpPost]
        public IActionResult Edit(WarrantyTypeGetByIdDto model)
        {
            var response = _requestHelper.SendRequest<Response<bool>>("/WarrantyType/Update", new WarrantyTypeUpdateCommand()
            {
                Name = model.Name,
                WarrantyTypeId = model.Id
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
            var response = _requestHelper.SendRequest<Response<bool>>("/WarrantyType/Delete", new WarrantyTypeDeleteCommand()
            {
                WarrantyTypeId = id
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
