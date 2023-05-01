using API.Models.Abstract;

namespace API.Models;

public class CustomerModel : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int UserId { get; set; }
}