using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarReg.Models.Identity;

namespace WebAppCarReg.Models.Database
{
    public class SeedDatabase
    {
        public static IHost CreateDatabaseIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<IdentityCarDbContext>();
                    context.Database.Migrate();//Ensure the database is created and has the lates migration added to it.

                    if ( ! context.Roles.Any())// are there any roles? if not, its a new database
                    {
                        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                        roleManager.CreateAsync(new IdentityRole("Admin")).Wait();

                        roleManager.CreateAsync(new IdentityRole("Member")).Wait();

                        var userManager = services.GetRequiredService<UserManager<AppUser>>();

                        AppUser superAdmin = new AppUser() { UserName = "SuperAdmin" };

                        userManager.CreateAsync(superAdmin, "Qwerty!23456").Wait();

                        superAdmin = userManager.FindByNameAsync("SuperAdmin").Result;

                        userManager.AddToRoleAsync(superAdmin, "Admin").Wait();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return host;
            }
        }
    }
}
