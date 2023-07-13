using Application.Features.Product.Command.Add;
using Application.Features.Product.Command.Delete;
using Application.Features.Product.Command.Update;
using Application.Features.Product.Query.GetAll;
using Application.Features.Product.Query.GetById;
using Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.Interfaces;

namespace WebUI.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IRequestHelper requestHelper, IWebHostEnvironment env) : base(requestHelper, env)
        {
        }

        public IActionResult Index()
        {
            var response = _requestHelper.SendRequest<List<ProductGetAllDto>>("/Product/GetAll", new ProductGetAllQuery());

            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ProductAddCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddCommand model, IFormFile formFile)
        {
            if (formFile != null)
            {
                var extent = Path.GetExtension(formFile.FileName);
                var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(_env.WebRootPath, "uploads", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }

                model.PhotoPath = randomName;
            }

            var response = _requestHelper.SendRequest<Response<int>>("/Product/Add", model);

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
            var response = _requestHelper.SendRequest<ProductGetByIdDto>("/Product/GetById", new ProductGetByIdQuery(id));

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductGetByIdDto model, IFormFile formFile)
        {
            if (formFile != null)
            {
                var extent = Path.GetExtension(formFile.FileName);
                var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine(_env.WebRootPath, "uploads", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }

                model.PhotoPath = randomName;
            }

            var response = _requestHelper.SendRequest<Response<bool>>("/Product/Update", new ProductUpdateCommand()
            {
                PhotoPath = model.PhotoPath,
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,
                ProductId = model.Id
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
            var response = _requestHelper.SendRequest<Response<bool>>("/Product/Delete", new ProductDeleteCommand()
            {
                ProductId = id
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
