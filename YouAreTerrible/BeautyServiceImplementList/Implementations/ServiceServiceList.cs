using BeautyModel;
using BeautyServiceDAL.BindingModels;
using BeautyServiceDAL.Interfaces;
using BeautyServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<ServiceViewModel> result = new List<ServiceViewModel>();
            for (int i = 0; i < source.Services.Count; ++i)
            {
                List<ServiceResourseViewModel> productComponents = new List<ServiceResourseViewModel>();
                for (int j = 0; j < source.ServiceResourses.Count; ++j)
                {
                    if (source.ServiceResourses[j].ServiceId == source.Services[i].ServiceId)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Resourses.Count; ++k)
                        {
                            if (source.ServiceResourses[j].ResourseId ==
                           source.Resourses[k].ResourseId)
                            {
                                componentName = source.Resourses[k].ResourseName;
                                break;
                            }
                        }
                        productComponents.Add(new ServiceResourseViewModel
                        {
                            ServiceResourseId = source.ServiceResourses[j].ServiceResourseId,
                            ServiceId = source.ServiceResourses[j].ServiceId,
                            ResourseId = source.ServiceResourses[j].ResourseId,
                            ResourseName = componentName,
                            Count = source.ServiceResourses[j].Count
                        });
                    }
                }
                result.Add(new ServiceViewModel
                {
                    ServiceId = source.Services[i].ServiceId,
                    ServiceName = source.Services[i].ServiceName,
                    ServicePrice = source.Services[i].ServicePrice,
                    ServiceResourses = productComponents
                });
            }
            return result;
        }
        public ServiceViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Services.Count; ++i)
            {
                List<ServiceResourseViewModel> productComponents = new List<ServiceResourseViewModel>();
                for (int j = 0; j < source.ServiceResourses.Count; ++j)
                {
                    if (source.ServiceResourses[j].ServiceId == source.Services[i].ServiceId)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Resourses.Count; ++k)
                        {
                            if (source.ServiceResourses[j].ResourseId == source.Resourses[k].ResourseId)
                            {
                                componentName = source.Resourses[k].ResourseName;
                                break;
                            }
                        }
                        productComponents.Add(new ServiceResourseViewModel
                        {
                            ServiceResourseId = source.ServiceResourses[j].ServiceResourseId,
                            ServiceId = source.ServiceResourses[j].ServiceId,
                            ResourseId = source.ServiceResourses[j].ResourseId,
                            ResourseName = componentName,
                            Count = source.ServiceResourses[j].Count
                        });
                    }
                }
                if (source.Services[i].ServiceId == id)
                {
                    return new ServiceViewModel
                    {
                        ServiceId = source.Services[i].ServiceId,
                        ServiceName = source.Services[i].ServiceName,
                        ServicePrice = source.Services[i].ServicePrice,
                        ServiceResourses = productComponents
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(ServiceBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Services.Count; ++i)
            {
                if (source.Services[i].ServiceId > maxId)
                {
                    maxId = source.Services[i].ServiceId;
                }
                if (source.Services[i].ServiceName == model.ServiceName)
                {
                    throw new Exception("Уже есть услуга с таким названием");
                }
            }
            source.Services.Add(new Service
            {
                ServiceId = maxId + 1,
                ServiceName = model.ServiceName,
                ServicePrice = model.ServicePrice
            });
            // компоненты для изделия
            int maxPCId = 0;
            for (int i = 0; i < source.ServiceResourses.Count; ++i)
            {
                if (source.ServiceResourses[i].ServiceResourseId > maxPCId)
                {
                    maxPCId = source.ServiceResourses[i].ServiceResourseId;
                }
            }
            // убираем дубли по компонентам
            for (int i = 0; i < model.ServiceResourses.Count; ++i)
            {
                for (int j = 1; j < model.ServiceResourses.Count; ++j)
                {
                    if (model.ServiceResourses[i].ResourseId ==
                    model.ServiceResourses[j].ResourseId)
                    {
                        model.ServiceResourses[i].Count +=
                        model.ServiceResourses[j].Count;
                        model.ServiceResourses.RemoveAt(j--);
                    }
                }
            }
            // добавляем компоненты
            for (int i = 0; i < model.ServiceResourses.Count; ++i)
            {
                source.ServiceResourses.Add(new ServiceResourse
                {
                    ServiceResourseId = ++maxPCId,
                    ServiceId = maxId + 1,
                    ResourseId = model.ServiceResourses[i].ResourseId,
                    Count = model.ServiceResourses[i].Count
                });
            }
        }
        public void UpdElement(ServiceBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Services.Count; ++i)
            {
                if (source.Services[i].ServiceId == model.ServiceId)
                {
                    index = i;
                }
                if (source.Services[i].ServiceName == model.ServiceName &&
                source.Services[i].ServiceId != model.ServiceId)
                {
                    throw new Exception("Уже есть услуга с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Services[index].ServiceName = model.ServiceName;
            source.Services[index].ServicePrice = model.ServicePrice;
            int maxPCId = 0;
            for (int i = 0; i < source.ServiceResourses.Count; ++i)
            {
                if (source.ServiceResourses[i].ServiceResourseId > maxPCId)
                {
                    maxPCId = source.ServiceResourses[i].ServiceResourseId;
                }
            }
            // обновляем существуюущие компоненты
            for (int i = 0; i < source.ServiceResourses.Count; ++i)
            {
                if (source.ServiceResourses[i].ServiceId == model.ServiceId)
                {
                    bool flag = true;
                    for (int j = 0; j < model.ServiceResourses.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.ServiceResourses[i].ServiceResourseId ==
                       model.ServiceResourses[j].ServiceResourseId)
                        {
                            source.ServiceResourses[i].Count = model.ServiceResourses[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.ServiceResourses.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for (int i = 0; i < model.ServiceResourses.Count; ++i)
            {
                if (model.ServiceResourses[i].ServiceResourseId == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.ServiceResourses.Count; ++j)
                    {
                        if (source.ServiceResourses[j].ServiceId == model.ServiceId &&
                        source.ServiceResourses[j].ResourseId ==
                       model.ServiceResourses[i].ResourseId)
                        {
                            source.ServiceResourses[j].Count +=
                           model.ServiceResourses[i].Count;
                            model.ServiceResourses[i].ServiceResourseId =
                           source.ServiceResourses[j].ServiceResourseId;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.ServiceResourses[i].ServiceResourseId == 0)
                    {
                        source.ServiceResourses.Add(new ServiceResourse
                        {
                            ServiceResourseId = ++maxPCId,
                            ServiceId = model.ServiceId,
                            ResourseId = model.ServiceResourses[i].ResourseId,
                            Count = model.ServiceResourses[i].Count
                        });
                    }
                }
            }
        }
        public void DelElement(int id)
        {
            // удаяем записи по компонентам при удалении изделия
            for (int i = 0; i < source.ServiceResourses.Count; ++i)
            {
                if (source.ServiceResourses[i].ServiceId == id)
                {
                    source.ServiceResourses.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Services.Count; ++i)
            {
                if (source.Services[i].ServiceId == id)
                {
                    source.Services.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
