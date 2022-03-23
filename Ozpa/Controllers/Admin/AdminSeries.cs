using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers.Admin
{
    public class AdminSeries : Controller
    {
        SeriesManager cm = new SeriesManager(new EfSeriesRepository());
        CategoryManager bm = new CategoryManager(new EfCategoryRepository());

        public IActionResult ASeries()
        {
            var values = cm.GetList();
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("ASeries");
        }
        [HttpGet]
        public IActionResult SeriesAdd()
        {
            List<SelectListItem> categoryvalues = (from x in bm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();

            ViewBag.cv = categoryvalues;
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
        [HttpGet]
        public IActionResult EditSeries(int id)
        {
            var values = cm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in bm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();

            ViewBag.cv = categoryvalues;
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSeries(Series b)
        {
            cm.TUpdate(b);
            return RedirectToAction("ASeries");
        }
    }
}
