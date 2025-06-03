using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KodlaWebApp.ViewModels
{
    public class LessonViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lesson title is required.")]
        [StringLength(200, ErrorMessage = "Lesson title cannot exceed 200 characters.")]
        [Display(Name = "Lesson Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lesson content is required.")]
        [Display(Name = "Lesson Content")]
        public string Content { get; set; }

        [Display(Name = "Belongs to Course")]
        [Required(ErrorMessage = "Please select the course for this lesson.")]
        public int CourseId { get; set; }

        public string CourseTitle { get; set; }

        public IEnumerable<SelectListItem> AvailableCourses { get; set; }

        public ICollection<CommentViewModel> LessonComments { get; set; } = new List<CommentViewModel>();
    }
}
