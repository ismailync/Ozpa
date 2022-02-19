using BusinessLayer.Abstract;
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
        public News GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<News> GetList()
        {
            throw new NotImplementedException();
        }

        public void NewsAdd(News news)
        {
            throw new NotImplementedException();
        }

        public void NewsDelete(News news)
        {
            throw new NotImplementedException();
        }

        public void NewsUpdate(News news)
        {
            throw new NotImplementedException();
        }
    }
}
