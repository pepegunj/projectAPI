using Data.Repositories.Abstract.Base;
using Domain.Entity;

namespace Data.Repositories.Abstract;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<IEnumerable<string>> GetAllManufacturersAsync();
}