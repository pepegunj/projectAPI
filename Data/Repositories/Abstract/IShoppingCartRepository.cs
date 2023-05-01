using System.Linq.Expressions;
using Data.Repositories.Abstract.Base;
using Domain.Entity;

namespace Data.Repositories.Abstract;

public interface IShoppingCartRepository : IBaseRepository<ShoppingCart>
{
    Task<IEnumerable<ShoppingCart>> GetByCustomerIdAsync(Expression<Func<ShoppingCart, bool>> predicate);
    Task BillCartByIdAsync(int id);
}