using System.ComponentModel.DataAnnotations;

namespace MovieShop.Core.Models
{
    public class UserRegisterRequestModel
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Passwork must have valid length", MinimumLength = 8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "Password Should have minimum 8 with at least one upper, lower, number and special character")]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
    }
}