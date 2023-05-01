using Domain.Dto.Auth;

namespace Services.Abstract.Auth;

public interface IAuthService
{
    Task<AuthResponse> Authenticate(AuthRequest request);
}