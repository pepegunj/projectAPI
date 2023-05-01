using System.ComponentModel.DataAnnotations;
using static Domain.Constants;

namespace Domain.Dto.Auth;

public class RegistrationModel
{
    [MinLength(USERNAME_MIN_LENGTH)]
    [MaxLength(USERNAME_MAX_LENGTH)]
    public string UserName { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    [MinLength(PASSWORD_MIN_LENGTH)]
    [MaxLength(PASSWORD_MAX_LENGTH)]
    public string Password { get; set; }

    [MinLength(PASSWORD_MIN_LENGTH)]
    [MaxLength(PASSWORD_MAX_LENGTH)]
    public string ConfirmationPassword { get; set; }

    public string? ProfileImageURL { get; set; }
}