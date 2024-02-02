using System.ComponentModel.DataAnnotations;

namespace yummer_backend.Utils.Validation
{
    public class PasswordValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string password)
            {
                if (password.Length < 10)
                {
                    return new ValidationResult(ErrorMessage ?? "Password must have at least 10 characters.");
                }
                
                if (!password.Any(char.IsUpper))
                {
                    return new ValidationResult(ErrorMessage ??"Password must have at least one uppercase character.");
                }
                
                if (!password.Any(char.IsDigit))
                {
                    return new ValidationResult(ErrorMessage ??"Password must have at least one number.");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("Wrong format!");
        }
    }
}