using Application.Features.WarrantyType.Command.Add;
using Application.Features.WarrantyType.Command.Delete;
using Application.Features.WarrantyType.Command.Update;
using Application.Features.WarrantyType.Query.GetAll;
using Application.Features.WarrantyType.Query.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class WarrantyTypeController : ApiControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(WarrantyTypeAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(WarrantyTypeUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(WarrantyTypeDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(WarrantyTypeGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetByIdAsync(WarrantyTypeGetByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}