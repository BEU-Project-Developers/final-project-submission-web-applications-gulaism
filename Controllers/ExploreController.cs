using KodlaWebApp.Data; // Add this for ApplicationDbContext
using KodlaWebApp.Models; // Add this for Course and Category models
using KodlaWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // For .Include() and .ToListAsync()
using System.Linq; // For .Any()
using System.Threading.Tasks; // For async/await

namespace KodlaWebApp.Controllers
{
    public class ExploreController : Controller
    {
        private readonly ApplicationDbContext _context; 

        public ExploreController(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Fetch all courses, including their associated category
            //var courses = await _context.Courses.Include(c => c.Category).ToListAsync();

            var courses = await _context.Courses
                .Include(c => c.Category) // Still include Category to get its data
                .Select(c => new CourseDto // Project to CourseDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    CategoryId = c.CategoryId,
                    Category = c.Category != null ? new CategoryDto // Project Category to CategoryDto
                    {
                        Id = c.Category.Id,
                        Name = c.Category.Name,
                        Description = c.Category.Description
                    } : null
                })
                .ToListAsync();

            //var categories = await _context.Categories.ToListAsync();

            var categories = await _context.Categories
                .Select(cat => new CategoryDto // Project to CategoryDto
                {
                    Id = cat.Id,
                    Name = cat.Name,
                    Description = cat.Description
                })
                .ToListAsync();

            //var viewModel = new ExploreViewModel
            //{
            //    Courses = courses,
            //    Categories = categories
            //};

            var viewModel = new ExploreViewModel
            {
                Courses = courses, // Now it's IEnumerable<CourseDto>
                Categories = categories // Now it's IEnumerable<CategoryDto>
            };

            return View(viewModel); // Pass the list of courses to the view
        }
    }
}