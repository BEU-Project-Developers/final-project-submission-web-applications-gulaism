using KodlaWebApp.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace KodlaWebApp.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Course title is required.")]
        [StringLength(100, ErrorMessage = "Course title cannot exceed 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Course description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The category field is required.")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
