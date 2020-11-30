using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarReg.Models.Data;

namespace WebAppCarReg.Models.Services
{
    public class CarService : ICarService
    {
        ICarsRepo _carsRepo = new InMemoryCarRepo();

        public Car Add(CreateCarViewModel createCarViewModel)
        {
            return _carsRepo.Create(createCarViewModel.Brand, createCarViewModel.ModelName, createCarViewModel.Year);
        }

        public List<Car> All()
        {
            return _carsRepo.Read();
        }

        public Car Edit(int id, CreateCarViewModel car)
        {
            Car editedCar = new Car() { Id = id, Brand = car.Brand, ModelName = car.ModelName, Year = car.Year };
            return _carsRepo.Update(editedCar);
        }

        public Car FindBy(int id)
        {
            return _carsRepo.Read(id);
        }

        public bool Remove(int id)
        {
            Car car = _carsRepo.Read(id);
            if (car == null)
            {
                return false;
            }
            else
            {
                return _carsRepo.Delete(car);
            }
        }
    }
}
