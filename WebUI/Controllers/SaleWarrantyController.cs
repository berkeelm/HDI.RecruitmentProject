﻿using Application.Features.Sale.Query.GetById;
using Application.Features.SaleWarranty.Command.Add;
using Application.Features.SaleWarranty.Command.Delete;
using Application.Features.SaleWarranty.Command.Update;
using Application.Features.SaleWarranty.Query.GetAll;
using Application.Features.SaleWarranty.Query.GetById;
using Application.Features.WarrantyType.Query.GetAll;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using WebUI.Interfaces;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    public class SaleWarrantyController : BaseController
    {
        public SaleWarrantyController(IRequestHelper requestHelper, IWebHostEnvironment env) : base(requestHelper, env)
        {
        }

        public IActionResult Index()
        {
            var response = _requestHelper.SendRequest<List<SaleWarrantyGetAllDto>>("/SaleWarranty/GetAll", new SaleWarrantyGetAllQuery());

            return View(response);
        }

        [HttpGet]
        public IActionResult Add(Guid id)
        {
            var Sale = _requestHelper.SendRequest<SaleGetByIdDto>("/Sale/GetById", new SaleGetByIdQuery(id));
            var warrantyTypeList = _requestHelper.SendRequest<List<WarrantyTypeGetAllDto>>("/WarrantyType/GetAll", new WarrantyTypeGetAllQuery());

            var model = new AddSaleWarrantyViewModel()
            {
                Sale = Sale,
                WarrantyTypes = warrantyTypeList
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(SaleWarrantyAddCommand model)
        {
            var response = _requestHelper.SendRequest<Response<Guid?>>("/SaleWarranty/Add", model);

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
            var response = _requestHelper.SendRequest<Response<bool>>("/SaleWarranty/Delete", new SaleWarrantyDeleteCommand()
            {
                SaleWarrantyId = id
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
