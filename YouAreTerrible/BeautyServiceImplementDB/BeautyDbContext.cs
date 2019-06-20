using BeautyModel;
using System.Data.Entity;

namespace BeautyServiceImplementDB
{
    public class BeautyDbContext : DbContext
    {
        public BeautyDbContext() : base("AbstractDatabase")
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied =
            System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<Resourse> Resourses { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceResourse> ServiceResourses { get; set; }
        public virtual DbSet<Sklad> Sklads { get; set; }
        public virtual DbSet<SkladResourse> SkladResourses { get; set; }
    }
}
