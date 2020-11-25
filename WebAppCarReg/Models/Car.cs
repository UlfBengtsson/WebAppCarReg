using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string ModelName { get; set; }
        public int Year { get; set; }

        public Car() {}

        public Car(string brand, string modelName, int year)
        {
            Brand = brand;
            ModelName = modelName;
            Year = year;
        }

        public Car(int id, string brand, string modelName, int year) : this(brand,modelName,year)
        {
            Id = id;
        }
    }
}
