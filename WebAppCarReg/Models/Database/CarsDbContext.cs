using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models.Database
{
    public class CarsDbContext : DbContext
    {
        //ctor
        public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
        { }

        //DbSet
        public DbSet<Car> CarList { get; set; }//will be tabels in database
    }
}
