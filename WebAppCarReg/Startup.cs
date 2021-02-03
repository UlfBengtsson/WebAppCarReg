using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAppCarReg.Models.Data;
using WebAppCarReg.Models.Database;
using WebAppCarReg.Models.Identity;
using WebAppCarReg.Models.Services;

namespace WebAppCarReg
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
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityCarDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<IdentityCarDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddScoped<ICarsRepo, InMemoryCarRepo>();//Container setting for my IoC
            services.AddScoped<ICarsRepo, DatabaseCarsRepo>();//Container setting for my IoC
            services.AddScoped<ICarService, CarService>();//Container setting for my IoC
            
            services.AddScoped<ISaleRepo, DatabaseSaleRepo>();
            services.AddScoped<ISaleService, SaleService>();
            
            services.AddScoped<IInsuranceRepo, DatabaseInsurancesRepo>();
            services.AddScoped<IInsuranceService, InsuranceService>();

            services.AddMvc();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddCors(options =>
           {
               options.AddPolicy(name: "MyAllowSpecificOrigins",
                              builder =>
                              {
                                  builder.WithOrigins("http://localhost:3000")//defualt uri for React (npm start)
                                                        .AllowAnyMethod()
                                                        .AllowAnyHeader();
                              });
           });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("MyAllowSpecificOrigins");

            app.UseAuthentication();//User login?
            app.UseAuthorization();//User has role?

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
