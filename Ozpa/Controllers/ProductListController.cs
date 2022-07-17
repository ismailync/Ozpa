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
    public class ProductListController : Controller
    {
        ProductManager bm = new ProductManager(new EfProductRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IActionResult ProductListIndex(int pageId = 1)
        {
            //var products = bm.GetList();
            var products = bm.GetPaged(pageId);
            var categories = cm.GetList();
            var values = new CategoriesProducts { Categories = categories, PaginatedProducts = products };
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
