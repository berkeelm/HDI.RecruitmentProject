using Application.Features.SaleWarranty.Command.Add;
using Application.Features.SaleWarranty.Command.Delete;
using Application.Features.SaleWarranty.Command.Update;
using Application.Features.SaleWarranty.Query.GetAll;
using Application.Features.SaleWarranty.Query.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class SaleWarrantyController : ApiControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(SaleWarrantyAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(SaleWarrantyUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(SaleWarrantyDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(SaleWarrantyGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetByIdAsync(SaleWarrantyGetByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}