using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
    public class AdminProduct : Controller
    {
        ProductManager cm = new ProductManager(new EfProductRepository());
        CategoryManager km = new CategoryManager(new EfCategoryRepository());
        BrandManager bm = new BrandManager(new EfBrandRepository());
        private readonly IHostingEnvironment _hostingEnvironment;

        public AdminProduct(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult AProduct()
        {
            var values = cm.GetList();
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            var filePath = _hostingEnvironment.WebRootPath + value.ProductImage;
            FileInfo fi = new FileInfo(filePath);
            fi.Delete();
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
        public IActionResult ProductAdd(AddProductImage b)
        {
            Product br = new Product();
            if (b.ProductImage != null)
            {
                var extension = Path.GetExtension(b.ProductImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/ProductImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.ProductImage.CopyTo(stream);
                br.ProductImage = "/Image/ProductImage/" + newimagename;
                stream.Close();
            }
            br.BrandId = b.BrandId;
            br.CategoryId = b.CategoryId;
            br.ProductComment = b.ProductComment;
            br.ProductName = b.ProductName;
            br.ProductTrend = b.ProductTrend;

            ProductValidator bv = new ProductValidator();
            ValidationResult results = bv.Validate(br);
            if (results.IsValid)
            {
                cm.TAdd(br);
                return RedirectToAction("AProduct", "AdminProduct");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
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

            ViewBag.ProductImage = values.ProductImage;
            ViewBag.Path = values.ProductImage;
            return View(values);
        }
        [HttpPost]
        public IActionResult EditProduct(AddProductImage b)
        {
            Product br = new Product();
            if (b.Path == null || b.ProductImage != null)
            {
                var extension = Path.GetExtension(b.ProductImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/ProductImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.ProductImage.CopyTo(stream);
                br.ProductImage = "/Image/ProductImage/" + newimagename;
            }
            br.ProductId = b.ProductId;
            br.BrandId = b.BrandId;
            br.CategoryId = b.CategoryId;
            br.ProductComment = b.ProductComment;
            br.ProductName = b.ProductName;
            br.ProductTrend = b.ProductTrend;
            br.ProductImage = b.Path;
            ProductValidator bv = new ProductValidator();
            ValidationResult results = bv.Validate(br);
            if (results.IsValid)
            {
                cm.TUpdate(br);
                return RedirectToAction("AProduct");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
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
    }
}
