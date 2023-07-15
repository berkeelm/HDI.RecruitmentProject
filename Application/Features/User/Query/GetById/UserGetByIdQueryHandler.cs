using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Query.GetById
{
    public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQuery, UserGetByIdDto>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserGetByIdQueryHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserGetByIdDto> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _HDIContext.User.Include(x => x.CreatedUser).Include(x => x.UpdatedUser).Where(x => !x.IsDeleted);

            if (request.UserId.HasValue)
            {
                dbQuery = dbQuery.Where(x => x.Id == request.UserId.GetValueOrDefault());
            }
            else
            {
                dbQuery = dbQuery.Where(x => x.Id == (Guid)_httpContextAccessor.HttpContext.Items["User"]);
            }


            var user = await dbQuery.FirstOrDefaultAsync(cancellationToken);

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