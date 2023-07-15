using Application.Features.SaleProblem.Command.Add;
using Application.Features.SaleProblem.Command.Delete;
using Application.Features.SaleProblem.Command.Update;
using Application.Features.SaleProblem.Query.GetAll;
using Application.Features.SaleProblem.Query.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class SaleProblemController : ApiControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(SaleProblemAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(SaleProblemUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(SaleProblemDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(SaleProblemGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetByIdAsync(SaleProblemGetByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}