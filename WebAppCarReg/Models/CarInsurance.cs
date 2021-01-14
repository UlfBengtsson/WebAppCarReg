using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models
{
    public class CarInsurance //Join table
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int InsuranceId { get; set; }
        public Insurance Insurance { get; set; }
    }
}
