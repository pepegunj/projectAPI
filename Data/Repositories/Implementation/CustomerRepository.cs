using Data.Repositories.Abstract;
using Data.Repositories.Abstract.Base;
using Domain.Entity;

namespace Data.Repositories.Implementation;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext db) : base(db)
    {
    }
}