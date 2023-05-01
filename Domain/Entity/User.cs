using Domain.Abstract;

namespace Domain.Entity;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } = "User";

    public string? ProfileImageURL { get; set; }

    /* public int CardId { get; set; }
     public ShoppingCart Cart {get;set;}*/
}