using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers.Admin
{
    public class AdminProduct : Controller
    {
        ProductManager cm = new ProductManager(new EfProductRepository());
        CategoryManager km = new CategoryManager(new EfCategoryRepository());
        BrandManager bm = new BrandManager(new EfBrandRepository());


        public IActionResult AProduct()
        {
            var values = cm.GetList();
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("AProduct");
        }

        [HttpGet]
        public IActionResult ProductAdd()
        {
            List<SelectListItem> categoryvalues = (from x in km.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();

            ViewBag.cv = categoryvalues;

            List<SelectListItem> brandvalues = (from x in bm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.BrandName,
                                                    Value = x.BrandId.ToString()
                                                }).ToList();

            ViewBag.cb = brandvalues;


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
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var values = cm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in km.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();

            ViewBag.cv = categoryvalues;

            List<SelectListItem> brandvalues = (from x in bm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.BrandName,
                                                    Value = x.BrandId.ToString()
                                                }).ToList();

            ViewBag.cb = brandvalues;
            return View(values);
        }
        [HttpPost]
        public IActionResult EditProduct(Product b)
        {
            cm.TUpdate(b);
            return RedirectToAction("AProduct");
        }
    }
}
