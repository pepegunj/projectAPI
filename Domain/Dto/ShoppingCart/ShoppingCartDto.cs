namespace Domain.Dto.ShoppingCart;

public class ShoppingCartDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public double FullPrice { get; set; }
    public CartStates CartState { get; set; }
    public IEnumerable<CartItemDto> CartItems { get; set; }
}