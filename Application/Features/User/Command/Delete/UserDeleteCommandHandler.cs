using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Command.Delete
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;

        public UserDeleteCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<Response<bool>> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var user = await _HDIContext.User.FirstOrDefaultAsync(x => x.Id == request.UserId && !x.IsDeleted);

            if (user == null)
                return new Response<bool>($"Kullanıcı bulunamadı.", false);

            user.IsDeleted = true;
            user.UpdatedUserId = (int)_httpContextAccessor.HttpContext.Items["User"];
            user.UpdatedDate = DateTime.Now;

            await _HDIContext.SaveChangesAsync(cancellationToken);

            return new Response<bool>($"Kullanıcı silindi.", true);
        }
    }
}