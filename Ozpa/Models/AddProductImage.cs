using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Models
{
    public class AddProductImage
    {
        public int ProductId { get; set; }
        public IFormFile ProductImage { get; set; }
        public string ProductName { get; set; }
        public string ProductComment { get; set; }
        public bool ProductTrend { get; set; }


        public int CategoryId { get; set; }
        public int BrandId { get; set; }

    }
}
