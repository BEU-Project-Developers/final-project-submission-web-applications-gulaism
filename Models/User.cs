using KodlaWebApp.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace KodlaWebApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Email is required!👿...")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!😒...")]
        public string PasswordHash { get; set; }

        // comments made by this user
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
