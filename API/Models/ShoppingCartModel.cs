using API.Models.Abstract;
using Domain;

namespace API.Models;

public class ShoppingCartModel : BaseModel
{
    public int CustomerId { get; set; }
    public CartStates CartState { get; set; }
    public double FullPrice { get; set; }

    public IEnumerable<CartItemModel> CartItems { get; set; }
}