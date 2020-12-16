using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models.ViewModels
{
    public class CreateSaleViewModel
    {
        public List<Car> CarList { get; set; }
        [Required]
        public Car Car { get; set; }
        [Required]
        public string Buyer { get; set; }
        [Required]
        public string Seller { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
