using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers.Admin
{
    [Authorize]
    public class AdminLogins : Controller
    {
        AdminLoginManager lm = new AdminLoginManager(new EfAdminLoginRepository());
        public IActionResult ALogin()
        {
            var values = lm.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult LoginAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginAdd(AdminLogin b)
        {
            AdminLoginValidator lv = new AdminLoginValidator();
            ValidationResult results = lv.Validate(b);
            if (results.IsValid)
            {
                lm.TAdd(b);
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
        public IActionResult EditLogin(int id)
        {
            var values = lm.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditLogin(AdminLogin b)
        {
            AdminLoginValidator lv = new AdminLoginValidator();
            ValidationResult results = lv.Validate(b);
            if (results.IsValid)
            {
                lm.TUpdate(b);
                return RedirectToAction("ALogin");
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
