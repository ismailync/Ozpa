using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBrandService
    {
        void BrandAdd(Brand brand);
        void BrandDelete(Brand brand);
        void BrandUpdate(Brand brand);
        List<Brand> GetList();
        Brand GetById(int id);
    }
}
