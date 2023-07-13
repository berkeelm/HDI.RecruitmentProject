using Application.Features.Customer.Command.Add;
using Application.Features.Customer.Command.Delete;
using Application.Features.Customer.Command.Update;
using Application.Features.Customer.Query.GetAll;
using Application.Features.Customer.Query.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class CustomerController : ApiControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(CustomerAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(CustomerUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(CustomerDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(CustomerGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetByIdAsync(CustomerGetByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}