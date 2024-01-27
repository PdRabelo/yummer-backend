using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using yummer_backend.Data;

namespace yummer_backend.Utils.Validation;

public class EmailValidations(ApiDbContext context) : ValidationAttribute
{
    private readonly ApiDbContext _context = context;

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string email)
        {
            if ()
            {
                return new ValidationResult(ErrorMessage ?? "Email already in use");
            }
        }
        
        return ValidationResult.Success;
    }
}