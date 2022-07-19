﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public DateTime ContactDTime { get; set; }
        public string ContactName { get; set; }
        public string ContactEMail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }

    }
}
