using Application.Features.User.Query.Login;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IJwtService
    {
        UserLoginDto Generate(User user);
        Guid? ValidateJwtToken(string token);
    }
}