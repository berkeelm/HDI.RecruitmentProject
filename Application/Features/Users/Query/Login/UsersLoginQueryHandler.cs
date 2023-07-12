using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Query.Login
{
    public class UsersLoginQueryHandler : IRequestHandler<UsersLoginQuery, UsersLoginDto>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IJwtService _jwtService;
        private readonly ICryptographyHelper _cryptographyHelper;

        public UsersLoginQueryHandler(IHDIContext HDIContext, IJwtService jwtService, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _jwtService = jwtService;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<UsersLoginDto> Handle(UsersLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _HDIContext.User.FirstOrDefaultAsync(x => x.Username == request.Username && x.Password == _cryptographyHelper.ComputeMD5Hash(request.Password) && !x.IsDeleted);

            if (user == null)
                return null;

            return _jwtService.Generate(user.Id);
        }
    }
}