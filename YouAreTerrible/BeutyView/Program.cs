using BeautyServiceDAL_P.Interfaces;
using BeautyServiceImplementList.Implementations;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IResourceService, ResourseServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISkladService, SkladServiceList>(new
HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
