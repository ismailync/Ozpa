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
    public class SeriesProductController : Controller
    {

        ProductManager bm = new ProductManager(new EfProductRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index(int id)
        {
            var products = bm.GetSeriesById(id);
            var categories = cm.GetSeriesById(id);
            var values = new CategoriesProducts { Categories = categories, Products = products };
            return View(values);
           
        }
    }
}
