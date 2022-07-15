using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Models
{
    public class AddCategoryImage
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IFormFile CategorySeriesImage { get; set; }
        public IFormFile CategoryImage { get; set; }
        public bool CategorySeries { get; set; }
        public string Path { get; set; }
        public string PathTo { get; set; }

    }
}
