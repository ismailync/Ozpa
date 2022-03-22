using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers.Admin
{
    public class AdminSeries : Controller
    {
        SeriesManager cm = new SeriesManager(new EfSeriesRepository());

        public IActionResult ASeries()
        {
            var values = cm.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult SeriesAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SeriesAdd(Series b)
        {
            SeriesValidator bv = new SeriesValidator();
            ValidationResult results = bv.Validate(b);
            if (results.IsValid)
            {
                cm.TAdd(b);
                return RedirectToAction("ASeries", "AdminSeries");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
