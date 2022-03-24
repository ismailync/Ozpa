using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Models
{
    public class AddNewsImage
    {
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public IFormFile NewsImage { get; set; }
        public string NewsComment { get; set; }
    }
}
