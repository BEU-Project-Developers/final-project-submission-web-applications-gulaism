using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KodlaWebApp.Models
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lesson title is required.")]
        [StringLength(200, ErrorMessage = "Lesson title cannot exceed 200 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lesson content is required.")]
        public string Content { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        // comments of this lesson
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
