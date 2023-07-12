using Application.Features.Users.Query.Login;

namespace Application.Common.Interfaces
{
    public interface IJwtService
    {
        UsersLoginDto Generate(int userId);
        int? ValidateJwtToken(string token);
    }
}