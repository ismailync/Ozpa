﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ozpa.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public IActionResult SeriesAdd(AddSeriesImage b)
        {
            Series br = new Series();
            if (b.SeriesImage != null)
            {
                var extension = Path.GetExtension(b.SeriesImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/SeriesImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.SeriesImage.CopyTo(stream);
                br.SeriesImage = "/Image/SeriesImage/" + newimagename;
            }
            br.SeriesName = b.SeriesName;
            br.CategoryId = b.CategoryId;

            SeriesValidator bv = new SeriesValidator();
            ValidationResult results = bv.Validate(br);
            if (results.IsValid)
            {
                cm.TAdd(br);
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
        public IActionResult EditSeries(AddSeriesImage b)
        {
            Series br = new Series();
            if (b.SeriesImage != null)
            {
                var extension = Path.GetExtension(b.SeriesImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/SeriesImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.SeriesImage.CopyTo(stream);
                br.SeriesImage = "/Image/SeriesImage/" + newimagename;
            }
            br.SeriesId = b.SeriesId;
            br.SeriesName = b.SeriesName;
            br.CategoryId = b.CategoryId;

            SeriesValidator bv = new SeriesValidator();
            ValidationResult results = bv.Validate(br);
            if (results.IsValid)
            {
                cm.TUpdate(br);
                return RedirectToAction("ASeries");
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
