using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Website.DAL.Contacts.Entities;

namespace Website.DAL.Implementations
{
    public class Context : IdentityDbContext<EntityUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<EntityCategory> Categories { get; set; }
        public DbSet<EntityProduct> Clothes { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}