using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Website.Models;

namespace Website
{
    public class Startup
    {
        public Startup()
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(config => config.UseInMemoryDatabase("MEMORY"))
                .AddIdentity<ApplicationUser, IdentityRole<Guid>>(config =>
                {
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequiredLength = 5;
                    config.Password.RequireNonAlphanumeric = false;
                }).AddEntityFrameworkStores<Context>();
            services.AddMvc();
            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/Home/Login";
            });
            services.AddAuthorization();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Login}");
            });
        }
    }
}