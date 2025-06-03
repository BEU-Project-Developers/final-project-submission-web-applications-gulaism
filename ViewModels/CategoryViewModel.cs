using System.ComponentModel.DataAnnotations;

namespace KodlaWebApp.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        [Display(Name = "Category pname")] // for UI display
        public string Name { get; set; }

        [Display(Name = "Category Description")]

        public string Description { get; set; }
    }
}
