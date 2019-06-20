using BeautyModel;
using BeautyServiceDAL_P.BindingModels;
using BeautyServiceDAL_P.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautyServiceDAL_P.Interfaces;

namespace BeautyServiceImplementDataBase.Implementations
{
    public class ApplicationServiceDB : IApplicationService
    {
        private BeautyDbContext context;
        public ApplicationServiceDB(BeautyDbContext context)
        {
            this.context = context;
        }
        public List<ApplicationViewModel> GetList()
        {
            List<ApplicationViewModel> result = context.Applications.Select(rec => new
           ApplicationViewModel
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
           rec.DateImplement.Value),
                ResourseName = rec.Resourse.ResourseName
            })
            .ToList();
            return result;
        }
        public void TakeApplicationInWork(ApplicationBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())

            {
                try
                {
                    Application element = context.Applications.FirstOrDefault(rec => rec.ApplicationId ==
                   model.ApplicationId);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.Status != ApplicationStatus.Создана)
                    {
                        throw new Exception("Заявка не в статусе \"Создана\"");
                    }
                    var applications = context.Applications.Include(rec => rec.Resourse).Where(rec => rec.ApplicationId == element.ApplicationId);
                    // списываем
                    foreach (var application in applications)
                    {
                        int countOnSklads = application.Count * element.Count;
                        var skladResourses = context.SkladResourses.Where(rec =>
                        rec.ResourseId == application.ResourseId);
                        foreach (var skladResourse in skladResourses)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (skladResourse.Count >= countOnSklads)
                            {
                                skladResourse.Count -= countOnSklads;
                                countOnSklads = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnSklads -= skladResourse.Count;
                                skladResourse.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnSklads >= 0)
                        {
                            throw new Exception("Не достаточно ресурсов ");
                        }

                    }
                    element.DateImplement = DateTime.Now;
                    element.Status = ApplicationStatus.Отправлена;
                    context.SaveChanges();
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
