using Application.Features.Users.Command.Add;
using Application.Features.Users.Command.Delete;
using Application.Features.Users.Command.Update;
using Application.Features.Users.Query.GetAll;
using Application.Features.Users.Query.GetById;
using Application.Features.Users.Query.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
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

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(UserDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(UsersGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetByIdAsync(UsersGetByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(UsersLoginQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}