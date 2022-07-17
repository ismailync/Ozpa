using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CategoriesProducts
    {
        public PaginatedListProduct PaginatedProducts { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }

    }
}
