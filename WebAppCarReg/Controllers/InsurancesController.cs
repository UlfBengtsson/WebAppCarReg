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
    public class InsurancesController : Controller
    {
        private readonly IInsuranceService _insuranceService;

        public InsurancesController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        // GET: InsurancesController
        public ActionResult Index()
        {
            return View(_insuranceService.All());
        }

        // GET: InsurancesController/Details/1
        public ActionResult Details(int id)
        {
            Insurance insurance = _insuranceService.FindBy(id);

            if (insurance == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(insurance);
        }

        // GET: InsurancesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsurancesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateInsuranceViewModel createInsurance)
        {
            if (ModelState.IsValid)
            {
                Insurance insurance = _insuranceService.Add(createInsurance);
                if (insurance != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("System", "Create failed.");
            }

            return View(createInsurance);
        }

        // GET: InsurancesController/Edit/2
        public ActionResult Edit(int id)
        {
            Insurance insurance = _insuranceService.FindBy(id);

            if (insurance == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.id = id;
            return View(new CreateInsuranceViewModel(insurance));
        }

        // POST: InsurancesController/Edit/2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateInsuranceViewModel createInsuranceViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_insuranceService.Edit(id, createInsuranceViewModel) != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("System", "Failed to edit");
            }

            ViewBag.id = id;
            return View(createInsuranceViewModel);

        }

        // GET: InsurancesController/Delete/3
        public ActionResult Delete(int id)
        {
            Insurance insurance = _insuranceService.FindBy(id);

            if (insurance == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(insurance);
        }

        // POST: InsurancesController/Delete/3
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, int deleteId)
        {
            if (id == deleteId)
            {
                if (_insuranceService.Remove(id))
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("System", "Failed to delete");
            }

            Insurance insurance = _insuranceService.FindBy(id);

            return View(insurance);
        }

    }
}
