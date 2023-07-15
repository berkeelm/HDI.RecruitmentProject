using Application.Features.Problem.Query.GetAll;
using Application.Features.Sale.Query.GetById;
using Application.Features.SaleProblem.Command.Add;
using Application.Features.SaleProblem.Command.Delete;
using Application.Features.SaleProblem.Query.GetAll;
using Application.Features.WarrantyType.Query.GetAll;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using WebUI.Interfaces;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    public class SaleProblemController : BaseController
    {
        public SaleProblemController(IRequestHelper requestHelper, IWebHostEnvironment env) : base(requestHelper, env)
        {
        }

        public IActionResult Index()
        {
            var response = _requestHelper.SendRequest<List<SaleProblemGetAllDto>>("/SaleProblem/GetAll", new SaleProblemGetAllQuery());

            return View(response);
        }

        [HttpGet]
        public IActionResult Add(Guid id)
        {
            var Sale = _requestHelper.SendRequest<SaleGetByIdDto>("/Sale/GetById", new SaleGetByIdQuery(id));
            var ProblemList = _requestHelper.SendRequest<List<ProblemGetAllDto>>("/Problem/GetAll", new ProblemGetAllQuery(id));

            var model = new AddSaleProblemViewModel()
            {
                Sale = Sale,
                Problems = ProblemList
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(SaleProblemAddCommand model)
        {
            var response = _requestHelper.SendRequest<Response<Guid?>>("/SaleProblem/Add", model);

            if (response.Data == null)
            {
                TempData["ErrorMessage"] = response.Message;
                return RedirectToAction("History", "Sale", new { id = model.SaleId });
            }

            TempData["SuccessMessage"] = response.Message;
            return RedirectToAction("History", "Sale", new { id = model.SaleId });
        }

        [HttpGet]
        public IActionResult Delete(Guid id, Guid saleId)
        {
            var response = _requestHelper.SendRequest<Response<bool>>("/SaleProblem/Delete", new SaleProblemDeleteCommand()
            {
                SaleProblemId = id
            });

            if (response.Data == false)
            {
                TempData["ErrorMessage"] = response.Message;
                return RedirectToAction("History", "Sale", new { id = saleId });
            }

            TempData["SuccessMessage"] = response.Message;
            return RedirectToAction("History", "Sale", new { id = saleId });
        }
    }
}
