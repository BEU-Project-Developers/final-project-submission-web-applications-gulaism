using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KodlaWebApp.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course title is required.")]
        [StringLength(100, ErrorMessage = "Course title cannot exceed 100 characters.")]
        [Display(Name = "Course title")]
        public string Title { get; set; }

        [Display(Name = "Course description")]
        public string Description { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        public string CategoryName { get; set; }

        public IEnumerable<SelectListItem> AvailableCategories { get; set; }
    }
}
