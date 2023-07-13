using Application.Features.Product.Command.Add;
using Application.Features.Product.Command.Delete;
using Application.Features.Product.Command.Update;
using Application.Features.Product.Query.GetAll;
using Application.Features.Product.Query.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class ProductController : ApiControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(ProductAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(ProductUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(ProductDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(ProductGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetByIdAsync(ProductGetByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}