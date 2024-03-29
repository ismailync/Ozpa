﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> GetProductListByBrand(int id);
        PaginatedListProduct GetPaged(int pageId);
        List<Product> GetSeachProduct(string searchText);
    }
}
