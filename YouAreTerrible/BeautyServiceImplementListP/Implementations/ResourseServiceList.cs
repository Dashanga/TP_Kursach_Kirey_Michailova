using BeautyModel;
using BeautyServiceDAL_P.BindingModels;
using BeautyServiceDAL_P.Interfaces;
using BeautyServiceDAL_P.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceImplementListP.Implementations
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
                Id = rec.ResourseId,
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
                    Id = element.ResourseId,
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
            == model.ResourseName && rec.ResourseId != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть ресурс с таким названием");
            }
            element = source.Resourses.FirstOrDefault(rec => rec.ResourseId == model.Id);
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
