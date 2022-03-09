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
        public void BannerAdd(Banner banner)
        {
            _bannerDal.Insert(banner);
        }

        public void BannerDelete(Banner banner)
        {
            _bannerDal.Delete(banner);
        }

        public void BannerUpdate(Banner banner)
        {
            _bannerDal.Update(banner);
        }

        public Banner GetById(int id)
        {
            return _bannerDal.GetByID(id);
        }

        public List<Banner> GetList()
        {
            return _bannerDal.GetListAll();
        }
    }
}
