using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductRepository : GenericRepository<Product>, IProductDal
    {
        public List<Product> GetListWithCategory()
        {
            using (var c = new Context())
            {
                return c.Products.Include(x => x.Category).ToList();
            }
        }

        public PaginatedListProduct GetPaged(int page, int pageSize)
        {
            using (var c = new Context())
            {
                var result = new PaginatedListProduct();
                result.CurrentPage = page;
                result.PageSize = pageSize;
                result.RowCount = c.Products.Count();


                var pageCount = (double)result.RowCount / pageSize;
                result.PageCount = (int)Math.Ceiling(pageCount);

                var skip = (page - 1) * pageSize;
                result.Results = c.Products.Skip(skip).Take(pageSize).ToList();

                return result;
            }
        }

        public List<Product> GetSeachProduct(string searchText)
        {
            using (var c = new Context())
            {
                return c.Products.Where(p => p.ProductName.Contains(searchText)).ToList();
            }
        }
    }
}
