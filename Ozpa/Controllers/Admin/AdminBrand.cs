using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Ozpa.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            return View(values);
        }
        [HttpPost]
        public IActionResult EditBrand(AddBrandImage b)
        {
            Brand br = new Brand();
            if (b.BrandImage != null)
            {
                var extension = Path.GetExtension(b.BrandImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/BrandImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.BrandImage.CopyTo(stream);
                br.BrandImage = "/Image/BrandImage/" + newimagename;
            }
            br.BrandId = b.BrandId;
            br.BrandName = b.BrandName;

            cm.TUpdate(br);
            return RedirectToAction("ABrand");
        }
    }
}
