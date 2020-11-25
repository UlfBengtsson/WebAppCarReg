using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppCarReg.Models;
using WebAppCarReg.Models.Services;

namespace WebAppCarReg.Controllers
{
    public class HomeController : Controller
    {
        ICarService _carService = new CarService();
        public IActionResult Index()
        {
            Car lastCar = null;
            List<Car> carList = _carService.All();

            if (carList.Count > 0)
            {
                lastCar = carList.Last();
            }

            return View(lastCar);
        }

    }
}
