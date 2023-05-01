using System.ComponentModel.DataAnnotations;
using static Domain.Constants;

namespace Domain.Dto.Auth;

public class AuthRequest
{
    [Required]
    [MinLength(USERNAME_MIN_LENGTH)]
    [MaxLength(USERNAME_MAX_LENGTH)]
    public string UserName { get; set; }

    [Required]
    [MinLength(PASSWORD_MIN_LENGTH)]
    [MaxLength(PASSWORD_MAX_LENGTH)]
    public string Password { get; set; }
}