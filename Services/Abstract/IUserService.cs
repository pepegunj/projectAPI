using Domain.Dto.User;
using Services.Abstract.Base;

namespace Service.Abstract;

public interface IUserService : IBaseService<UserDto>
{
    Task<UserDto> GetByUsername(string username);
    Task<bool> AddAdminByIdAsync(int id);
}