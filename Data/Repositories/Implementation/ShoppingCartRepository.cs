using System.Linq.Expressions;
using Data.Repositories.Abstract;
using Data.Repositories.Abstract.Base;
using Domain;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementation;

public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
{
    public ShoppingCartRepository(ApplicationDbContext db) : base(db)
    {
    }

    public async Task BillCartByIdAsync(int id)
    {
        var cartFromDb = await GetByIdAsync(id);
        cartFromDb.CartState = CartStates.Billed;
        await UpdateAsync(cartFromDb);
    }

    public async Task<IEnumerable<ShoppingCart>> GetByCustomerIdAsync(Expression<Func<ShoppingCart, bool>> predicate)
    {
        return await _db.ShoppingCarts.Include(x => x.CartItems).ThenInclude(x => x.Product).Include(x => x.Customer)
            .Where(predicate)
            .ToListAsync();
    }
}