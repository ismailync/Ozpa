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
    public class AdminSlider : Controller
    {
        BannerManager cm = new BannerManager(new EfBannerRepository());

        public IActionResult ASlider()
        {
            var values = cm.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult SliderAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SliderAdd(Banner b)
        {
            BannerValidator bv = new BannerValidator();
            ValidationResult results = bv.Validate(b);
            if (results.IsValid)
            {
                cm.TAdd(b);
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
    }
}
