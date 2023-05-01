using Data.Repositories.Abstract;
using Data.Repositories.Abstract.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementation;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext db) : base(db)
    {
    }

    public async Task<IEnumerable<string>> GetAllManufacturersAsync()
    {
        return await _db.Set<Product>().Select(x => x.Manufacturer).Distinct().ToListAsync();
    }
}