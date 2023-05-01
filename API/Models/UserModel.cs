using System.ComponentModel.DataAnnotations;
using API.Models.Abstract;

namespace API.Models;

public class UserModel : BaseModel
{
    /*        [Required]*/
    /*        public int Id { get; set; }*/
    [Required] public string Username { get; set; }

    [Required] public string Password { get; set; }
}