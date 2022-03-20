using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers.Admin
{
    public class AdminProduct : Controller
    {
        public IActionResult AProduct()
        {
            return View();
        }
    }
}
