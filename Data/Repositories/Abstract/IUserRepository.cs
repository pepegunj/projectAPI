using Data.Repositories.Abstract.Base;
using Domain.Entity;

namespace Data.Repositories.Abstract;

public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> AddAdminByIdAsync(int id);
}