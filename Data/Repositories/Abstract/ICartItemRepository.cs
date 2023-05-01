using Data.Repositories.Abstract.Base;
using Domain.Entity;

namespace Data.Repositories.Abstract;

public interface ICartItemRepository : IBaseRepository<CartItem>
{
    Task<IEnumerable<CartItem>> GetAllCartItemsByCartId(int cartId);
}