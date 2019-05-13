using BeautyServiceDAL.BindingModels;
using BeautyServiceDAL.ViewModels;
using System;
using System.Collections.Generic;

namespace BeautyServiceDAL.Interfaces
{
    public interface IResourseService
    {
        List<ResourseViewModel> GetList();
        ResourseViewModel GetElement(int id);
        void AddElement(ResourseBindingModel model);
        void UpdElement(ResourseBindingModel model);
        void DelElement(int id);

    }
}
