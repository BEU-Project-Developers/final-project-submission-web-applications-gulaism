﻿namespace KodlaWebApp.ViewModels
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
    }
}
