using System.ComponentModel.DataAnnotations;

namespace yummer_backend.Utils.Validation;

public class BirthDateValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime birthDate)
        {
            if (birthDate >= DateTime.Now)
            {
                return new ValidationResult(ErrorMessage ?? "Birth date must be in the past.");
            }
        }
        return ValidationResult.Success;
    }
    
}