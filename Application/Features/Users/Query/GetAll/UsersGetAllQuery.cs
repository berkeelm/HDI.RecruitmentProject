using MediatR;

namespace Application.Features.Users.Query.GetAll
{
    public class UsersGetAllQuery : IRequest<List<UsersGetAllDto>>
    {
        public UsersGetAllQuery()
        {
        }
    }
}