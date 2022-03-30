using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Grpc.Core;
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
    public class AdminSlider : Controller
    {
        BannerManager cm = new BannerManager(new EfBannerRepository());
        CategoryManager bm = new CategoryManager(new EfCategoryRepository()); 
        private readonly IHostingEnvironment _hostingEnvironment;

        public AdminSlider(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult ASlider()
        {
            var values = cm.GetList();
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);

            var filePath = _hostingEnvironment.WebRootPath + value.BannerImage;
            FileInfo fi = new FileInfo(filePath);
            fi.Delete();
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
                stream.Close();
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
            ViewBag.BannerImage = values.BannerImage;
            ViewBag.Path = values.BannerImage;
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSlider(AddSliderImage b)
        {
            Banner br = new Banner();
            if (b.Path == null || b.BannerImage != null)
            {
                var extension = Path.GetExtension(b.BannerImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/SliderImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.BannerImage.CopyTo(stream);
                br.BannerImage = "/Image/SliderImage/" + newimagename;
                b.Path = br.BannerImage;
                stream.Close();
            }
            br.BannerId = b.BannerId;
            br.CategoryId = b.CategoryId;
            br.BannerImage = b.Path;
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
