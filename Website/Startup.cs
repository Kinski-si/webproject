using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Website.Contexts;
using Website.Identity;

namespace Website
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddDbContext<UserContext>(config =>
                    config.UseInMemoryDatabase("MEMORY"))
                .AddIdentity<UserModel, IdentityRole<Guid>>(config =>
                {
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequiredLength = 5;
                    config.Password.RequireNonAlphanumeric = false;
                }).AddEntityFrameworkStores<UserContext>();
            services.AddMvc();
            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/Areas/Welcome/Controllers/Home/Login";
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
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{area=Welcome}/{controller=Home}/{action=Login}");
            });
        }
    }
}