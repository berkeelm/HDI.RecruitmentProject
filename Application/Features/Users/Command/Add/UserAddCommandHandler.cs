using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Command.Add
{
    public class UserAddCommandHandler : IRequestHandler<UserAddCommand, Response<int>>
    {
        private readonly IHDIContext _HDIContext;

        public UserAddCommandHandler(IHDIContext HDIContext)
        {
            _HDIContext = HDIContext;
        }

        public async Task<Response<int>> Handle(UserAddCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                UserType = request.UserType,
                CreatedDate = DateTime.Now,
                CreatedUserId = 123,
                Email = request.Email,
                NameSurname = request.NameSurname,
                Password = request.Password,
                Username = request.Username,
            };

            await _HDIContext.User.AddAsync(user, cancellationToken);

            await _HDIContext.SaveChangesAsync(cancellationToken);

            return new Response<int>($"Kullanıcı kaydedildi.", user.Id);
        }
    }
}