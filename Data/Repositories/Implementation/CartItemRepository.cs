using Data.Repositories.Abstract;
using Data.Repositories.Abstract.Base;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementation;

public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
{
    public CartItemRepository(ApplicationDbContext db) : base(db)
    {
    }


    public async Task<IEnumerable<CartItem>> GetAllCartItemsByCartId(int cartId)
    {
        return await _db.CartItems.Include(opt => opt.ShoppingCart).Where(opt => opt.ShoppingCartId == cartId)
            .ToListAsync();
    }
}