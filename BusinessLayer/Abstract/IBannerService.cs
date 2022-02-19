using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBannerService
    {
        void BannerAdd(Banner banner);
        void BannerDelete(Banner banner);
        void BannerUpdate(Banner banner);
        List<Banner> GetList();
        Banner GetById(int id);
    }
}
