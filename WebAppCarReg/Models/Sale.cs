using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Car Car { get; set; }

        public string Buyer { get; set; }

        public string Seller { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
