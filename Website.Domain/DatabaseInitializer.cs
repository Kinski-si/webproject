using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Website.DAL.Contacts.Entities;

namespace Website.Domain.Implementations
{
    public static class DatabaseInitializer
    {
        public static async Task Initialize(RoleManager<IdentityRole<Guid>> aRoleManager,
            UserManager<EntityUser> aUserManager)
        {
            const string ADMIN_EMAIL = "admin@gmail.com";
            const string PASSWORD = "qwerty1234";

            if (await aRoleManager.FindByNameAsync("Admin") == null)
            {
                await aRoleManager.CreateAsync(new IdentityRole<Guid>("Admin"));
            }

            if (await aUserManager.FindByNameAsync(ADMIN_EMAIL) == null)
            {
                var admin = new EntityUser {Email = ADMIN_EMAIL, UserName = ADMIN_EMAIL};
                var result = await aUserManager.CreateAsync(admin, PASSWORD);
                if (result.Succeeded) await aUserManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}