using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarReg.Models;
using WebAppCarReg.Models.Services;
using WebAppCarReg.Models.ViewModels;

namespace WebAppCarReg.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly ICarService _carService;

        public SalesController(ISaleService saleService, ICarService carService)
        {
            _saleService = saleService;
            _carService = carService;
        }

        // GET: SalesController
        public ActionResult Index()
        {
            return View(_saleService.All());
        }

        // GET: SalesController/Details/5
        public ActionResult Details(int id)
        {
            Sale sale = _saleService.FindBy(id);

            if (sale == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(sale);
        }

        // GET: SalesController/Create
        public ActionResult Create()
        {
            CreateSaleViewModel createSaleViewModel = new CreateSaleViewModel();
            createSaleViewModel.CarList = _carService.All();
            return View(createSaleViewModel);
        }

        // POST: SalesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSaleViewModel createSale)
        {

            if (ModelState.IsValid)
            {
                Sale sale = _saleService.Add(createSale);

                if (sale == null)
                {
                    ModelState.AddModelError("msg", "Database problems");
                    return View(createSale);
                }

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createSale);
            }
        }

        // GET: SalesController/Edit/5
        public ActionResult Edit(int id)
        {
            Sale sale = _saleService.FindBy(id);

            if (sale == null)
            {
                return RedirectToAction("Index");
            }

            return View(new CreateSaleViewModel(sale));
        }

        // POST: SalesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateSaleViewModel editSale)
        {
            if (ModelState.IsValid)
            {
                Sale sale = _saleService.Edit(id, editSale);

                if (sale != null)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("msg", "Database problems");
            }

            return View(editSale);

        }

        // GET: SalesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
