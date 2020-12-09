using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppCarReg.Models;

namespace WebAppCarReg.Controllers
{
    public class PlainAjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult SimpelText()
        {
            return Ok("plain text");// code 200
        }

        public IActionResult CantFindIt()
        {
            return NotFound("this action always restuns 404");// code 404
        }
        
        public IActionResult GiveMeJSON()
        {
            Car car = new Car("Saab", "900", 1989);
            return Json(car);
        }
    }
}
