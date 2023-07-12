using MediatR;

namespace Application.Features.Users.Query.GetById
{
    public class UsersGetByIdQuery : IRequest<UsersGetByIdDto>
    {
        public int UserId { get; set; }

        public UsersGetByIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
