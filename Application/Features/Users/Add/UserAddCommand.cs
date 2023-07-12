using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Users.Command.Add
{
    public class UserAddCommand : IRequest<Response<int>>
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}