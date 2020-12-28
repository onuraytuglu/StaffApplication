using Microsoft.AspNetCore.Identity;
using PersonelProject.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.ToDo.Web1
{
    public static class IdentityInitialize
    {
        public static async Task SeedData(UserManager<AppUser>
            userManager,RoleManager<AppRole> roleManager)
        {

            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole==null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }
            var personelRole = await roleManager.FindByNameAsync("Personel");
            if (personelRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Personel" });
            }

            var adminUser = await userManager.FindByNameAsync("onur");
            if (adminUser==null)
            {
                AppUser user = new AppUser
                {
                    Name = "Onur",
                    SurName = "Giray",
                    UserName = "thrall",
                    Email = "onur@gmail.com"

                };
                await userManager.CreateAsync(user,"1");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

    }
}
