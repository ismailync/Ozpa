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
    public class AdminBrand : Controller
    {
        BrandManager cm = new BrandManager(new EfBrandRepository());
        private readonly IHostingEnvironment _hostingEnvironment;

        public AdminBrand(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult ABrand()
        {
            var values = cm.GetList();
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);

            var filePath = _hostingEnvironment.WebRootPath + value.BrandImage;
            FileInfo fi = new FileInfo(filePath);
            fi.Delete();
            return RedirectToAction("ABrand");
        }

        [HttpGet]
        public IActionResult BrandAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BrandAdd(AddBrandImage b)
        {
            Brand br = new Brand();
            if (b.BrandImage != null)
            {
                var extension = Path.GetExtension(b.BrandImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/BrandImage/" , newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.BrandImage.CopyTo(stream);
                br.BrandImage = "/Image/BrandImage/" +newimagename;
                stream.Close();
            }
            br.BrandName = b.BrandName;
           
            BrandValidator bv = new BrandValidator();
            ValidationResult results = bv.Validate(br);
            if (results.IsValid)
            {            
                cm.TAdd(br);
                return RedirectToAction("ABrand", "AdminBrand");
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
            ViewBag.BrandImage = values.BrandImage;
            ViewBag.Path = values.BrandImage;
            return View(values);
        }
        [HttpPost]
        public IActionResult EditBrand(AddBrandImage b)
        {
            Brand br = new Brand();
            if (b.Path == null || b.BrandImage != null)
            {
                var extension = Path.GetExtension(b.BrandImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/BrandImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.BrandImage.CopyTo(stream);
                br.BrandImage = "/Image/BrandImage/" + newimagename;
                b.Path = br.BrandImage;
                stream.Close();
            }
            br.BrandId = b.BrandId;
            br.BrandName = b.BrandName;
            br.BrandImage = b.Path;

            BrandValidator bv = new BrandValidator();
            ValidationResult results = bv.Validate(br);
            if (results.IsValid)
            {
                cm.TUpdate(br);
                return RedirectToAction("ABrand");
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
