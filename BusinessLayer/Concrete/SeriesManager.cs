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
        public void TAdd(Series t)
        {
            _seriesDal.Insert(t);
        }

        public void TDelete(Series t)
        {
            _seriesDal.Delete(t);
        }

        public void TUpdate(Series t)
        {
            _seriesDal.Update(t);
        }
    }
}
