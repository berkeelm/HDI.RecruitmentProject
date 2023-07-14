using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.User.Command.Add
{
    public class UserAddCommand : IRequest<Response<Guid>>
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType? UserType { get; set; } = null;
    }
}