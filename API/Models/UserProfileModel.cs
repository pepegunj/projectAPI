using API.Models.Abstract;

namespace API.Models
{
    public class UserProfileModel : BaseModel
    {
        public string Username { get; set; }
        public string? ProfileImageURL { get; set; }

    }
}
