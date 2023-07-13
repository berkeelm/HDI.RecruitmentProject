using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Query.Login
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, UserLoginDto>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IJwtService _jwtService;
        private readonly ICryptographyHelper _cryptographyHelper;

        public UserLoginQueryHandler(IHDIContext HDIContext, IJwtService jwtService, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _jwtService = jwtService;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<UserLoginDto> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _HDIContext.User.FirstOrDefaultAsync(x => x.Username == request.Username && x.Password == _cryptographyHelper.ComputeMD5Hash(request.Password) && !x.IsDeleted);

            if (user == null)
                return null;

            return _jwtService.Generate(user.Id);
        }
    }
}