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
    public class AdminProduct : Controller
    {
        ProductManager cm = new ProductManager(new EfProductRepository());

        public IActionResult AProduct()
        {
            var values = cm.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult ProductAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProductAdd(Product b)
        {
            ProductValidator bv = new ProductValidator();
            ValidationResult results = bv.Validate(b);
            if (results.IsValid)
            {
                cm.TAdd(b);
                return RedirectToAction("AProduct", "AdminProduct");
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
