using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebAppCarReg.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAppCarReg.Models.Database
{
    public class IdentityCarDbContext : IdentityDbContext<AppUser>
    {
        public IdentityCarDbContext(DbContextOptions<IdentityCarDbContext> options) : base(options) { }

        //DbSet
        public DbSet<Car> CarList { get; set; }//will be tabels in database
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<CarInsurance> CarInsurances { get; set; }//join table

        protected override void OnModelCreating(ModelBuilder modelBuilder)//tells EF how to work with the many-to-many
        {

            base.OnModelCreating(modelBuilder);//Don´t forget this one! otherwise you will get a IdentityUser has no Key error.

            modelBuilder.Entity<CarInsurance>()
            .HasKey(ci => new { ci.CarId, ci.InsuranceId });

            modelBuilder.Entity<CarInsurance>()
                .HasOne(ci => ci.Car)
                .WithMany(c => c.Insurances)
                .HasForeignKey(ci => ci.CarId);

            modelBuilder.Entity<CarInsurance>()
                .HasOne(ci => ci.Insurance)
                .WithMany(i => i.Cars)
                .HasForeignKey(ci => ci.InsuranceId);
        }
    }
}
