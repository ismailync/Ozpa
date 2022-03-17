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
        void SeriesAdd(Series series);
        void SeriesDelete(Series series);
        void SeriesUpdate(Series series);
        List<Series> GetList();
        Series GetById(int id);
    }
}
