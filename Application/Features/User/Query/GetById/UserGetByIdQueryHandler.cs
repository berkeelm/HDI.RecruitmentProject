using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Query.GetById
{
    public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQuery, UserGetByIdDto>
    {
        private readonly IHDIContext _HDIContext;

        public UserGetByIdQueryHandler(IHDIContext HDIContext)
        {
            _HDIContext = HDIContext;
        }

        public async Task<UserGetByIdDto> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _HDIContext.User.Include(x => x.CreatedUser).Include(x => x.UpdatedUser).FirstOrDefaultAsync(x => x.Id == request.UserId && !x.IsDeleted);

            if (user == null)
                return null;

            var userDto = new UserGetByIdDto()
            {
                UpdatedUser = user.UpdatedUser == null ? null : user.UpdatedUser.NameSurname,
                CreatedDate = user.CreatedDate,
                CreatedUser = user.CreatedUser == null ? null : user.CreatedUser.NameSurname,
                Email = user.Email,
                Id = user.Id,
                NameSurname = user.NameSurname,
                UpdatedDate = user.UpdatedDate,
                Username = user.Username,
                UserType = user.UserType
            };

            return userDto;
        }
    }
}