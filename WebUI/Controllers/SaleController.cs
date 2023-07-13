using Application.Features.Customer.Query.GetAll;
using Application.Features.Product.Query.GetAll;
using Application.Features.Product.Query.GetById;
using Application.Features.Sale.Command.Add;
using Application.Features.Sale.Command.Delete;
using Application.Features.Sale.Command.Update;
using Application.Features.Sale.Query.GetAll;
using Application.Features.Sale.Query.GetById;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using WebUI.Interfaces;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    public class SaleController : BaseController
    {
        public SaleController(IRequestHelper requestHelper, IWebHostEnvironment env) : base(requestHelper, env)
        {
        }

        public IActionResult Index()
        {
            var response = _requestHelper.SendRequest<List<SaleGetAllDto>>("/Sale/GetAll", new SaleGetAllQuery());

            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var productList = _requestHelper.SendRequest<List<ProductGetAllDto>>("/Product/GetAll", new ProductGetAllQuery());
            var customerList = _requestHelper.SendRequest<List<CustomerGetAllDto>>("/Customer/GetAll", new CustomerGetAllQuery());

            var viewModel = new AddSaleViewModel()
            {
                CustomerList = customerList,
                ProductList = productList,
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(SaleAddCommand model)
        {
            var response = _requestHelper.SendRequest<Response<int>>("/Sale/Add", model);

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
            var response = _requestHelper.SendRequest<SaleGetByIdDto>("/Sale/GetById", new SaleGetByIdQuery(id));

            return View(response);
        }

        [HttpPost]
        public IActionResult Edit(SaleGetByIdDto model)
        {
            var response = _requestHelper.SendRequest<Response<bool>>("/Sale/Update", new SaleUpdateCommand()
            {
                SaleId = model.Id,
                ProductId = model.ProductId,
                Price = model.Price,
                CustomerId = model.CustomerId
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
            var response = _requestHelper.SendRequest<Response<bool>>("/Sale/Delete", new SaleDeleteCommand()
            {
                SaleId = id
            });

            if (response.Data == false)
            {
                TempData["ErrorMessage"] = response.Message;
                return RedirectToAction("Index");
            }

            TempData["SuccessMessage"] = response.Message;
            return RedirectToAction("Index");
        }

        public JsonResult GetProductPrice(int _productId)
        {
            var response = _requestHelper.SendRequest<ProductGetByIdDto>("/Product/GetById", new ProductGetByIdQuery(_productId));

            return Json(response.Price);
        }
    }
}
