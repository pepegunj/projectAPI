using API.Models.Abstract;

namespace API.Models;

public class CartItemModel : BaseModel
{
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }

    public string ProductName { get; set; }
    public string ProductDescription { get; set; }

    public string Category { get; set; }
    public string iconURL { get; set; }
    public int Price { get; set; }
}