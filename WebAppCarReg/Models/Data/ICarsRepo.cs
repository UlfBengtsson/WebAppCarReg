using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models.Data
{
    public interface ICarsRepo
    {
        Car Create(string brand, string modelName, int year);
        List<Car> Read();
        Car Read(int id);
        Car Update(Car car);
        bool Delete(Car car);
    }
}
