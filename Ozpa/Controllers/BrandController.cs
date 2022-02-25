using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult BrandIndex()
        {
            return View();
        }
    }
}
