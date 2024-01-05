using System.ComponentModel.DataAnnotations;

public class UserDto
{
    [Required (ErrorMessage = "Name is mandatory!")]
    public string Name { get; set; } = null!;

    [Required (ErrorMessage = "Password is mandatory!")]

    public string Password { get; set; } = null!;
    
    [Required (ErrorMessage = "Email is mandatory!")]
    [EmailAddress (ErrorMessage = "Email is not valid!")]

    public string Email { get; set; } = null!;

    [Required (ErrorMessage = "Birth date is mandatory!")]
    [DataType(DataType.DateTime, ErrorMessage = "Not valid date")]
    [BirthDateValidation(ErrorMessage = "Birth date must be in the past.")]
    public DateTime BirthDate { get; set; }
}
