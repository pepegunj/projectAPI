using AutoMapper;
using Data.Repositories.Abstract;
using Domain.Dto.Pagination;
using Domain.Dto.User;
using Domain.Entity;
using Service.Abstract;

namespace Services.Implementation;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(UserDto entity)
    {
        var user = _mapper.Map<User>(entity);
        await _userRepository.AddAsync(user);
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var result = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserDto>>(result);
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        var result = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserDto>(result);
    }

    public async Task<UserDto?> GetByUsername(string username)
    {
        var user = await _userRepository.GetAllWhereAsync(x => x.Username == username);
        return _mapper.Map<UserDto>(user.FirstOrDefault());
    }

    public async Task<bool> RemoveAsync(int id, int issuerId)
    {
        return await _userRepository.DeleteAsync(id);
    }

    public async Task UpdateAsync(UserDto entity)
    {
        var result = _mapper.Map<User>(entity);
        await _userRepository.UpdateAsync(result);
    }

    public async Task<PaginatedResult<UserDto>> GetPageAsync(PagedRequest query, CancellationToken cancellationToken)
    {
        var result = await _userRepository.GetPagedData(query, cancellationToken);
        return _mapper.Map<PaginatedResult<UserDto>>(result);
    }

    public async Task<bool> AddAdminByIdAsync(int id)
    {
        return await _userRepository.AddAdminByIdAsync(id);
    }
}