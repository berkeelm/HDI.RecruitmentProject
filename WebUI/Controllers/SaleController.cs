using Application.Features.Customer.Query.GetAll;
using Application.Features.Product.Query.GetAll;
using Application.Features.Product.Query.GetById;
using Application.Features.Sale.Command.Add;
using Application.Features.Sale.Command.Delete;
using Application.Features.Sale.Command.Update;
using Application.Features.Sale.Query.GetAll;
using Application.Features.Sale.Query.GetById;
using Application.Features.SaleProblem.Query.GetAll;
using Application.Features.SaleWarranty.Query.GetAll;
using Application.Features.User.Query.GetAll;
using Domain.Common;
using Domain.Enums;
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

        public IActionResult Index(string ProductName, string CustomerName, string RepairChangeCenterName, DateTime? CreatedDate, string CreatedUser)
        {
            var saleList = _requestHelper.SendRequest<List<SaleGetAllDto>>("/Sale/GetAll", new SaleGetAllQuery(ProductName, CustomerName, RepairChangeCenterName, CreatedDate, CreatedUser));

            var viewModel = new SaleListViewModel()
            {
                ProductName = ProductName,
                SaleList = saleList,
                CustomerName = CustomerName,
                RepairChangeCenterName = RepairChangeCenterName,
                CreatedDate = CreatedDate,
                CreatedUser = CreatedUser
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var productList = _requestHelper.SendRequest<List<ProductGetAllDto>>("/Product/GetAll", new ProductGetAllQuery());
            var customerList = _requestHelper.SendRequest<List<CustomerGetAllDto>>("/Customer/GetAll", new CustomerGetAllQuery());
            var userList = _requestHelper.SendRequest<List<UserGetAllDto>>("/User/GetAll", new UserGetAllQuery(UserType.RepairChangeCenterUser));

            var viewModel = new AddSaleViewModel()
            {
                CustomerList = customerList,
                ProductList = productList,
                UserList = userList
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(SaleAddCommand model)
        {
            var response = _requestHelper.SendRequest<Response<Guid?>>("/Sale/Add", model);

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
        public IActionResult Delete(Guid id)
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

        public JsonResult GetProductPrice(Guid _productId)
        {
            var response = _requestHelper.SendRequest<ProductGetByIdDto>("/Product/GetById", new ProductGetByIdQuery(_productId));

            return Json(response.Price);
        }

        [HttpGet]
        public IActionResult History(Guid id)
        {
            var Sale = _requestHelper.SendRequest<SaleGetByIdDto>("/Sale/GetById", new SaleGetByIdQuery(id));
            var saleWarranties = _requestHelper.SendRequest<List<SaleWarrantyGetAllDto>>("/SaleWarranty/GetAll", new SaleWarrantyGetAllQuery(id));
            var saleProblems = _requestHelper.SendRequest<List<SaleProblemGetAllDto>>("/SaleProblem/GetAll", new SaleProblemGetAllQuery(id));
            //garanti history
            //arıza geçmişi

            var viewModel = new SaleHistoryViewModel()
            {
                Sale = Sale,
                SaleWarranties = saleWarranties,
                SaleProblems = saleProblems
            };

            return View(viewModel);
        }
    }
}
