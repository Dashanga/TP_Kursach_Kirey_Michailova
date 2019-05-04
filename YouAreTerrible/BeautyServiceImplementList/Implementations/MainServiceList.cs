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
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;
        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<ApplicationViewModel> GetList()
        {
            List<ApplicationViewModel> result = new List<ApplicationViewModel>();
            for (int i = 0; i < source.Applications.Count; ++i)
            {
                string productName = string.Empty;
                for (int j = 0; j < source.Resourses.Count; ++j)
                {
                    if (source.Resourses[j].ResourseId == source.Applications[i].ResourseId)
                    {
                        productName = source.Resourses[j].ResourseName;
                        break;
                    }
                }
                result.Add(new ApplicationViewModel
                {
                    ApplicationId = source.Applications[i].ApplicationId,
                    ResourseId = source.Applications[i].ResourseId,
                    ResourseName = productName,
                    Count = source.Applications[i].Count,
                    Summa = source.Applications[i].Summa,
                    DateCreate = source.Applications[i].DateCreate.ToLongDateString(),
                    DateImplement = source.Applications[i].DateImplement?.ToLongDateString(),
                    Status = source.Applications[i].Status.ToString()
                });
            }
            return result;
        }
        public void CreateApplication(ApplicationBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Applications.Count; ++i)
            {
                if (source.Applications[i].ApplicationId > maxId)
                {
                    maxId = source.Applications[i].ApplicationId;
                }
            }
            source.Applications.Add(new Application
            {
                ApplicationId = maxId + 1,
                ResourseId = model.ResourseId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Summa = model.Summa,
                Status = ApplicationStatus.Создана
            });
        }
        public void SendApplication(ApplicationBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Applications.Count; ++i)
            {
                if (source.Applications[i].ApplicationId == model.ApplicationId)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Applications[index].Status != ApplicationStatus.Создана)
            {
                throw new Exception("Заявка не в статусе \"Создана\"");
            }
            source.Applications[index].DateImplement = DateTime.Now;
            source.Applications[index].Status = ApplicationStatus.Отправлена;
        }
        public void FinishApplication(ApplicationBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Applications.Count; ++i)
            {
                if (source.Applications[i].ApplicationId == model.ApplicationId)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Applications[index].Status != ApplicationStatus.Отправлена)
            {
                throw new Exception("Заявка не в статусе \"Отправлена\"");
            }
            source.Applications[index].Status = ApplicationStatus.Выполнена;
        }
    }
}
