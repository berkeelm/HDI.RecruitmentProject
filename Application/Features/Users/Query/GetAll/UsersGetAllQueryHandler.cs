using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Query.GetAll
{
    public class UsersGetAllQueryHandler : IRequestHandler<UsersGetAllQuery, List<UsersGetAllDto>>
    {
        private readonly IHDIContext _HDIContext;

        public UsersGetAllQueryHandler(IHDIContext HDIContext)
        {
            _HDIContext = HDIContext;
        }

        public async Task<List<UsersGetAllDto>> Handle(UsersGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _HDIContext.User.Include(x => x.CreatedUser).Include(x => x.UpdatedUser).Where(x => !x.IsDeleted);

            var users = await dbQuery.ToListAsync(cancellationToken);

            var usersDto = users.Select(x => new UsersGetAllDto()
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