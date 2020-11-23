using System.Collections.Generic;

namespace WebAppCarReg.Models
{
    public class CarsViewModel
    {
        public string Search { get; set; }
        public CreateCarViewModel CreateCar { get; set; }
        public List<Car> CarList { get; set; }
    }
}