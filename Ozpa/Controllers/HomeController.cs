using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ozpa.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        BannerManager bm = new BannerManager(new EfBannerRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());
        BrandManager brm = new BrandManager(new EfBrandRepository());
        CategoryManager sm = new CategoryManager(new EfCategoryRepository());
        CertManager cm = new CertManager(new EfCertRepository());


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet("/")]
        public IActionResult HomeIndex()
        {
            var mainModel = new MainModel();
            mainModel.Banners = bm.GetList();
            mainModel.Products = pm.GetList();
            mainModel.Brands = brm.GetList();
            mainModel.Categories = sm.GetList();
            mainModel.Certs = cm.GetList();
            return View(mainModel);
        }

       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
