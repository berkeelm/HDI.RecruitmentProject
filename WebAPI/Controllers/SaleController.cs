using Application.Features.Sale.Command.Add;
using Application.Features.Sale.Command.Delete;
using Application.Features.Sale.Command.Update;
using Application.Features.Sale.Query.GetAll;
using Application.Features.Sale.Query.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class SaleController : ApiControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(SaleAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(SaleUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(SaleDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(SaleGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetByIdAsync(SaleGetByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}