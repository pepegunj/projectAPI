using Domain.Abstract;

namespace Domain.Entity;

public class Customer : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    public List<ShoppingCart> ShoppingCarts { get; set; }
    public IEnumerable<Order> Orders { get; set; }
}

//User -> customer. logging -> check if cart exists. if not - Create
//    item+ 
//        CartItem +
//        bill. ->after bill -> cart = null.