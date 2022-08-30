using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozpa.Models
{
    public class AddCertImage
    {
        public int CertId { get; set; }
        public IFormFile CertImage { get; set; }
        public string Path { get; set; }

    }
}
