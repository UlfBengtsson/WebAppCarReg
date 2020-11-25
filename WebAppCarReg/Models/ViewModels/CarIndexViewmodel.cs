using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models.ViewModels
{
    public class CarIndexViewmodel
    {
        [Required]
        [Range(1886, 3000, ErrorMessage = "First car in the world was made in the year 1886.")]
        public int BeforeYear { get; set; }

        [Required]
        [Range(1886, 3000, ErrorMessage = "First car in the world was made in the year 1886.")]
        public int AfterYear { get; set; }

        public List<Car> CarList { get; set; }

        public CarIndexViewmodel()
        {
            CarList = new List<Car>();
            AfterYear = 1886;
            BeforeYear = DateTime.Now.Year;
        }
    }
}
