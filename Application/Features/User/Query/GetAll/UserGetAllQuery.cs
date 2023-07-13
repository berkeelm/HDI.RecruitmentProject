using Domain.Enums;
using MediatR;

namespace Application.Features.User.Query.GetAll
{
    public class UserGetAllQuery : IRequest<List<UserGetAllDto>>
    {
        public UserType? UserType { get; set; } = null;

        public UserGetAllQuery()
        {

        }

        public UserGetAllQuery(UserType? UserType)
        {
            this.UserType = UserType;
        }
    }
}