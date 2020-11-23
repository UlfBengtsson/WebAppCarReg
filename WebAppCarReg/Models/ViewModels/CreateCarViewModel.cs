using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models
{
    public class CreateCarViewModel
    {
        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Model")]
        [StringLength(80, MinimumLength = 1)]
        public string ModelName { get; set; }

        [Display(Name = "Production Year")]
        [Range(1500, 2025)]
        public int Year { get; set; }
    }
}
