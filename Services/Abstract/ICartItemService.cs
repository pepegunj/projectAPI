using Domain.Dto.ShoppingCart;
using Services.Abstract.Base;

namespace Services.Abstract;

public interface ICartItemService : IBaseService<CartItemDto>
{
    Task<IEnumerable<CartItemDto>> getCartItemsByCartIdAsync(int id);
}