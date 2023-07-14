using MediatR;

namespace Application.Features.User.Query.GetById
{
    public class UserGetByIdQuery : IRequest<UserGetByIdDto>
    {
        public Guid UserId { get; set; }

        public UserGetByIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
