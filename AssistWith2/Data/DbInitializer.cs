using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistWith.Data
{
    public static class DbInitializer
    {
        public static void Initialize(
            ApplicationDbContext context)
        {
            //context.Database.EnsureCreated();

        }
        public static async void SeedData(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (userManager.FindByNameAsync("timkopp@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "timkopp@gmail.com";
                user.Email = "timkopp@gmail.com";
                IdentityResult result = userManager.CreateAsync(user, "P@ssword1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            } 
        }
    }
}
