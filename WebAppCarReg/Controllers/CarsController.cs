using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppCarReg.Models;

namespace WebAppCarReg.Controllers
{
    public class CarsController : Controller
    {
        private static List<Car> carsList = new List<Car>();
        private static int idCounter = 0;

        public IActionResult Index()
        {
            return View(carsList);
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
                carsList.Add(new Car() { Id = ++idCounter, Brand = carViewModel.Brand, ModelName = carViewModel.ModelName, Year = carViewModel.Year });

                return RedirectToAction(nameof(Index));
            }

            return View(carViewModel);
        }
    }
}
