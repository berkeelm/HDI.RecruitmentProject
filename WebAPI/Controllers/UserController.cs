using Application.Features.User.Command.Add;
using Application.Features.User.Command.Delete;
using Application.Features.User.Command.Update;
using Application.Features.User.Query.GetAll;
using Application.Features.User.Query.GetById;
using Application.Features.User.Query.Login;
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
        public async Task<IActionResult> GetAllAsync(UserGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetByIdAsync(UserGetByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(UserLoginQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}