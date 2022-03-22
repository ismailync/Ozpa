using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers.Admin
{
    public class AdminBrand : Controller
    {
        BrandManager cm = new BrandManager(new EfBrandRepository());
        public IActionResult ABrand()
        {
            var values = cm.GetList();
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("ABrand");
        }

        [HttpGet]
        public IActionResult BrandAdd()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult BrandAdd(Brand b)
        {
            BrandValidator bv = new BrandValidator();
            ValidationResult results = bv.Validate(b);
            if (results.IsValid)
            {
                cm.TAdd(b);
                return RedirectToAction("ABrand","AdminBrand");
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
        public IActionResult EditBrand(int id)
        {
            var values = cm.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditBrand(Brand b)
        {
            return RedirectToAction("ABrand");
        }
    }
}
