using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Command.Update
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;

        public UserUpdateCommandHandler(IHDIContext HDIContext)
        {
            _HDIContext = HDIContext;
        }

        public async Task<Response<bool>> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await _HDIContext.User.FirstOrDefaultAsync(x => x.Id == request.UserId && !x.IsDeleted);

            if (user == null)
                return new Response<bool>($"Kullanıcı bulunamadı.", false);

            user.NameSurname = request.NameSurname;
            user.Email = request.Email;
            user.Username = request.Username;
            user.UserType = request.UserType;
            user.UpdatedUserId = 123;
            user.UpdatedDate = DateTime.Now;

            int numberOfUpdated = await _HDIContext.SaveChangesAsync(cancellationToken);

            if (numberOfUpdated > 0)
                return new Response<bool>($"Kullanıcı güncellendi.", true);

            return new Response<bool>($"Kullanıcı güncellenirken bir hata oluştu.", false);
        }
    }
}