using System.ComponentModel.DataAnnotations;

namespace KodlaWebApp.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Email is required!👿...")]
        [EmailAddress(ErrorMessage = "Please write a valid email address!🙏...")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!😒...")]
        public string Password { get; set; }
    }
}
