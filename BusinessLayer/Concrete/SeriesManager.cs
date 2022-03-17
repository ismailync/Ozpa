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
    public class SeriesManager : ISeriesService
    {
        ISeriesDal _seriesDal;
        public SeriesManager(ISeriesDal seriesDal)
        {
            _seriesDal = seriesDal;
        }
        public Series GetById(int id)
        {
            return _seriesDal.GetByID(id);
        }

        public List<Series> GetList()
        {
            return _seriesDal.GetListAll();
        }

        public void SeriesAdd(Series series)
        {
            _seriesDal.Insert(series);
        }

        public void SeriesDelete(Series series)
        {
            _seriesDal.Delete(series);
        }

        public void SeriesUpdate(Series series)
        {
            _seriesDal.Update(series);
        }
    }
}
