using IdentityProject.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProject.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Customer.ToString()));
        }
        public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
        {
            var superAdmin = new ApplicationUser()
            {
                Email = "superadmin@superadmin.com",
                UserName = "superadmin",
                FullName = "Super Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != superAdmin.Id))
            {
                var user = await userManager.FindByEmailAsync(superAdmin.Email);
                if(user == null)
                {
                    await userManager.CreateAsync(superAdmin, "123Pa$$word.");
                    await userManager.AddToRoleAsync(superAdmin, Enums.Roles.Customer.ToString());
                    await userManager.AddToRoleAsync(superAdmin, Enums.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(superAdmin, Enums.Roles.SuperAdmin.ToString());
                }
            }
            var customer = new ApplicationUser()
            {
                Email = "customer@customer.com",
                UserName = "customer",
                FullName = "Customer Customer",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != customer.Id))
            {
                var user = await userManager.FindByEmailAsync(customer.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(customer, "123Pa$$word.");
                    await userManager.AddToRoleAsync(customer, Enums.Roles.Customer.ToString());
                }
            }
            var admin = new ApplicationUser()
            {
                Email = "admin@admin.com",
                UserName = "admin",
                FullName = "Admin Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != admin.Id))
            {
                var user = await userManager.FindByEmailAsync(admin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(admin, "123Pa$$word.");
                    await userManager.AddToRoleAsync(admin, Enums.Roles.Admin.ToString());
                }
            }
        }
    }
}
