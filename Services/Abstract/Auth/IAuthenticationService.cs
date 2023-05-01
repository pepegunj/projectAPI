using Domain.Dto.Auth;

namespace Services.Abstract.Auth;

public interface IAuthenticationService
{
    Task<AuthResponse> AuthenticateAsync(AuthRequest request);
}