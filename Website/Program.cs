using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Website.DAL.Contacts;
using Website.DAL.Contacts.Entities;
using Website.Domain.Implementations;

namespace Website
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                await DatabaseInitializer.Initialize(
                    scope.ServiceProvider.GetService<RoleManager<IdentityRole<Guid>>>(),
                    scope.ServiceProvider.GetService<UserManager<EntityUser>>());
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}