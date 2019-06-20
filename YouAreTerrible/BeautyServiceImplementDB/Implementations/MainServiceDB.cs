using BeautyModel;
using BeautyServiceDAL.BindingModels;
using BeautyServiceDAL.Interfaces;
using BeautyServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceImplementDB.Implementations
{
    public class MainServiceDB : IMainService
    {
        private BeautyDbContext context;
        public MainServiceDB(BeautyDbContext context)
        {
             this.context = context;
        }
        public List<ApplicationViewModel> GetList()
        {
            List<ApplicationViewModel> result = context.Applications.Select(rec => new ApplicationViewModel
            {
                ApplicationId = rec.ApplicationId,
                ResourseId = rec.ResourseId,
                Count = rec.Count,
                Summa = rec.Sum,
                Status = rec.Status.ToString(),
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
            SqlFunctions.DateName("mm", rec.DateCreate) + " " +
            SqlFunctions.DateName("yyyy", rec.DateCreate),
                DateImplement = rec.DateImplement == null ? "" :
            SqlFunctions.DateName("dd",
            rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("mm",
            rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("yyyy",
            rec.DateImplement.Value)
            })
            .ToList();
            return result;
        }
        public void CreateApplication(ApplicationBindingModel model)
        {
            context.Applications.Add(new Application
            {
                DateCreate = DateTime.Now,
                ResourseId = model.ResourseId,
                Count = model.Count,
                Sum = model.Summa,
                Status = ApplicationStatus.Создана
            });
            context.SaveChanges();
        }
        public void SendApplication(ApplicationBindingModel model)
        {
            Application element = context.Applications.FirstOrDefault(rec => rec.ApplicationId == model.ApplicationId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != ApplicationStatus.Создана)
            {
                throw new Exception("Заявка не в статусе \"Создана\"");
            }
            //код отправка по почте
            element.Status = ApplicationStatus.Отправлена;
            context.SaveChanges();
        }
        public bool ApplicationFinished(ApplicationBindingModel model)
        {
            Application element = context.Applications.FirstOrDefault(rec => rec.ApplicationId == model.ApplicationId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != ApplicationStatus.Отправлена)
            {
                throw new Exception("Заявка не в статусе \"Отправлена\"");
            }
            //if (код проверки выполнена ли)
            //{
            //    return true;
            //}
            return false;
        }
        public void FinishApplication(ApplicationBindingModel model)
        {
            Application element = context.Applications.FirstOrDefault(rec => rec.ApplicationId == model.ApplicationId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != ApplicationStatus.Отправлена)
            {
                throw new Exception("Заявка не в статусе \"Отправлена\"");
            }
            if (ApplicationFinished != true)
            {
                throw new Exception("Заявка ещё не выполнена");
            }
            element.DateImplement = DateTime.Now;
            element.Status = ApplicationStatus.Выполнена;
            context.SaveChanges();
        }
    }
}
