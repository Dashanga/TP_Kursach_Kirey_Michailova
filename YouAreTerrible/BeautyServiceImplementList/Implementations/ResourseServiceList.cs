using BeautyModel;
using BeautyServiceDAL.BindingModels;
using BeautyServiceDAL.Interfaces;
using BeautyServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeautyServiceImplementList.Implementations
{
    public class ResourseServiceList : IResourseService
    {
        private DataListSingleton source;
        public ResourseServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<ResourseViewModel> GetList()
        {
            List<ResourseViewModel> result = source.Resourses.Select(rec => new
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
            Resourse element = source.Resourses.FirstOrDefault(rec => rec.ResourseId == id);
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
            Resourse element = source.Resourses.FirstOrDefault(rec => rec.ResourseName
            == model.ResourseName);
            if (element != null)
            {
                throw new Exception("Уже есть ресурс с таким названием");
            }
            int maxId = source.Resourses.Count > 0 ? source.Resourses.Max(rec =>
           rec.ResourseId) : 0;
            source.Resourses.Add(new Resourse
            {
                ResourseId = maxId + 1,
                ResourseName = model.ResourseName,
                ResoursePrice = model.ResoursePrice
            });
        }
        public void UpdElement(ResourseBindingModel model)
        {
            Resourse element = source.Resourses.FirstOrDefault(rec => rec.ResourseName
            == model.ResourseName && rec.ResourseId != model.ResourseId);
            if (element != null)
            {
                throw new Exception("Уже есть ресурс с таким названием");
            }
            element = source.Resourses.FirstOrDefault(rec => rec.ResourseId == model.ResourseId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ResourseName = model.ResourseName;
            element.ResoursePrice = model.ResoursePrice;
        }
        public void DelElement(int id)
        {
            Resourse element = source.Resourses.FirstOrDefault(rec => rec.ResourseId == id);
            if (element != null)
            {
                source.Resourses.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
