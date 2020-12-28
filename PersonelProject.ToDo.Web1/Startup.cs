using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonelProject.ToDo.Business.Concrete;
using PersonelProject.ToDo.Business.Interfaces;
using PersonelProject.ToDo.DataAccess.Concrete.EFC.Contexts;
using PersonelProject.ToDo.DataAccess.Concrete.EFC.Repositories;
using PersonelProject.ToDo.DataAccess.InterFaces;
using PersonelProject.ToDo.Entities.Concrete;
using System;

namespace PersonelProject.ToDo.Web1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMissionService, MissionManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IUrgencyService, UrgencyManager>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IMissionBranch, EFCMissionRepository>();
            services.AddScoped<IUrgencyBranch, EFCUrgencyRepository>();
            services.AddScoped<IReportBranch, EFCReportRepository>();
            services.AddScoped<IAppUserBranch, EFCAppUserRepository>();

            services.AddDbContext<ToDoContext>();
            services.AddIdentity<AppUser, AppRole>(opt=> {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<ToDoContext>();

            services.ConfigureApplicationCookie(opt=> {

                opt.Cookie.Name = "BusinessCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(14);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";

            
            });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<AppUser> userManager
            ,RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            IdentityInitialize.SeedData(userManager, roleManager).Wait();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                    );


                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
