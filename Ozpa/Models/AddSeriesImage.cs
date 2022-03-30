using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Models
{
    public class AddSeriesImage
    {
        public int SeriesId { get; set; }
        public IFormFile SeriesImage { get; set; }
        public string SeriesName { get; set; }
        public int CategoryId { get; set; }
        public string Path { get; set; }

    }
}
