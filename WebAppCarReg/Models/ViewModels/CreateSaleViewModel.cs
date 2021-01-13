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

        public CreateSaleViewModel() {}

        public CreateSaleViewModel(Sale sale)
        {
            Car = sale.Car;
            Buyer = sale.Buyer;
            Seller = sale.Seller;
            TransactionDate = sale.TransactionDate;
        }

        public CreateSaleViewModel(Sale sale, List<Car> carList) : this(sale)
        {
            CarList = carList;
        }
    }
}
