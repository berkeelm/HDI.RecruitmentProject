using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.User.Command.Update
{
    public class UserUpdateCommand : IRequest<Response<bool>>
    {
        public Guid UserId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public UserType UserType { get; set; }
    }
}