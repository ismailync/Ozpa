﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult ContactIndex()
        {
            return View();
        }
    }
}