using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers
{
    public class BrandController : Controller
    {
        BrandManager cm = new BrandManager(new EfBrandRepository());

        public IActionResult BrandIndex()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}
