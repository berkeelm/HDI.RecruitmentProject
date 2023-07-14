using Application.Features.Problem.Command.Add;
using Application.Features.Problem.Command.Delete;
using Application.Features.Problem.Command.Update;
using Application.Features.Problem.Query.GetAll;
using Application.Features.Problem.Query.GetById;
using Application.Features.WarrantyType.Query.GetAll;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using WebUI.Interfaces;

namespace WebUI.Controllers
{
    public class ProblemController : BaseController
    {
        public ProblemController(IRequestHelper requestHelper, IWebHostEnvironment env) : base(requestHelper, env)
        {
        }

        public IActionResult Index()
        {
            var response = _requestHelper.SendRequest<List<ProblemGetAllDto>>("/Problem/GetAll", new ProblemGetAllQuery());

            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var warrantyTypeList = _requestHelper.SendRequest<List<WarrantyTypeGetAllDto>>("/WarrantyType/GetAll", new WarrantyTypeGetAllQuery());

            return View(warrantyTypeList);
        }

        [HttpPost]
        public IActionResult Add(ProblemAddCommand model)
        {
            var response = _requestHelper.SendRequest<Response<Guid>>("/Problem/Add", model);

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
            var response = _requestHelper.SendRequest<ProblemGetByIdDto>("/Problem/GetById", new ProblemGetByIdQuery(id));

            var warrantyTypeList = _requestHelper.SendRequest<List<WarrantyTypeGetAllDto>>("/WarrantyType/GetAll", new WarrantyTypeGetAllQuery());
            ViewBag.WarrantyTypeList = warrantyTypeList;

            return View(response);
        }

        [HttpPost]
        public IActionResult Edit(ProblemGetByIdDto model)
        {
            var response = _requestHelper.SendRequest<Response<bool>>("/Problem/Update", new ProblemUpdateCommand()
            {
                Name = model.Name,
                ProblemId = model.Id,
                WarrantyTypeId = model.WarrantyTypeId
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
            var response = _requestHelper.SendRequest<Response<bool>>("/Problem/Delete", new ProblemDeleteCommand()
            {
                ProblemId = id
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
