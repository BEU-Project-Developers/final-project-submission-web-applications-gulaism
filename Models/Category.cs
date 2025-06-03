using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace KodlaWebApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string Name { get; set; }

        public string Description { get; set; }

        // courses belonging to this category
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
