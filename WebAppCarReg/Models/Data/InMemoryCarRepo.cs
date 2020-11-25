using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models.Data
{
    public class InMemoryCarRepo : ICarsRepo
    {
        private static List<Car> carsList = new List<Car>();
        private static int idCounter = 0;

        public Car Create(string brand, string modelName, int year)
        {
            Car car = new Car( ++idCounter, brand,  modelName,  year );
            carsList.Add(car);
            return car;
        }

        public bool Delete(Car car)
        {
            return carsList.Remove(car);
        }

        public List<Car> Read()
        {
            return carsList;
        }

        public Car Read(int id)
        {
            foreach (Car car in carsList)
            {
                if (car.Id == id)
                {
                    return car;
                }
            }

            return null;
        }

        public Car Update(Car car)
        {
            Car originalCar = Read(car.Id);
            
            if (originalCar == null)
            {
                return null;
            }

            originalCar.Brand = car.Brand;
            originalCar.ModelName = car.ModelName;
            originalCar.Year = car.Year;

            return originalCar;
        }
    }
}
