using Domain.Dto.Auth;

namespace Services.Abstract.Auth;

public interface ITokenService
{
    public string GetAccessToken(AuthResponse user);
}