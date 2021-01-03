using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Website.Models;

namespace Website
{
    public class Context : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}