using DAL.EF;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BLL.Validations
{
    public class UniqueEmail : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var db = (BookManagementContext)
                validationContext.GetService(typeof(BookManagementContext));

            var email = value.ToString();

            var data = (from u in db.Users
                        where u.Email == email
                        select u).SingleOrDefault();

            if (data == null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Email already exists");
        }
    }
}