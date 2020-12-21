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
        private readonly CarsDbContext _carsDbContext;

        public DatabaseCarsRepo(CarsDbContext carsDbContext)
        {
            _carsDbContext = carsDbContext;
        }

        public Car Create(string brand, string modelName, int year)
        {
            Car car = new Car(brand, modelName, year);

            _carsDbContext.CarList.Add(car);

            _carsDbContext.SaveChanges();

            return car;
        }

        public bool Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> Read()
        {
            return _carsDbContext.CarList.ToList();
        }

        public Car Read(int id)
        {
            //return _carsDbContext.CarList.SingleOrDefault(carList => carList.Id == id);//Lazy loading, no sales will be loaded
            return _carsDbContext.CarList.Include( c => c.SalesHistory).SingleOrDefault(carList => carList.Id == id);
        }

        public Car Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
