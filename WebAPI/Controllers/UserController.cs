using Application.Features.Users.Command.Add;
using Application.Features.Users.Command.Update;
using Application.Features.Users.Query.GetAll;
using Application.Features.Users.Query.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class UserController : ApiControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(UserAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(UserUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(UsersGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById(UsersGetByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}