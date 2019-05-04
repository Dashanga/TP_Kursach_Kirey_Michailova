using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;
using ForgeServiceImplementList.Implementations;

namespace BeautyViewWeb
{
    public static class Globals
    {
        public static IResourseService ResourseService { get; } = new ResourseServiceList();
        public static IServiceService ServiceService { get; } = new ServiceServiceList();
        public static IMainService MainService { get; } = new MainServiceList();
    }
}