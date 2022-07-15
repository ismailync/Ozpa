using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers
{
    public class BrandProduct : Controller
    {
        BrandManager bm = new BrandManager(new EfBrandRepository());
        public IActionResult Index(int id)
        {
            var values = bm.GetBrandWithProductsByBrandId(id);
            return View(values);

        }
    }
}
