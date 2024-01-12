using Microsoft.AspNetCore.Identity;

namespace ArticleShop.Models.Database
{
    public class IdentityInitializer
    {
        public static void SeedData(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new()
                {
                    Name = "Admin",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }

        public static void SeedOneUser(UserManager<IdentityUser> userManager, string name, string password, string? role = null)
        {
            if (userManager.FindByNameAsync(name).Result == null)
            {
                IdentityUser user = new()
                {
                    UserName = name,
                    Email = name
                };
                IdentityResult result = userManager.CreateAsync(user, password).Result;
                if (result.Succeeded && role != null)
                {
                    userManager.AddToRoleAsync(user, role).Wait();
                }
            }
        }
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            SeedOneUser(userManager, "student1@pwr.edu.pl", "P@ssw0rd");
            SeedOneUser(userManager, "student2@pwr.edu.pl", "P@ssw0rd");
            SeedOneUser(userManager, "student3@pwr.edu.pl", "P@ssw0rd");
            SeedOneUser(userManager, "admin@pwr.edu.pl", "P@ssw0rd", "Admin");
        }

    }
}
