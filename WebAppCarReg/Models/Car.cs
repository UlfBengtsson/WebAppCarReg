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
        int year;
        public int Year 
        {
            get
            {
                return year;
            }
            set
            {
                if (value >= 1886)
                {
                    year = value;
                }
                else
                {
                    throw new Exception("Worlds first car was made 1886.");
                }
            } 
        }

        public List<Sale> SalesHistory { get; set; }//Many

        public Car() {}

        public Car(string brand, string modelName, int year)
        {
            Brand = brand;
            ModelName = modelName;
            Year = year;
            //this.year = year;//bad way, this dose not check the year and dosent throw the exception.
        }

        public Car(int id, string brand, string modelName, int year) : this(brand,modelName,year)
        {
            Id = id;
        }
    }
}
