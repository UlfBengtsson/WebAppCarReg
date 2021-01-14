using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppCarReg.Models;
using WebAppCarReg.Models.Services;
using WebAppCarReg.Models.ViewModels;

namespace WebAppCarReg.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly IInsuranceService _insuranceService;

        public CarsController(ICarService carService, IInsuranceService insuranceService)
        {
            _carService = carService;
            _insuranceService = insuranceService;
        }

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

        public IActionResult Details(int id)
        {
            Car car = _carService.FindBy(id);

            if (car != null)
            {
                return View(car);
            }

            return RedirectToAction(nameof(Index));//Car was not found
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

        [HttpGet]
        public IActionResult ManageCarInsurances(int id)
        {
            Car car = _carService.FindBy(id);

            if (car != null)
            {
                SubscribeInsuranceViewModel subscribeInsuranceViewModel 
                    = new SubscribeInsuranceViewModel(car, _insuranceService.All());
                return View(subscribeInsuranceViewModel);
            }

            return RedirectToAction(nameof(Index));//Car was not found
        }

        [HttpGet]
        public IActionResult AddCarInsurance(int carId, int insurId)
        {
            Car car = _carService.FindBy(carId);

            if (car != null)
            {
                Insurance insurance = _insuranceService.FindBy(insurId);
                if (insurance != null)
                {
                    car.Insurances.Add(new CarInsurance() { CarId = carId, InsuranceId = insurId });
                    _carService.Edit(carId, new CreateCarViewModel(car));
                }
                return RedirectToAction(nameof(ManageCarInsurances), new { id = carId });
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult RemoveCarInsurance(int carId, int insurId)
        {
            Car car = _carService.FindBy(carId);

            if (car != null)
            {
                foreach (var item in car.Insurances)
                {
                    if (item.InsuranceId == insurId)
                    {
                        car.Insurances.Remove(item);
                        _carService.Edit(carId, new CreateCarViewModel(car));
                        break;
                    }
                }
                
                return RedirectToAction(nameof(ManageCarInsurances), new { id = carId });
            }
            return RedirectToAction(nameof(Index));
        }

        //----------------- Ajax --------------------------------------

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
