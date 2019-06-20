using BeautyModel;
using BeautyServiceDAL.BindingModels;
using BeautyServiceDAL.Interfaces;
using BeautyServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeautyServiceImplementDB.Implementations
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
            List<ApplicationViewModel> result = source.Applications
            .Select(rec => new ApplicationViewModel
            {
                 ApplicationId = rec.ApplicationId,
                 ResourseId = rec.ResourseId,
                 DateCreate = rec.DateCreate.ToLongDateString(),
                 DateImplement = rec.DateImplement?.ToLongDateString(),
                 Status = rec.Status.ToString(),
                 Count = rec.Count,
                 Summa = rec.Summa,
                 ResourseName = source.Resourses.FirstOrDefault(recP => recP.ResourseId ==
                 rec.ResourseId)?.ResourseName,
            })
            .ToList();
            return result;
        }
        public void CreateApplication(ApplicationBindingModel model)
        {
            int maxId = source.Applications.Count > 0 ? source.Applications.Max(rec => rec.ApplicationId) : 0;
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
            Application element = source.Applications.FirstOrDefault(rec => rec.ApplicationId == model.ApplicationId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != ApplicationStatus.Создана)
            {
                throw new Exception("Заявка не в статусе \"Создана\"");
            }
            element.DateImplement = DateTime.Now;
            element.Status = ApplicationStatus.Отправлена;
        }
        public void FinishApplication(ApplicationBindingModel model)
        {
            Application element = source.Applications.FirstOrDefault(rec => rec.ApplicationId == model.ApplicationId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != ApplicationStatus.Отправлена)
            {
                throw new Exception("Заявка не в статусе \"Отправлена\"");
            }
            element.Status = ApplicationStatus.Выполнена;
        }
    }
}
