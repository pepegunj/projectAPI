using Domain.Abstract;

namespace Domain.Entity;

public class Order : BaseEntity
{
    public double Price { get; set; }
    public string Adress { get; set; }

    public int ShoppingCartId { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
}