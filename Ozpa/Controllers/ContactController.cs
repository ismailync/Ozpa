using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Ozpa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactRepository());

        [HttpGet]
        public IActionResult ContactIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactIndex(AddContact b)
        {
            Contact br = new Contact();
            br.ContactDTime = DateTime.Now;
            br.ContactName = b.ContactName;
            br.ContactEMail = b.ContactEMail;
            br.ContactSubject = b.ContactSubject;
            br.ContactMessage = b.ContactMessage;

            ContactValidator bv = new ContactValidator();
            ValidationResult results = bv.Validate(br);
            if (results.IsValid)
            {
                cm.TAdd(br);
                return RedirectToAction("ContactIndex", "Contact");
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
