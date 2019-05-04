using BeautyServiceDAL.Interfaces;
using BeautyServiceImplementList.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyViewWeb
{
    public static class Globals
    {
        public static IResourseService ResourseService { get; } = new ResourseServiceList();
        public static IServiceService ServiceService { get; } = new ServiceServiceList();
        public static IMainService MainService { get; } = new MainServiceList();
    }
}