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
            var categoryList = new List<Category>();
            foreach (var product in values.Products)
            {
                categoryList.Add(product.Category);
            }
            values.Categories = categoryList;
            return View(values);

        }
    }
}
