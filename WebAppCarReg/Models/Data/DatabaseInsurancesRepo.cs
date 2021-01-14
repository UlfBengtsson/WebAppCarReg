using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarReg.Models.Database;

namespace WebAppCarReg.Models.Data
{
    public class DatabaseInsurancesRepo : IInsuranceRepo
    {
        private readonly CarsDbContext _carsDbContext;

        public DatabaseInsurancesRepo(CarsDbContext carsDbContext)
        {
            _carsDbContext = carsDbContext;
        }

        public Insurance Create(string name, double price)
        {
            Insurance insurance = new Insurance() { Name = name, Price = price };

            _carsDbContext.Insurances.Add(insurance);

            if (_carsDbContext.SaveChanges() > 0)
            {
                return insurance;
            }

            return null;
        }

        public bool Delete(Insurance insurance)
        {
            _carsDbContext.Insurances.Remove(insurance);

            if (_carsDbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public List<Insurance> Read()
        {
            return _carsDbContext.Insurances.ToList();
        }

        public Insurance Read(int id)
        {
            return _carsDbContext.Insurances.Include(i => i.Cars).ThenInclude(i => i.Car).SingleOrDefault(i => i.Id == id);
        }

        public Insurance Update(Insurance insurance)
        {
            _carsDbContext.Insurances.Update(insurance);

            if (_carsDbContext.SaveChanges() > 0)
            {
                return insurance;
            }

            return null;
        }
    }
}