using MediatR;

namespace Application.Features.User.Query.GetById
{
    public class UserGetByIdQuery : IRequest<UserGetByIdDto>
    {
        public int UserId { get; set; }

        public UserGetByIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
