using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Ozpa.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers.Admin
{
    [Authorize]
    public class AdminCategory : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        private readonly IHostingEnvironment _hostingEnvironment;

        public AdminCategory(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult ACategory()
        {
            var values = cm.GetList();
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);

            var filePath = _hostingEnvironment.WebRootPath + value.CategoryImage;
            FileInfo fi = new FileInfo(filePath);
            fi.Delete();
            var filePath2 = _hostingEnvironment.WebRootPath + value.CategorySeriesImage;
            FileInfo fi2 = new FileInfo(filePath2);
            fi2.Delete();
            return RedirectToAction("ACategory");
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(AddCategoryImage b)
        {
            Category br = new Category();
            if (b.CategoryImage != null)
            {
                var extension = Path.GetExtension(b.CategoryImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/CategoryImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.CategoryImage.CopyTo(stream);
                br.CategoryImage = "/Image/CategoryImage/" + newimagename;
                stream.Close();
            }
            if (b.CategorySeriesImage != null)
            {
                var extension = Path.GetExtension(b.CategorySeriesImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/CategorySeriesImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.CategorySeriesImage.CopyTo(stream);
                br.CategorySeriesImage = "/Image/CategorySeriesImage/" + newimagename;
                stream.Close();
            }
            br.CategoryName = b.CategoryName;
            br.CategorySeries = b.CategorySeries;

            CategoryValidator bv = new CategoryValidator();
            ValidationResult results = bv.Validate(br);
            if (results.IsValid)
            {
                cm.TAdd(br);
                return RedirectToAction("ACategory", "AdminCategory");
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
        public IActionResult EditCategory(int id)
        {
            var values = cm.TGetById(id);
            ViewBag.CategorySeriesImage = values.CategorySeriesImage;
            ViewBag.CategoryImage = values.CategoryImage;
            ViewBag.PathTo = values.CategorySeriesImage;
            ViewBag.Path = values.CategoryImage;
            return View(values);
        }
        [HttpPost]
        public IActionResult EditCategory(AddCategoryImage b)
        {
            Category br = new Category();
            if (b.Path == null || b.CategoryImage != null)
            {
                var extension = Path.GetExtension(b.CategoryImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/CategoryImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.CategoryImage.CopyTo(stream);
                br.CategoryImage = "/Image/CategoryImage/" + newimagename;
                b.Path = br.CategoryImage;
                stream.Close();
            }
            if (b.PathTo == null || b.CategorySeriesImage != null)
            {
                var extension = Path.GetExtension(b.CategorySeriesImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/CategorySeriesImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.CategorySeriesImage.CopyTo(stream);
                br.CategorySeriesImage = "/Image/CategorySeriesImage/" + newimagename;
                b.PathTo = br.CategorySeriesImage;
                stream.Close();
            }
            br.CategoryId = b.CategoryId;
            br.CategoryName = b.CategoryName;
            br.CategorySeries = b.CategorySeries;
            br.CategoryImage = b.Path;
            br.CategorySeriesImage = b.PathTo;

            CategoryValidator bv = new CategoryValidator();
            ValidationResult results = bv.Validate(br);
            if (results.IsValid)
            {
                cm.TUpdate(br);
                return RedirectToAction("ACategory");
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
