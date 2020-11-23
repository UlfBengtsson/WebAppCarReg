using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppCarReg.Models;
using WebAppCarReg.Models.Services;

namespace WebAppCarReg.Controllers
{
    public class CarsController : Controller
    {
        private ICarService _carService = new CarService();

        public IActionResult Index()
        {
            return View(_carService.All());
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                _carService.Add(carViewModel);

                return RedirectToAction(nameof(Index));
            }

            return View(carViewModel);
        }

    }
}
