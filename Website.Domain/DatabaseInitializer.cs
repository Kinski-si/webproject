using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Website.DAL.Contacts.Entities;
using Website.DAL.Implementations;

namespace Website.Domain.Implementations
{
    public static class DatabaseInitializer
    {
        public static async Task Initialize(RoleManager<IdentityRole<Guid>> aRoleManager,
            UserManager<EntityUser> aUserManager)
        {
            const string ADMIN_EMAIL = "admin@gmail.com";
            const string PASSWORD = "qwerty1234";

            if (await aRoleManager.FindByNameAsync(Roles.ADMIN) == null)
            {
                await aRoleManager.CreateAsync(new IdentityRole<Guid>(Roles.ADMIN));
            }

            if (await aRoleManager.FindByNameAsync(Roles.MANAGER) == null)
            {
                await aRoleManager.CreateAsync(new IdentityRole<Guid>(Roles.MANAGER));
            }

            if (await aUserManager.FindByNameAsync(ADMIN_EMAIL) == null)
            {
                var admin = new EntityUser {Email = ADMIN_EMAIL, UserName = ADMIN_EMAIL};
                var result = await aUserManager.CreateAsync(admin, PASSWORD);
                if (result.Succeeded)
                {
                    await aUserManager.AddToRoleAsync(admin, Roles.ADMIN);
                }
            }
        }
    }
}