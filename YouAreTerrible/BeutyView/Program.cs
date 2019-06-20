using BeautyServiceDAL_P.Interfaces;
using BeautyServiceImplementDataBase;
using BeautyServiceImplementDataBase.Implementations;
using BeautyServiceImplementListP.Implementations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace BeutyView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormLogin>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, BeautyDbContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IResourseService, ResourseServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISkladService, SkladServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportService, ReportServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProviderService, ProviderServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IApplicationService, ApplicationServiceDB>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
