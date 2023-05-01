using AutoMapper;
using Data.Repositories.Abstract;
using Domain.Dto.Auth;
using Services.Abstract.Auth;

namespace Services.Implementation.Auth;

public class AuthService : IAuthenticationService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AuthResponse?> AuthenticateAsync(AuthRequest request)
    {
        var result = await FindUser(request.UserName, request.Password);

        return result;
    }

    private async Task<AuthResponse?> FindUser(string username, string password)
    {
        var user = await _userRepository.GetAllWhereAsync(x => x.Username == username && x.Password == password);

        if (user.Any())
        {
            var foundUser = user.First();
            var response = _mapper.Map<AuthResponse>(foundUser);
            return response;
        }

        return null;
    }
}