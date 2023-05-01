namespace Domain.Dto.Order;

public class OrderDto
{
    public double Price { get; set; }
    public int UserId { get; set; }
    public int ShoppingCartId { get; set; }
    public string Adress { get; set; }
    /*public virtual User User { get; set; }
    public virtual ShoppingCartDto ShoppingCart { get; set; }*/
}