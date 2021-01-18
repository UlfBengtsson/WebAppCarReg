using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarReg.Models.Database;

namespace WebAppCarReg.Models.Data
{
    public class DatabaseSaleRepo : ISaleRepo
    {
        private readonly IdentityCarDbContext _carsDbContext;

        public DatabaseSaleRepo(IdentityCarDbContext carsDbContext)
        {
            _carsDbContext = carsDbContext;
        }

        public Sale Create(string buyer, string seller, Car car, DateTime transactionDate)
        {
            Sale sale = new Sale() { Car = car, Buyer = buyer, Seller = seller, TransactionDate = transactionDate };

            _carsDbContext.Sales.Add(sale);

            if (_carsDbContext.SaveChanges() > 0)// don´t forget to save
            {
                return sale;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(Sale sale)
        {
            //_carsDbContext.Remove(sale);
            _carsDbContext.Sales.Remove(sale);

            if (_carsDbContext.SaveChanges() > 0)// don´t forget to save
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Sale> Read()
        {
            //return _carsDbContext.Sales.ToList();//Lazy loading (only sales no car)
            return _carsDbContext.Sales.Include( s => s.Car).ToList();//Eager loading (sales and cars)
        }

        public Sale Read(int id)
        {
            //return _carsDbContext.Sales.Find(id);
            return _carsDbContext.Sales.Include(s => s.Car).SingleOrDefault( s => s.Id == id);
        }

        public Sale Update(Sale sale)
        {
            _carsDbContext.Sales.Update(sale);

            if (_carsDbContext.SaveChanges() > 0)// don´t forget to save
            {
                return sale;
            }
            else
            {
                return null;
            }
        }
    }
}
