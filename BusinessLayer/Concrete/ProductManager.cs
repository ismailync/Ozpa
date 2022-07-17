using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetProductListWithCategory()
        {
            return _productDal.GetListWithCategory();
        }
        public List<Product> GetProductByID(int id)
        {
            return _productDal.GetListAll(x => x.ProductId == id);
        }
        public List<Product> GetSeriesById(int id)
        {
            return _productDal.GetListAll(x => x.CategoryId == id);
        }
        public Product TGetById(int id)
        {
            return _productDal.GetByID(id);
        }

        public List<Product> GetList()
        {
            return _productDal.GetListAll();
        }
        public List<Product> GetProductListByBrand(int id)
        {
            return _productDal.GetListAll(x => x.BrandId == id);
        }

        public void TAdd(Product t)
        {
            _productDal.Insert(t);
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }

        public PaginatedListProduct GetPaged(int pageId)
        {
            return _productDal.GetPaged(pageId, 6);
        }

        public List<Product> GetSeachProduct(string searchText)
        {
            return _productDal.GetSeachProduct(searchText);
        }
    }
}
