using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers
{
    public class AboutController : Controller
    {
        AboutManager cm = new AboutManager(new EfAboutRepository());
        public IActionResult AboutIndex()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}
