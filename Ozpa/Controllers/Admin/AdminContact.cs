using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers.Admin
{
    public class AdminContact : Controller
    {
        ContactManager cm = new ContactManager(new EfContactRepository());
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult ContactS(int id)
        {
            var values = cm.TGetById(id);
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);           
            return RedirectToAction("Index");
        }
    }
}
