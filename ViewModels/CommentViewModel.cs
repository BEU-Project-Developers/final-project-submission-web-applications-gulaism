using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KodlaWebApp.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Comment text is required.")]
        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
        [Display(Name = "Your Comment")]
        public string Text { get; set; }

        [Display(Name = "Posted On")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
        public int LessonId { get; set; }

        [Display(Name = "Posted by")]
        public string UserEmail { get; set; }

        [Display(Name = "On Lesson")]
        public string LessonTitle { get; set; }

        //public UserViewModel User { get; set; }

        //[ForeignKey("LessonId")]
        //public LessonViewModel Lesson { get; set; }

    }
}
