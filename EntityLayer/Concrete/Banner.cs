﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Banner
    {
        [Key]
        public int BannerId { get; set; }
        public string BannerImage { get; set; }


        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
