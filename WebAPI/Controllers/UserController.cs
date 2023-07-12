using Application.Features.Users.Command.Add;
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
    }
}