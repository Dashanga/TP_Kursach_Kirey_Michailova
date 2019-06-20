using BeautyModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceImplementDataBase
{
    public class BeautyDbContext : DbContext
    {
        public BeautyDbContext() : base("BeautyDatabase")
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied =
           System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Resourse> Resourses { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceResourse> ServiceResourses { get; set; }
        public virtual DbSet<Sklad> Sklads { get; set; }
        public virtual DbSet<SkladResourse> SkladResourses { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<ApplicationResourse> ApplicationResourses { get; set; }
    }
}
