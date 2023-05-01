namespace Domain.Dto.ShoppingCart;

public class CartItemDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string Category { get; set; }
    public string iconURL { get; set; }
    public int CustomerId { get; set; }
}