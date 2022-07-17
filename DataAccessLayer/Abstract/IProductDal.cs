using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetListWithCategory();
        PaginatedListProduct GetPaged(int page, int pageSize);

        List<Product> GetSeachProduct(string searchText);

    }
}
