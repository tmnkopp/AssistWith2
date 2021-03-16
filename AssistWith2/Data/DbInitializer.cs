using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
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
            var defaultuser = configuration.GetSection("AppSettings")["defaultuser"];
            if (userManager.FindByNameAsync(defaultuser).Result == null)
            { 
                var pass = configuration.GetSection("AppSettings")["pass"];
                IdentityUser user = new IdentityUser();
                user.UserName = defaultuser;
                user.Email = defaultuser;
                IdentityResult result = userManager.CreateAsync(user, pass).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            } 
        }
    }
}
