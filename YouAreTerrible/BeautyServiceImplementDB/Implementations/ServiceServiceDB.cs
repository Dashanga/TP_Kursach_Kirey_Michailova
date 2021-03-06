﻿using BeautyModel;
using BeautyServiceDAL.BindingModels;
using BeautyServiceDAL.Interfaces;
using BeautyServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceImplementDB.Implementations
{
    public class ServiceServiceDB : IServiceService
    {
        private BeautyDbContext context;
        public ServiceServiceDB(BeautyDbContext context)
        {
            this.context = context;
        }
        public List<ServiceViewModel> GetList()
        {
            List<ServiceViewModel> result = context.Services.Select(rec => new
            ServiceViewModel
            {
                ServiceId = rec.ServiceId,
                ServiceName = rec.ServiceName,
                ServiceResourses = context.ServiceResourses
            .Where(recPC => recPC.ServiceId == rec.ServiceId)
            .Select(recPC => new ServiceResourseViewModel
            {
                ServiceResourseId = recPC.ServiceResourseId,
                ServiceId = recPC.ServiceId,
                ResourseId = recPC.ResourseId,
                ResourseName = recPC.Resourse.ResourseName,
                Count = recPC.Count
            })
            .ToList()
            })
            .ToList();
            return result;
        }
        public ServiceViewModel GetElement(int id)
        {
            Service element = context.Services.FirstOrDefault(rec => rec.ServiceId == id);
            if (element != null)
            {
                return new ServiceViewModel
                {
                    ServiceId = element.ServiceId,
                    ServiceName = element.ServiceName,
                    ServiceResourses = context.ServiceResourses
                    .Where(recPC => recPC.ServiceId == element.ServiceId)
                    .Select(recPC => new ServiceResourseViewModel
                    {
                        ServiceResourseId = recPC.ServiceResourseId,
                        ServiceId = recPC.ServiceId,
                        ResourseId = recPC.ResourseId,
                        ResourseName = recPC.Resourse.ResourseName,
                        Count = recPC.Count
                    })
                    .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(ServiceBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    //Service element = context.Services.FirstOrDefault(rec =>
                    //rec.ServiceName == model.ServiceName);
                    //if (element != null)
                    //{
                    //    throw new Exception("Уже есть услуга с таким названием");
                    //}
                    
                    //foreach (var resourse in model.ServiceResourses)
                    //{
                    //    int countOnStocks = resourse.Count;
                    //    //var skladElements = от Марины
                    //    foreach (var skladElement in skladElements)
                    //    {
                    //        // компонентов на одном слкаде может не хватать
                    //        if (skladElement.Count >= countOnStocks)
                    //        {
                    //            skladElement.Count -= countOnStocks;
                    //            countOnStocks = 0;
                    //            context.SaveChanges();
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            countOnStocks -= skladElement.Count;
                    //            skladElement.Count = 0;
                    //            context.SaveChanges();
                    //        }
                    //    }
                    //    if (countOnStocks > 0)
                    //    {
                    //        throw new Exception("Не достаточно ресурсов " +
                    //        outputElement.Resourse.ResourseName + " требуется " + outputElement.Count + ", не хватает " + countOnStocks);
                    //    }
                    //}
                    //element = new Service
                    //{
                    //    ServiceName = model.ServiceName
                    //};
                    //context.Services.Add(element);
                    //context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
