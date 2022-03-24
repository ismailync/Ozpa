using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
    public class AdminSlider : Controller
    {
        BannerManager cm = new BannerManager(new EfBannerRepository());
        CategoryManager bm = new CategoryManager(new EfCategoryRepository());

        public IActionResult ASlider()
        {
            var values = cm.GetList();
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("ASlider");
        }

        [HttpGet]
        public IActionResult SliderAdd()
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
        public IActionResult SliderAdd(AddSliderImage b)
        {
            Banner br = new Banner();
            if (b.BannerImage != null)
            {
                var extension = Path.GetExtension(b.BannerImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/SliderImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.BannerImage.CopyTo(stream);
                br.BannerImage = "/Image/SliderImage/" + newimagename;
            }
            br.CategoryId = b.CategoryId;


            BannerValidator bv = new BannerValidator();
            ValidationResult results = bv.Validate(br);
            if (results.IsValid)
            {
                cm.TAdd(br);
                return RedirectToAction("ASlider", "AdminSlider");
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
        public IActionResult EditSlider(int id)
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
        public IActionResult EditSlider(AddSliderImage b)
        {
            Banner br = new Banner();
            if (b.BannerImage != null)
            {
                var extension = Path.GetExtension(b.BannerImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/SliderImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.BannerImage.CopyTo(stream);
                br.BannerImage = "/Image/SliderImage/" + newimagename;
            }
            br.BannerId = b.BannerId;
            br.CategoryId = b.CategoryId;

            BannerValidator bv = new BannerValidator();
            ValidationResult results = bv.Validate(br);
            if (results.IsValid)
            {
                cm.TUpdate(br);
                return RedirectToAction("ASlider");
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
