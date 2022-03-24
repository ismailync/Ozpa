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
    public class AdminNews : Controller
    {
        NewsManager cm = new NewsManager(new EfNewsRepository());

        public IActionResult ANews()
        {
            var values = cm.GetList();
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("ANews");
        }
        [HttpGet]
        public IActionResult NewsAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewsAdd(AddNewsImage b)
        {
            News br = new News();
            if (b.NewsImage != null)
            {
                var extension = Path.GetExtension(b.NewsImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/NewsImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.NewsImage.CopyTo(stream);
                br.NewsImage = "/Image/NewsImage/" + newimagename;
            }
            br.NewsTitle = b.NewsTitle;
            br.NewsComment = b.NewsComment;

            NewsValidator bv = new NewsValidator();
            ValidationResult results = bv.Validate(br);
            if (results.IsValid)
            {
                cm.TAdd(br);
                return RedirectToAction("ANews", "AdminNews");
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
        public IActionResult EditNews(int id)
        {
            var values = cm.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditNews(AddNewsImage b)
        {
            News br = new News();
            if (b.NewsImage != null)
            {
                var extension = Path.GetExtension(b.NewsImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/NewsImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.NewsImage.CopyTo(stream);
                br.NewsImage = "/Image/NewsImage/" + newimagename;
            }
            br.NewsId = b.NewsId;
            br.NewsTitle = b.NewsTitle;
            br.NewsComment = b.NewsComment;

            NewsValidator bv = new NewsValidator();
            ValidationResult results = bv.Validate(br);
            if (results.IsValid)
            {
                cm.TUpdate(br);
                return RedirectToAction("ANews");
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
