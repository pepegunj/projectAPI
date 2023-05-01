using Data.Repositories.Abstract;
using Data.Repositories.Abstract.Base;
using Domain.Entity;

namespace Data.Repositories.Implementation;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext db) : base(db)
    {
    }

    public async Task<bool> AddAdminByIdAsync(int id)
    {
        var userFrobDb = await GetByIdAsync(id);
        userFrobDb.Role = "Admin";
        await UpdateAsync(userFrobDb);
        return true;
    }
}