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
using Microsoft.EntityFrameworkCore;

namespace Website
{
    public class Startup
    {
        public const string COOKIE = "Cookies";

        public Startup()
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAuthentication(COOKIE).AddCookie(COOKIE, b =>
            {
                b.AccessDeniedPath = "/Home/Denied";
                b.LoginPath = "/Home/Login";
            });
            services.AddAuthorization(b => b.AddPolicy("Artem",
                c => c.RequireAssertion(a => a.User.HasClaim(ClaimTypes.Name, "Rin"))));
            services.AddDbContext<Context>(config => config.UseInMemoryDatabase("MEMORY"));
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