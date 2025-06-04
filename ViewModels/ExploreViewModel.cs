namespace KodlaWebApp.ViewModels
{
    public class ExploreViewModel
    {
        public IEnumerable<KodlaWebApp.ViewModels.CourseDto> Courses { get; set; }

        // This property now holds DTOs
        public IEnumerable<KodlaWebApp.ViewModels.CategoryDto> Categories { get; set; } // <--- CHANGED THIS LINE
    }
}
