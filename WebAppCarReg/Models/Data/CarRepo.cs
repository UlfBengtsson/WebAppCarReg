using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models.Data
{
    public class CarRepo : IGenericRepo<Car, CreateCarViewModel>
    {
        public Car Create(CreateCarViewModel create)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Car model)
        {
            throw new NotImplementedException();
        }

        public Car Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<Car> Read()
        {
            throw new NotImplementedException();
        }

        public Car Update(Car model)
        {
            throw new NotImplementedException();
        }
    }
}
