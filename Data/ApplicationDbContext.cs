using KodlaWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KodlaWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
