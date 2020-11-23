using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models.Services
{
    public interface ICarService
    {
        Car Add(CreateCarViewModel createCarViewModel);
        List<Car> All();
        Car FindBy(int id);
        Car Edit(int id, CreateCarViewModel car);
        bool Remove(int id);

    }
}
