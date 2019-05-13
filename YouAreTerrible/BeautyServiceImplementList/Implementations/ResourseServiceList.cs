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
    public class ResourseServiceList : IResourseService
    {
        private DataListSingleton source;
        public ResourseServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<ResourseViewModel> GetList()
        {
            List<ResourseViewModel> result = new List<ResourseViewModel>();
            for (int i = 0; i < source.Resourses.Count; ++i)
            {
                result.Add(new ResourseViewModel
                {
                    ResourseId = source.Resourses[i].ResourseId,
                    ResoursePrice = source.Resourses[i].ResoursePrice,
                    ResourseName = source.Resourses[i].ResourseName

                });
            }
            return result;
        }
        public ResourseViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Resourses.Count; ++i)
            {
                if (source.Resourses[i].ResourseId == id)
                {
                    return new ResourseViewModel
                    {
                        ResourseId = source.Resourses[i].ResourseId,
                        ResourseName = source.Resourses[i].ResourseName,
                        ResoursePrice = source.Resourses[i].ResoursePrice
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(ResourseBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Resourses.Count; ++i)
            {
                if (source.Resourses[i].ResourseId > maxId)
                {
                    maxId = source.Resourses[i].ResourseId;
                }
                if (source.Resourses[i].ResourseName == model.ResourseName)
                {
                    throw new Exception("Уже есть ресурс с таким названием");
                }
            }
            source.Resourses.Add(new Resourse
            {
                ResourseId = maxId + 1,
                ResourseName = model.ResourseName,
                ResoursePrice = model.ResoursePrice
            });
        }
        public void UpdElement(ResourseBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Resourses.Count; ++i)
            {
                if (source.Resourses[i].ResourseId == model.ResourseId)
                {
                    index = i;
                }
                if (source.Resourses[i].ResourseName == model.ResourseName &&
                source.Resourses[i].ResourseId != model.ResourseId)
                {
                    throw new Exception("Уже есть ресурс с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Resourses[index].ResourseName = model.ResourseName;
            source.Resourses[index].ResoursePrice = model.ResoursePrice;
        }
        public void DelElement(int id)
        {
            for (int i = 0; i < source.Resourses.Count; ++i)
            {
                if (source.Resourses[i].ResourseId == id)
                {
                    source.Resourses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
