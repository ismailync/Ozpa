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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public Brand TGetById(int id)
        {
            return _brandDal.GetByID(id);
        }

        public List<Brand> GetList()
        {
            return _brandDal.GetListAll();
        }

        public void TAdd(Brand t)
        {
            _brandDal.Insert(t);
        }

        public void TDelete(Brand t)
        {
            _brandDal.Delete(t);
        }

        public void TUpdate(Brand t)
        {
            _brandDal.Update(t);
        }
    }
}
