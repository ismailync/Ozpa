using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers.Admin
{
    public class AdminNews : Controller
    {
        public IActionResult ANews()
        {       
            return View();
        }
    }
}
