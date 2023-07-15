using Application.Common.Helpers;
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
        private readonly ISignalRHelper _signalRHelper;

        public UserDeleteCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper, ISignalRHelper signalRHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
            _signalRHelper = signalRHelper;
        }

        public async Task<Response<bool>> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _HDIContext.User.FirstOrDefault(x => x.Id == (Guid)_httpContextAccessor.HttpContext.Items["User"]);

            var user = await _HDIContext.User.FirstOrDefaultAsync(x => x.Id == request.UserId && !x.IsDeleted);

            if (user == null)
                return new Response<bool>($"Kullanıcı bulunamadı.", false);

            user.IsDeleted = true;
            user.UpdatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"];
            user.UpdatedDate = DateTime.Now;

            await _HDIContext.SaveChangesAsync(cancellationToken);

            await _signalRHelper.SendLog($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm")}] {currentUser.NameSurname} isimli kullanıcı {user.NameSurname} isimli kullanıcıyı sildi.");

            return new Response<bool>($"Kullanıcı silindi.", true);
        }
    }
}