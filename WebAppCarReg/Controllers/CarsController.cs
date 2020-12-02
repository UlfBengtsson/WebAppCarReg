using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppCarReg.Models;
using WebAppCarReg.Models.Services;
using WebAppCarReg.Models.ViewModels;

namespace WebAppCarReg.Controllers
{
    public class CarsController : Controller
    {
        private ICarService _carService = new CarService();

        [HttpGet]
        public IActionResult Index()
        {
            CarIndexViewmodel indexViewmodel = new CarIndexViewmodel();

            indexViewmodel.CarList = _carService.All();

            return View(indexViewmodel);
        }
        [HttpPost]
        public IActionResult Index(CarIndexViewmodel indexViewmodel)
        {
            if (ModelState.IsValid)
            {
                if (indexViewmodel.BeforeYear < indexViewmodel.AfterYear)
                {

                    return View(indexViewmodel);
                }
                else
                {
                    foreach (var item in _carService.All())
                    {
                        if (item.Year <= indexViewmodel.BeforeYear && item.Year >= indexViewmodel.AfterYear)
                        {
                            indexViewmodel.CarList.Add(item);
                        }
                    }

                }
            }

            return View(indexViewmodel);
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

        public IActionResult Delete(int id)
        {
            if (_carService.Remove(id))
            {
                ViewBag.msg = "Car was removed.";
            }
            else
            {
                ViewBag.msg = "Unable to remove car with id: " + id;
            }

            CarIndexViewmodel indexViewmodel = new CarIndexViewmodel();

            indexViewmodel.CarList = _carService.All();

            return View("Index", indexViewmodel);
        }

        public IActionResult AjaxFindById(int id)
        {
            Car car = _carService.FindBy(id);

            if (car == null)
            {
                return NotFound();//404
            }
            else
            {
                return PartialView("_CarPartialView", car);
            }
        }

        [HttpGet]
        public IActionResult CreateForm()
        {
            return PartialView("_CarCreateAjaxPartialView");
        }

        [HttpPost]
        public IActionResult AjaxCreateForm(CreateCarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                Car car = _carService.Add(carViewModel);

                return PartialView("_CarPartialView", car);
            }

            Response.StatusCode = 400;
            return PartialView("_CarCreateAjaxPartialView", carViewModel);
        }
    }
}
