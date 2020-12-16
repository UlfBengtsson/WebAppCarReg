using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCarReg.Models.Data
{
    public interface ISaleRepo
    {
        Sale Create(string buyer, string seller, Car car, DateTime transactionDate);
        List<Sale> Read();
        Sale Read(int id);
        Sale Update(Sale car);
        bool Delete(Sale car);
    }
}
