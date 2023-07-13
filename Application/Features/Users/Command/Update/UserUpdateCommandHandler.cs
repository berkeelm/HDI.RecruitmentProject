using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Command.Update
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserUpdateCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<bool>> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var control = await _HDIContext.User.FirstOrDefaultAsync(x => x.Id != request.UserId && x.Username == request.Username && !x.IsDeleted);

            if (control != null)
                return new Response<bool>($"Kullanıcı adı kayıtlıdır, lütfen başka bir kullanıcı adı giriniz.", false);

            control = await _HDIContext.User.FirstOrDefaultAsync(x => x.Id != request.UserId && x.Email == request.Email && !x.IsDeleted);

            if (control != null)
                return new Response<bool>($"Mail adresi kayıtlıdır, lütfen başka bir mail adresi giriniz.", false);

            var user = await _HDIContext.User.FirstOrDefaultAsync(x => x.Id == request.UserId && !x.IsDeleted);

            if (user == null)
                return new Response<bool>($"Kullanıcı bulunamadı.", false);

            user.NameSurname = request.NameSurname;
            user.Email = request.Email;
            user.Username = request.Username;
            user.UserType = request.UserType;
            user.UpdatedUserId = (int)_httpContextAccessor.HttpContext.Items["User"];
            user.UpdatedDate = DateTime.Now;

            int numberOfUpdated = await _HDIContext.SaveChangesAsync(cancellationToken);

            if (numberOfUpdated > 0)
                return new Response<bool>($"Kullanıcı güncellendi.", true);

            return new Response<bool>($"Kullanıcı güncellenirken bir hata oluştu.", false);
        }
    }
}