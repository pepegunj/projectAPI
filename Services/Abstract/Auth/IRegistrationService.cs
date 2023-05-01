using Domain.Dto.Auth;
using Domain.Dto.User;

namespace Services.Abstract.Auth;

public interface IRegistrationService
{
    public Task<UserDto> RegistrationAsync(RegistrationModel registration);
}