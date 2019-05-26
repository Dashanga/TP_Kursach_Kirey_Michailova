using BeautyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceImplementListP
{
    class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Resourse> Resourses { get; set; }
        public List<Service> Services { get; set; }
        public List<ServiceResourse> ServiceResourses { get; set; }
        public List<Sklad> Sklads { get; set; }
        public List<SkladResourse> SkladResourses { get; set; }
        private DataListSingleton()
        {
            Resourses = new List<Resourse>();
            Services = new List<Service>();
            ServiceResourses = new List<ServiceResourse>();
            Sklads = new List<Sklad>();
            SkladResourses = new List<SkladResourse>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
