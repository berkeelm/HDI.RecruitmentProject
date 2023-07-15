using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Command.Add
{
    public class UserAddCommandHandler : IRequestHandler<UserAddCommand, Response<Guid?>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;
        private readonly ISignalRHelper _signalRHelper;

        public UserAddCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper, ISignalRHelper signalRHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
            _signalRHelper = signalRHelper;
        }

        public async Task<Response<Guid?>> Handle(UserAddCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _HDIContext.User.FirstOrDefault(x => x.Id == (Guid)_httpContextAccessor.HttpContext.Items["User"]);

            var control = await _HDIContext.User.FirstOrDefaultAsync(x => x.Username == request.Username && !x.IsDeleted);

            if (control != null)
                return new Response<Guid?>($"Kullanıcı adı kayıtlıdır, lütfen başka bir kullanıcı adı giriniz.", (Guid?)null);

            control = await _HDIContext.User.FirstOrDefaultAsync(x => x.Email == request.Email && !x.IsDeleted);

            if (control != null)
                return new Response<Guid?>($"Mail adresi kayıtlıdır, lütfen başka bir mail adresi giriniz.", (Guid?)null);

            var user = new Domain.Entities.User()
            {
                UserType = request.UserType.GetValueOrDefault(),
                CreatedDate = DateTime.Now,
                CreatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"],
                Email = request.Email,
                NameSurname = request.NameSurname,
                Password = _cryptographyHelper.ComputeMD5Hash(request.Password),
                Username = request.Username,
            };

            await _HDIContext.User.AddAsync(user, cancellationToken);


            await _HDIContext.SaveChangesAsync(cancellationToken);

            await _signalRHelper.SendLog($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm")}] {currentUser.NameSurname} isimli kullanıcı {user.NameSurname} isimli kullanıcıyı ekledi.");

            return new Response<Guid?>($"Kullanıcı kaydedildi.", user.Id);
        }
    }
}