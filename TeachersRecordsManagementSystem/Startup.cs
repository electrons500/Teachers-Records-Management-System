using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TeachersRecordsManagementSystem.Models;
using TeachersrRecordsManagementSystem.Models.Data.TrmsContext;
using TeachersrRecordsManagementSystem.Models.Service;

namespace TeachersrRecordsManagementSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // injection for sessions
            services.AddDistributedMemoryCache();
            services.AddSession(o => {
                o.IdleTimeout = TimeSpan.FromSeconds(10);
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            
            });

            services.AddDbContext<trmsContext>(o => {
                o.UseSqlServer(Configuration.GetConnectionString("Conn"));
            });
            services.AddScoped<AdminService>();
            services.AddScoped<BankService>();
            services.AddScoped<GenderService>();
            services.AddScoped<MaritalStatusService>();
            services.AddScoped<StateService>();
            services.AddScoped<TitleService>();
            services.AddScoped<TeachersService>();
            services.AddScoped<CheckIfSessionExist>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
