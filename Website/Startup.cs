using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Website.DAL.Contacts;
using Website.DAL.Contacts.Entities;
using Website.DAL.Implementations;
using Website.Domain.Contracts;
using Website.Domain.Contracts.Models;
using Website.Domain.Implementations;

namespace Website
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddDbContext<Context>(config =>
                    config.UseInMemoryDatabase("MEMORY"))
                .AddIdentity<EntityUser, IdentityRole<Guid>>(config =>
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
                option.LoginPath = "/Shop/Login/LoginView";
                option.AccessDeniedPath = "/Authorization/Home/Denied";
            });
            services.AddSingleton(
                new AutoMapper.MapperConfiguration(configuration =>
                    configuration.AddProfile(new AutoMapperConfiguration())).CreateMapper());
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IDbRepository, DbRepository>();
            services.AddAuthorization();
            services.AddScoped<AuthorizeForm>();
            services.AddMemoryCache();
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
                endpoints.MapControllerRoute("default", "{area=Shop}/{controller=Identity}/{action=Identity}");
            });
        }
    }
}