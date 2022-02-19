using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsImage { get; set; }
        public string NewsComment { get; set; }
    }
}
