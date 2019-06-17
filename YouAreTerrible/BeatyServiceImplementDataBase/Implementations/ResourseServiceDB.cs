using BeautyModel;
using BeautyServiceDAL_P.BindingModels;
using BeautyServiceDAL_P.Interfaces;
using BeautyServiceDAL_P.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceImplementDataBase.Implementations
{
    public class ResourseServiceDB : IResourseService
    {
        private BeautyDbContext context;
        public ResourseServiceDB(BeautyDbContext context)
        {
            this.context = context;
        }
        public List<ResourseViewModel> GetList()
        {
            List<ResourseViewModel> result = context.Resourses.Select(rec => new
           ResourseViewModel
            {
                Id = rec.ResourseId,
                ResourseName = rec.ResourseName,
                ResoursePrice = rec.ResoursePrice
            })
            .ToList();
            return result;
        }
        public ResourseViewModel GetElement(int id)
        {
            Resourse element = context.Resourses.FirstOrDefault(rec => rec.ResourseId == id);
            if (element != null)
            {
                return new ResourseViewModel
                {
                    Id = element.ResourseId,
                    ResourseName = element.ResourseName,
                    ResoursePrice = element.ResoursePrice
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(ResourseBindingModel model)
        {
            Resourse element = context.Resourses.FirstOrDefault(rec => rec.ResourseName ==
           model.ResourseName);
            if (element != null)
            {
                throw new Exception("Уже есть ресурс с таким названием");
            }
            context.Resourses.Add(new Resourse
            {
                ResourseName = model.ResourseName,
                ResoursePrice = model.ResoursePrice
            });
            context.SaveChanges();
        }
        public void UpdElement(ResourseBindingModel model)
        {
            Resourse element = context.Resourses.FirstOrDefault(rec => rec.ResourseName ==
           model.ResourseName && rec.ResourseId != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть ресурс с таким названием");
            }
            element = context.Resourses.FirstOrDefault(rec => rec.ResourseId == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ResourseName = model.ResourseName;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Resourse element = context.Resourses.FirstOrDefault(rec => rec.ResourseId == id);
            if (element != null)
            {
                context.Resourses.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
