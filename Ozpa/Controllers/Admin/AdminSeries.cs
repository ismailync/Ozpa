using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers.Admin
{
    public class AdminSeries : Controller
    {
        public IActionResult ASeries()
        {
            return View();
        }
    }
}
