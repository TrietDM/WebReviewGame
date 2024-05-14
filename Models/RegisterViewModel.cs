using System.ComponentModel.DataAnnotations;

namespace WebReviewGame.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

    }
}
