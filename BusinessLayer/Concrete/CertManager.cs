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
    public class CertManager : ICertService
    {
        ICertDal _certDal;
        public CertManager(ICertDal certDal)
        {
            _certDal = certDal;
        }
        public List<Cert> GetList()
        {
            return _certDal.GetListAll();
        }

        public void TAdd(Cert t)
        {
            _certDal.Insert(t);
        }

        public void TDelete(Cert t)
        {
            _certDal.Delete(t);
        }

        public Cert TGetById(int id)
        {
            return _certDal.GetByID(id);
        }

        public void TUpdate(Cert t)
        {
            _certDal.Update(t);
        }
    }
}
