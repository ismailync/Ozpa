using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBrandRepository : GenericRepository<Brand>, IBrandDal
    {
        public Brand GetBrandWithProductsByBrandId(int brandId)
        {
            using var c = new Context();
            return c.Brands.Where(p => p.BrandId == brandId).Include(x => x.Products).FirstOrDefault();
        }
    }
}
