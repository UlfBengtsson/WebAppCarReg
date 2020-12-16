using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarReg.Models.ViewModels;

namespace WebAppCarReg.Models.Services
{
    public interface ISaleService
    {
        Sale Add(CreateSaleViewModel createSaleViewModel);
        List<Sale> All();
        Sale FindBy(int id);
        Sale Edit(int id, CreateSaleViewModel sale);
        bool Remove(int id);
    }
}
