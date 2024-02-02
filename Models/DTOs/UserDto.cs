using System.ComponentModel.DataAnnotations;
using yummer_backend.Utils.Validation;

namespace yummer_backend.Models.DTOs;

public class UserDto
{
    [BirthDateValidation]
    public DateTime BirthDate { get; set; }
    
    [EmailAddress]
    public string? Email { get; set; }
    
    [PasswordValidation]
    public string? Password { get; set; }
}