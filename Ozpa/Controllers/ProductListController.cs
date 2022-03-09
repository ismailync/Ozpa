using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers
{
    public class ProductListController : Controller
    {
        ProductManager bm = new ProductManager(new EfProductRepository());

        public IActionResult ProductListIndex()
        {
            var values = bm.GetProductListWithCategory();
            return View(values);
        }

        public IActionResult ProductDetailsIndex(int id)
        {
            ViewBag.i = id;
            var values = bm.GetProductByID(id);
            return View(values);
        }
    }
}
