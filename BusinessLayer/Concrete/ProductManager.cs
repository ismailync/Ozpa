using BusinessLayer.Abstract;
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
        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetList()
        {
            throw new NotImplementedException();
        }

        public void ProductAdd(Product product)
        {
            throw new NotImplementedException();
        }

        public void ProductDelete(Product product)
        {
            throw new NotImplementedException();
        }

        public void ProductUpdate(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
