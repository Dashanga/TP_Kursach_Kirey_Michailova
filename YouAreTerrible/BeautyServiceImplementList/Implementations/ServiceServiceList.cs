using BeautyModel;
using BeautyServiceDAL.BindingModels;
using BeautyServiceDAL.Interfaces;
using BeautyServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeautyServiceImplementList.Implementations
{
    public class ServiceServiceList : IServiceService
    {
        private DataListSingleton source;
        public ServiceServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<ServiceViewModel> GetList()
        {
            List<ServiceViewModel> result = source.Services
            .Select(rec => new ServiceViewModel
            {
                ServiceId = rec.ServiceId,
                ServiceName = rec.ServiceName,
                ServiceResourses = source.ServiceResourses
                .Where(recPC => recPC.ServiceId == rec.ServiceId)
                .Select(recPC => new ServiceResourseViewModel
                {
                    ServiceResourseId = recPC.ServiceResourseId,
                    ServiceId = recPC.ServiceId,
                    ResourseId = recPC.ResourseId,
                    ResourseName = source.Resourses.FirstOrDefault(recC =>
                    recC.ResourseId == recPC.ResourseId)?.ResourseName,
                    Count = recPC.Count
                })
                .ToList()
            })
            .ToList();
            return result;
        }
        public ServiceViewModel GetElement(int id)
        {
            Service element = source.Services.FirstOrDefault(rec => rec.ServiceId == id);
            if (element != null)
            {
                return new ServiceViewModel
                {
                    ServiceId = element.ServiceId,
                    ServiceName = element.ServiceName,
                    ServiceResourses = source.ServiceResourses
                    .Where(recPC => recPC.ServiceId == element.ServiceId)
                    .Select(recPC => new ServiceResourseViewModel
                {
                    ServiceResourseId = recPC.ServiceResourseId,
                    ServiceId = recPC.ServiceId,
                    ResourseId = recPC.ResourseId,
                    ResourseName = source.Resourses.FirstOrDefault(recC =>
                    recC.ResourseId == recPC.ResourseId)?.ResourseName,
                    Count = recPC.Count
                })
               .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(ServiceBindingModel model)
        {
            Service element = source.Services.FirstOrDefault(rec => rec.ServiceName ==
            model.ServiceName);
            if (element != null)
            {
                throw new Exception("Уже есть услуга с таким названием");
            }
            int maxId = source.Services.Count > 0 ? source.Services.Max(rec => rec.ServiceId) : 0;
            source.Services.Add(new Service
            {
                ServiceId = maxId + 1,
                ServiceName = model.ServiceName
            });
            // компоненты для изделия
            int maxPCId = source.ServiceResourses.Count > 0 ?
            source.ServiceResourses.Max(rec => rec.ServiceResourseId) : 0;
            // убираем дубли по компонентам
            var groupComponents = model.ServiceResourses
            .GroupBy(rec => rec.ResourseId)
            .Select(rec => new
            {
               ResourseId = rec.Key,
               Count = rec.Sum(r => r.Count)
            });
            // добавляем компоненты
            foreach (var groupComponent in groupComponents)
            {
                source.ServiceResourses.Add(new ServiceResourse
                {
                    ServiceResourseId = ++maxPCId,
                    ServiceId = maxId + 1,
                    ResourseId = groupComponent.ResourseId,
                    Count = groupComponent.Count
                });
            }
            var productComponents = source.ServiceResourses.Where(rec => rec.ServiceId
            == element.ServiceId);
            foreach (var productComponent in productComponents)
            {
                int countOnStocks = source.SkladResourses
                .Where(rec => rec.ResourseId ==
               productComponent.ResourseId)
               .Sum(rec => rec.Count);
                if (countOnStocks < productComponent.Count)
                {
                    var componentName = source.Resourses.FirstOrDefault(rec => rec.ResourseId ==
                   productComponent.ResourseId);
                    throw new Exception("Не достаточно ресурсов " +
                   componentName?.ResourseName + " требуется " + (productComponent.Count) +
                   ", в наличии " + countOnStocks);
                }
            }
            // списываем
            foreach (var productComponent in productComponents)
            {
                int countOnStocks = productComponent.Count;
                var stockComponents = source.SkladResourses.Where(rec => rec.ResourseId
               == productComponent.ResourseId);
                foreach (var stockComponent in stockComponents)
                {
                    // компонентов на одном слкаде может не хватать
                    if (stockComponent.Count >= countOnStocks)
                    {
                        stockComponent.Count -= countOnStocks;
                        break;
                    }
                    else
                    {
                        countOnStocks -= stockComponent.Count;
                        stockComponent.Count = 0;
                    }
                }
            }
        }
        //public void UpdElement(ServiceBindingModel model)
        //{
        //    Service element = source.Services.FirstOrDefault(rec => rec.ServiceName ==
        //    model.ServiceName && rec.ServiceId != model.ServiceId);
        //    if (element != null)
        //    {
        //        throw new Exception("Уже есть услуга с таким названием");
        //    }
        //    element = source.Services.FirstOrDefault(rec => rec.ServiceId == model.ServiceId);
        //    if (element == null)
        //    {
        //        throw new Exception("Элемент не найден");
        //    }
        //    element.ServiceName = model.ServiceName;
        //    int maxPCId = source.ServiceResourses.Count > 0 ?
        //    source.ServiceResourses.Max(rec => rec.ServiceResourseId) : 0;
        //    // обновляем существуюущие компоненты
        //    var compIds = model.ServiceResourses.Select(rec =>
        //    rec.ResourseId).Distinct();
        //    var updateComponents = source.ServiceResourses.Where(rec => rec.ServiceId ==
        //    model.ServiceId && compIds.Contains(rec.ResourseId));
        //    foreach (var updateComponent in updateComponents)
        //    {
        //        updateComponent.Count = model.ServiceResourses.FirstOrDefault(rec =>
        //       rec.ServiceResourseId == updateComponent.ServiceResourseId).Count;
        //    }
        //    source.ServiceResourses.RemoveAll(rec => rec.ServiceId == model.ServiceId &&
        //    !compIds.Contains(rec.ResourseId));
        //    // новые записи
        //    var groupComponents = model.ServiceResourses
        //    .Where(rec => rec.ServiceResourseId == 0)
        //    .GroupBy(rec => rec.ResourseId)
        //    .Select(rec => new
        //    {
        //       ResourseId = rec.Key,
        //       Count = rec.Sum(r => r.Count)
        //    });
        //    foreach (var groupComponent in groupComponents)
        //    {
        //        ServiceResourse elementPC = source.ServiceResourses.FirstOrDefault(rec
        //        => rec.ServiceId == model.ServiceId && rec.ResourseId == groupComponent.ResourseId);
        //        if (elementPC != null)
        //        {
        //            elementPC.Count += groupComponent.Count;
        //        }
        //        else
        //        {
        //            source.ServiceResourses.Add(new ServiceResourse
        //            {
        //                ServiceResourseId = ++maxPCId,
        //                ServiceId = model.ServiceId,
        //                ResourseId = groupComponent.ResourseId,
        //                Count = groupComponent.Count
        //            });
        //        }
        //    }
        //}
        public void DelElement(int id)
        {
            Service element = source.Services.FirstOrDefault(rec => rec.ServiceId == id);
            if (element != null)
            {
                // удаяем записи по компонентам при удалении изделия
                source.ServiceResourses.RemoveAll(rec => rec.ServiceId == id);
                source.Services.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
