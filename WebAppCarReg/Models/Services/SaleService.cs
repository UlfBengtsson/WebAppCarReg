using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarReg.Models.Data;
using WebAppCarReg.Models.ViewModels;

namespace WebAppCarReg.Models.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepo _saleRepo;
        private readonly ICarService _carService;

        public SaleService(ISaleRepo saleRepo, ICarService carService)
        {
            _saleRepo = saleRepo;
            _carService = carService;
        }

        public Sale Add(CreateSaleViewModel createSaleViewModel)
        {
            createSaleViewModel.Car = _carService.FindBy(createSaleViewModel.Car.Id);
            if (createSaleViewModel.Car == null)
            {
                return null;
            }

            Sale sale = _saleRepo.Create(createSaleViewModel.Buyer, createSaleViewModel.Seller, createSaleViewModel.Car, createSaleViewModel.TransactionDate);
            
            return sale;
        }

        public List<Sale> All()
        {
            return _saleRepo.Read();
        }

        public Sale Edit(int id, CreateSaleViewModel sale)
        {
            Sale editidSale = new Sale() { Id = id, Buyer = sale.Buyer, Seller = sale.Seller, Car = sale.Car, TransactionDate = sale.TransactionDate };

            return _saleRepo.Update(editidSale);
        }

        public Sale FindBy(int id)
        {
            return _saleRepo.Read(id);
        }

        public bool Remove(int id)
        {
            return _saleRepo.Delete(FindBy(id));
        }
    }
}
