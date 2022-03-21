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
    public class AdminLoginManager : ILoginService
    {
        IAdminLoginDal _adminLoginDal;
        public AdminLoginManager(IAdminLoginDal adminLoginDal)
        {
            _adminLoginDal = adminLoginDal;
        }
        public AdminLogin GetById(int id)
        {
            return _adminLoginDal.GetByID(id);
        }

        public List<AdminLogin> GetList()
        {
            return _adminLoginDal.GetListAll();
        }

        public void TAdd(AdminLogin t)
        {
            _adminLoginDal.Insert(t);
        }

        public void TDelete(AdminLogin t)
        {
            _adminLoginDal.Delete(t);
        }

        public void TUpdate(AdminLogin t)
        {
            _adminLoginDal.Update(t);
        }
    }
}
