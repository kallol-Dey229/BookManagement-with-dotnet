using BLL.Validations;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [UniqueEmail]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [PasswordMatch]
        public string? ConfirmPassword { get; set; }
    }
}