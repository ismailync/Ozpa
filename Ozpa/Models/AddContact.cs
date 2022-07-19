using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Models
{
    public class AddContact
    {
        public int ContactId { get; set; }
        public DateTime ContactDTime { get; set; }
        public string ContactName { get; set; }
        public string ContactEMail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
    }
}
