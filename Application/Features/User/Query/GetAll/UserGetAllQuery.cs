using MediatR;

namespace Application.Features.User.Query.GetAll
{
    public class UserGetAllQuery : IRequest<List<UserGetAllDto>>
    {
        public UserGetAllQuery()
        {
        }
    }
}