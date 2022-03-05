using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers
{
    public class NewsController : Controller
    {
        NewsManager cm = new NewsManager(new EfNewsRepository());
        public IActionResult NewsIndex()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}
