using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCarReg.Models;
using WebAppCarReg.Models.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppCarReg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IInsuranceService _insuranceService;
        private readonly ISaleService _saleService;

        public ReactController(ICarService carService, IInsuranceService insuranceService, ISaleService saleService)
        {
            _carService = carService;
            _insuranceService = insuranceService;
            _saleService = saleService;
        }

        // GET: api/<ReactController>
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return _carService.All();
        }

        // GET api/<ReactController>/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            Car car = _carService.FindBy(id);

            if (car == null)
            {
                Response.StatusCode = 404;
            }

            //this will prevent the JSON converter to get stuck in a infenet loop.
            foreach (var item in car.Insurances)
            {
                item.Car = null;
                item.Insurance.Cars = null;
            }
            foreach (var item in car.SalesHistory)
            {
                item.Car = null;
            }

            return car;
        }

        // POST api/<ReactController>
        [HttpPost]
        public IActionResult Post(CreateCarViewModel createCarViewModel)
        {
            if (ModelState.IsValid)
            {
                Car car = _carService.Add(createCarViewModel);
                return Created("URI to car omitted", car);
            }

            return BadRequest(createCarViewModel);
        }

        // PUT api/<ReactController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateCarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                Car car = _carService.Edit(id, carViewModel);

                if (car == null)
                {
                    return Problem("Unable to save changes.", null, 500);
                }
                return Ok(car);
            }

            return BadRequest(carViewModel);
        }

        // DELETE api/<ReactController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_carService.Remove(id))
            {
                return Ok();
            }
            return BadRequest();

        }
    }
}
