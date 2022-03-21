using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AdminLogin
    {
        [Key]
        public int LoginID { get; set; }
        public string LoginName { get; set; }
        public int LoginPassword { get; set; }

    }
}
