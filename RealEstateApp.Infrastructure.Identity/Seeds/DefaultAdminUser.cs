using RealEstateApp.Core.Application.Enums;
using RealEstateApp.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Infrastructure.Identity.Seeds
{
    public class DefaultAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultUser = new();
            defaultUser.UserName = "AdminUser";
            defaultUser.Email = "AdminUser100@gmail.com";
            defaultUser.Firstname = "John";
            defaultUser.Lastname = "Doe";
            defaultUser.PhoneNumber = "80997809";
            defaultUser.DocumementId = "9009";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;

            if (userManager.Users.All(user => user.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    
                }
            }

        }
    }
}
