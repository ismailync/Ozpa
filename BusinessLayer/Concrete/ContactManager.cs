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
    public class ContactManager : IContactService
    {
        IContactDal _contacDal;
        public ContactManager(IContactDal contacDal)
        {
            _contacDal = contacDal;
        }
        public List<Contact> GetList()
        {
            return _contacDal.GetListAll();
        }

        public void TAdd(Contact t)
        {
            _contacDal.Insert(t);
        }

        public void TDelete(Contact t)
        {
            _contacDal.Delete(t);
        }

        public Contact TGetById(int id)
        {
            return _contacDal.GetByID(id);
        }

        public void TUpdate(Contact t)
        {
            _contacDal.Update(t);
        }
    }
}
