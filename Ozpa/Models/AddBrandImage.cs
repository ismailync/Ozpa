using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Models
{
    public class AddBrandImage
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public IFormFile BrandImage { get; set; }
        public IFormFile BrandBannerImage { get; set; }
        public string Path { get; set; }
        public string PathTo { get; set; }

    }
}
