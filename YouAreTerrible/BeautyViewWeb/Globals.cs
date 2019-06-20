using BeautyServiceDAL.Interfaces;
using BeautyServiceImplementDB;
using BeautyServiceImplementDB.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyViewWeb
{
    public static class Globals
    {
        public static BeautyDbContext DbContext { get; } = new BeautyDbContext();
        public static IResourseService ResourseService { get; } = new ResourseServiceDB(DbContext);
        public static IServiceService ServiceService { get; } = new ServiceServiceDB(DbContext);
        public static IMainService MainService { get; } = new MainServiceDB(DbContext);
        public static ISkladService SkladService { get; } = new SkladServiceDB(DbContext);
    }
}