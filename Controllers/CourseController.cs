using KodlaWebApp.Data;
using KodlaWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace KodlaWebApp.Controllers
{
    [Authorize(Roles = "Instructor,Admin")]
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var course = await _context.Courses.Include(c => c.Category).ToListAsync();
            return View(course);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Category)
                .Include(c => c.Lessons)
                .FirstOrDefaultAsync(m => m.Id == id);

            if(course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title, Description, CategoryId")] Course course)
        {
            // b1
            // point
            if(ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Course created successfully!";
                return RedirectToAction(nameof(Index));
            }

            Debug.WriteLine("ModelState is NOT valid. Errors found.");
            foreach(var modelStateEntry in ModelState.Values)
            {
                foreach(var error in modelStateEntry.Errors)
                {
                    Debug.WriteLine($"- Error: {error.ErrorMessage}");
                }
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(course);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if(course == null)
            {
                return NotFound();
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(course);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Title, Description, CategoryId")] Course course)
        {
            if(id != course.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Course updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!_context.Courses.Any(e => e.Id == course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(course);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(C => C.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if(course == null)
            {
                return NotFound();
            }

            return View(course);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if(course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Course deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
