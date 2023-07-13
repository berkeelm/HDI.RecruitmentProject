using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Query.GetAll
{
    public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, List<UserGetAllDto>>
    {
        private readonly IHDIContext _HDIContext;

        public UserGetAllQueryHandler(IHDIContext HDIContext)
        {
            _HDIContext = HDIContext;
        }

        public async Task<List<UserGetAllDto>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _HDIContext.User.Include(x => x.CreatedUser).Include(x => x.UpdatedUser).Where(x => !x.IsDeleted);

            if (request.UserType.HasValue)
            {
                dbQuery = dbQuery.Where(x => x.UserType == request.UserType);
            }

            var users = await dbQuery.ToListAsync(cancellationToken);

            var usersDto = users.Select(x => new UserGetAllDto()
            {
                UpdatedUser = x.UpdatedUser == null ? null : x.UpdatedUser.NameSurname,
                CreatedDate = x.CreatedDate,
                CreatedUser = x.CreatedUser == null ? null : x.CreatedUser.NameSurname,
                Email = x.Email,
                Id = x.Id,
                NameSurname = x.NameSurname,
                UpdatedDate = x.UpdatedDate,
                Username = x.Username,
                UserType = x.UserType
            });

            return usersDto.ToList();
        }
    }
}