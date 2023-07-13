using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Command.Add
{
    public class UserAddCommandHandler : IRequestHandler<UserAddCommand, Response<int>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;

        public UserAddCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<Response<int>> Handle(UserAddCommand request, CancellationToken cancellationToken)
        {
            var control = await _HDIContext.User.FirstOrDefaultAsync(x => x.Username == request.Username && !x.IsDeleted);

            if (control != null)
                return new Response<int>($"Kullanıcı adı kayıtlıdır, lütfen başka bir kullanıcı adı giriniz.", 0);

            control = await _HDIContext.User.FirstOrDefaultAsync(x => x.Email == request.Email && !x.IsDeleted);

            if (control != null)
                return new Response<int>($"Mail adresi kayıtlıdır, lütfen başka bir mail adresi giriniz.", 0);

            var user = new User()
            {
                UserType = request.UserType.GetValueOrDefault(),
                CreatedDate = DateTime.Now,
                CreatedUserId = (int)_httpContextAccessor.HttpContext.Items["User"],
                Email = request.Email,
                NameSurname = request.NameSurname,
                Password = _cryptographyHelper.ComputeMD5Hash(request.Password),
                Username = request.Username,
            };

            await _HDIContext.User.AddAsync(user, cancellationToken);

            await _HDIContext.SaveChangesAsync(cancellationToken);

            return new Response<int>($"Kullanıcı kaydedildi.", user.Id);
        }
    }
}