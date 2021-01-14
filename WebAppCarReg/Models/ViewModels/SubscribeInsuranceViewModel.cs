using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models.ViewModels
{
    public class SubscribeInsuranceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }

        public List<CarInsurance> CurrentInsurances { get; set; }
        public List<Insurance> SelectebleInsurances { get; set; }

        public SubscribeInsuranceViewModel() { }

        public SubscribeInsuranceViewModel(Car car)
        {
            Id = car.Id;
            Brand = car.Brand;
            Name = car.ModelName;
            CurrentInsurances = car.Insurances;
        }

        public SubscribeInsuranceViewModel(Car car, List<Insurance> insuranceList) : this(car)
        {
            foreach (var item in car.Insurances)
            {
                insuranceList.Remove(item.Insurance);
            }
            SelectebleInsurances = insuranceList;
        }
    }
}
