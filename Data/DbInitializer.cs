using System.ComponentModel;
using KodlaWebApp.Models;

namespace KodlaWebApp.Data
{
    public static class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if(!context.Categories.Any())
            {
                context.Categories.Add(new Category { Name = "Programming", Description = "This is a category for Programming." });
                context.SaveChanges();
            }
        }
    }
}
