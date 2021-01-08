using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Website.Identity;

namespace Website.Contexts
{
    public class UserContext : IdentityDbContext<UserModel, IdentityRole<Guid>, Guid>
    {
        public UserContext(DbContextOptions options) : base(options)
        {
        }
    }
}