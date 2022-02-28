using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISeriesService
    {
        void AboutAdd(Series series);
        void AboutDelete(Series series);
        void AboutUpdate(Series series);
        List<Series> GetList();
        Series GetById(int id);
    }
}
