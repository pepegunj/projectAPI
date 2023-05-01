using Domain.Abstract;

namespace Domain.Entity;

public class ShoppingCart : BaseEntity
{
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    //public IEnumerable<Order> Orders { get; set; }

    public IEnumerable<CartItem> CartItems { get; set; }

    public CartStates CartState { get; set; }
}