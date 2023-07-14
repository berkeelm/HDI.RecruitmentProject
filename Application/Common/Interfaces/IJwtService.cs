using Application.Features.User.Query.Login;

namespace Application.Common.Interfaces
{
    public interface IJwtService
    {
        UserLoginDto Generate(Guid userId);
        Guid? ValidateJwtToken(string token);
    }
}