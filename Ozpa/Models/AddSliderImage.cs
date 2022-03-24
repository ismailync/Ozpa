using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Models
{
    public class AddSliderImage
    {
        public int BannerId { get; set; }
        public IFormFile BannerImage { get; set; }
        public int CategoryId { get; set; }
    }
}
