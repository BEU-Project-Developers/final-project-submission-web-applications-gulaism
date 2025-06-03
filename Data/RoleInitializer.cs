using Microsoft.AspNetCore.Identity;

namespace KodlaWebApp.Data
{
    public static class RoleInitializer
    {
        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService <UserManager<IdentityUser>>();
            
            
            string[] roleNames = { "Admin", "Instructor", "Student" };

            foreach(var role in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            string adminEmail = "gulaymovlamova@gmail.com";
            string adminPassword = "SuperAdmin123!";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if(adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(adminUser, adminPassword);

                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                } 
                else
                {
                    Console.WriteLine($"Error creating admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
            else
            {
                if(!await userManager.IsInRoleAsync(adminUser, "Admin"))
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
