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
    public class BannerManager : IBannerService
    {
        IBannerDal _bannerDal;
        public BannerManager(IBannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }
        public Banner GetById(int id)
        {
            return _bannerDal.GetByID(id);
        }

        public List<Banner> GetList()
        {
            return _bannerDal.GetListAll();
        }

        public void TAdd(Banner t)
        {
            _bannerDal.Insert(t);
        }

        public void TDelete(Banner t)
        {
            _bannerDal.Delete(t);
        }

        public void TUpdate(Banner t)
        {
            _bannerDal.Update(t);
        }
    }
}
