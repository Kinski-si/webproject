using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Website.DAL.Contacts.Entities;

namespace Website.DAL.Implementations
{
    public class Context : IdentityDbContext<EntityUser, IdentityRole<Guid>, Guid>
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}