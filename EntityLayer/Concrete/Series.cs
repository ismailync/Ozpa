﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Series
    {
        [Key]
        public int SeriesId { get; set; }
        public string SeriesImage { get; set; }
        public string SeriesName { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
