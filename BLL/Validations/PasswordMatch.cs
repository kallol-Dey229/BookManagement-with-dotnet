using BLL.DTOs;
using System.ComponentModel.DataAnnotations;

namespace BLL.Validations
{
    public class PasswordMatch : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var obj = validationContext.ObjectInstance as UserDTO;

            if (obj != null && obj.Password != null &&
                obj.Password.Equals(value.ToString()))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Confirm Password does not match");
        }
    }
}