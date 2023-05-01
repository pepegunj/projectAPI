using Domain.Abstract;

namespace Domain.Entity;

public class CartItem : BaseEntity
{
    public int Quantity { get; set; }
    public double Price { get; set; }

    public int ShoppingCartId { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}