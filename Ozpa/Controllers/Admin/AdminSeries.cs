using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    [Authorize]
    public class AdminSeries : Controller
    {
        SeriesManager cm = new SeriesManager(new EfSeriesRepository());
        CategoryManager bm = new CategoryManager(new EfCategoryRepository());
        private readonly IHostingEnvironment _hostingEnvironment;

        public AdminSeries(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult ASeries()
        {
            var values = cm.GetList();
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);

            var filePath = _hostingEnvironment.WebRootPath + value.SeriesImage;
            FileInfo fi = new FileInfo(filePath);
            fi.Delete();
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
                stream.Close();
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
            List<SelectListItem> categoryvalues = (from x in bm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();

            ViewBag.cv = categoryvalues;
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
            ViewBag.SeriesImage = values.SeriesImage;
            ViewBag.Path = values.SeriesImage;
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSeries(AddSeriesImage b)
        {
            Series br = new Series();
            if (b.Path == null || b.SeriesImage != null)
            {
                var extension = Path.GetExtension(b.SeriesImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/SeriesImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.SeriesImage.CopyTo(stream);
                br.SeriesImage = "/Image/SeriesImage/" + newimagename;
                b.Path = br.SeriesImage;
                stream.Close();
            }
            br.SeriesId = b.SeriesId;
            br.SeriesName = b.SeriesName;
            br.CategoryId = b.CategoryId;
            br.SeriesImage = b.Path;

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
            List<SelectListItem> categoryvalues = (from x in bm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();

            ViewBag.cv = categoryvalues;
            return View();
            
        }
    }
}
