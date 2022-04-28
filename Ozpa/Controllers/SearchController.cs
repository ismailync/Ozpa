using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers
{
    public class SearchController : Controller
    {
        ProductManager bm = new ProductManager(new EfProductRepository());
        public IActionResult SearchIndex()
        {
            var values = bm.GetProductListWithCategory();
            return View(values);
        }
    }
}
