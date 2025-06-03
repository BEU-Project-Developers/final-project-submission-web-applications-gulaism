using System.ComponentModel.DataAnnotations;

namespace KodlaWebApp.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Email is required!👿...")]
        [EmailAddress(ErrorMessage = "Please write a valid email address!🙏...")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!😒...")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}
