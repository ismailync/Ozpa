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
    public class NewsManager : INewsService
    {
        INewsDal _newsDal;
        public NewsManager(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }
        public News GetById(int id)
        {
            return _newsDal.GetByID(id);
        }

        public List<News> GetList()
        {
            return _newsDal.GetListAll();
        }

        public void NewsAdd(News news)
        {
            _newsDal.Insert(news);
        }

        public void NewsDelete(News news)
        {
            _newsDal.Delete(news);
        }

        public void NewsUpdate(News news)
        {
            _newsDal.Update(news);
        }
    }
}
