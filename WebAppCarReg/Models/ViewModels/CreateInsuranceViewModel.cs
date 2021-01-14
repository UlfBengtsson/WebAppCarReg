using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models.ViewModels
{
    public class CreateInsuranceViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }

        public CreateInsuranceViewModel() { }

        public CreateInsuranceViewModel(Insurance insurance)
        {
            Name = insurance.Name;
            Price = insurance.Price;
        }
    }
}
