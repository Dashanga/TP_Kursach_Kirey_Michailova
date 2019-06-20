using BeautyModel;
using BeautyServiceDAL.BindingModels;
using BeautyServiceDAL.Interfaces;
using BeautyServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceImplementDB.Implementations
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
                ResourseId = rec.ResourseId,
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
                    ResourseId = element.ResourseId,
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
                throw new Exception("Уже есть компонент с таким названием");
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
            model.ResourseName && rec.ResourseId != model.ResourseId);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            element = context.Resourses.FirstOrDefault(rec => rec.ResourseId == model.ResourseId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ResourseName = model.ResourseName;
            element.ResoursePrice = model.ResoursePrice;
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