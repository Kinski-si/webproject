using Microsoft.EntityFrameworkCore;
using Website.Models;

namespace Website
{
    public class Context : DbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}