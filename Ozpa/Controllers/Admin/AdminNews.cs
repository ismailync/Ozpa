﻿using BusinessLayer.Concrete;
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
    public class AdminNews : Controller
    {
        NewsManager cm = new NewsManager(new EfNewsRepository());

        public IActionResult ANews()
        {
            var values = cm.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult NewsAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewsAdd(News b)
        {
            NewsValidator bv = new NewsValidator();
            ValidationResult results = bv.Validate(b);
            if (results.IsValid)
            {
                cm.TAdd(b);
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
    }
}
