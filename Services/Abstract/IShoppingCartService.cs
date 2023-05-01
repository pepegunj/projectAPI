using Domain.Dto.ShoppingCart;
using Services.Abstract.Base;

namespace Services.Abstract;

public interface IShoppingCartService : IBaseService<ShoppingCartDto>
{
    Task<ShoppingCartDto> GetActiveShoppingCartAsync(int id);
    Task<IEnumerable<ShoppingCartDto>> GetAllShoppingCartsByIdAsync(int id);
    Task BillCartByIdAsync(int id);
}