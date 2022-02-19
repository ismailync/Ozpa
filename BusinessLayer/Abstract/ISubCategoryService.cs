using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISubCategoryService
    {
        void SubCategoryAdd(SubCategory subCategory);
        void SubCategoryDelete(SubCategory subCategory);
        void SubCategoryUpdate(SubCategory subCategory);
        List<SubCategory> GetList();
        SubCategory GetById(int id);
    }
}
