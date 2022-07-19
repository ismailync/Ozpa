using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-1N40TLD; database=OzpaCosmeticDb; integrated security=true;");
            //optionsBuilder.UseSqlServer(@"Data Source = ARC578NB\SQLEXPRESS; database=OzpaCosmeticDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

            //optionsBuilder.UseSqlServer("Data Source=94.73.145.4;Initial Catalog=u9582252_Ozpa; User Id=u9582252_ozpa;Password=LRso54G8HSzh20S;");
        }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}
