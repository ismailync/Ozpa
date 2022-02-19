using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INewsService
    {
        void NewsAdd(News news);
        void NewsDelete(News news);
        void NewsUpdate(News news);
        List<News> GetList();
        News GetById(int id);
    }
}
