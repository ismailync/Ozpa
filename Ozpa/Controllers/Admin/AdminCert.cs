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
    public class AdminCert : Controller
    {
        CertManager cm = new CertManager(new EfCertRepository());
        private readonly IHostingEnvironment _hostingEnvironment;
        public AdminCert(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult ACert()
        {
            var values = cm.GetList();
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);

            var filePath = _hostingEnvironment.WebRootPath + value.CertImage;
            FileInfo fi = new FileInfo(filePath);
            fi.Delete();
            return RedirectToAction("ACert");
        }
        [HttpGet]
        public IActionResult CertAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CertAdd(AddCertImage b)
        {
            Cert br = new Cert();
            if (b.CertImage != null)
            {
                var extension = Path.GetExtension(b.CertImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/CertImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.CertImage.CopyTo(stream);
                br.CertImage = "/Image/CertImage/" + newimagename;
                stream.Close();
            }

            CertValidator bv = new CertValidator();
            ValidationResult results = bv.Validate(br);
            if (results.IsValid)
            {
                cm.TAdd(br);
                return RedirectToAction("ACert", "AdminCert");
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
        public IActionResult EditCert(int id)
        {
            var values = cm.TGetById(id);

            ViewBag.CertImage = values.CertImage;
            ViewBag.Path = values.CertImage;
            return View(values);
        }
        [HttpPost]
        public IActionResult EditCert(AddCertImage b)
        {
            Cert br = new Cert();
            if (b.Path == null || b.CertImage != null)
            {
                var extension = Path.GetExtension(b.CertImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/CertImage/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.CertImage.CopyTo(stream);
                br.CertImage = "/Image/CertImage/" + newimagename;
                b.Path = br.CertImage;
                stream.Close();
            }
            br.CertId = b.CertId;
            br.CertImage = b.Path;
            CertValidator bv = new CertValidator();
            ValidationResult results = bv.Validate(br);
            if (results.IsValid)
            {
                cm.TUpdate(br);
                return RedirectToAction("ACert");
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
