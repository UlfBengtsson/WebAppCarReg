using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarReg.Models.Database;

namespace WebAppCarReg.Models.Data
{
    public class DatabaseCarsRepo : ICarsRepo
    {
        private readonly IdentityCarDbContext _carsDbContext;

        public DatabaseCarsRepo(IdentityCarDbContext carsDbContext)
        {
            _carsDbContext = carsDbContext;
        }

        public Car Create(string brand, string modelName, int year)
        {
            Car car = new Car(brand, modelName, year);

            _carsDbContext.CarList.Add(car);

            if (_carsDbContext.SaveChanges() > 0)
            {
                return car;
            }

            return null;
        }

        public bool Delete(Car car)
        {
            _carsDbContext.CarList.Remove(car);

            if (_carsDbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public List<Car> Read()
        {
            return _carsDbContext.CarList.ToList();
        }

        public Car Read(int id)
        {
            //return _carsDbContext.CarList.SingleOrDefault(carList => carList.Id == id);//Lazy loading, no sales will be loaded
            return _carsDbContext.CarList.Include( c => c.SalesHistory).Include( c => c.Insurances ).ThenInclude( c => c.Insurance ).SingleOrDefault(carList => carList.Id == id);
        }

        public Car Update(Car car)
        {
            _carsDbContext.CarList.Update(car);

            if (_carsDbContext.SaveChanges() > 0)
            {
                return car;
            }

            return null;
        }
    }
}
