using Application.Features.User.Query.Login;

namespace Application.Common.Interfaces
{
    public interface IJwtService
    {
        UserLoginDto Generate(int userId);
        int? ValidateJwtToken(string token);
    }
}