using System;
using System.Collections.Generic;
using BeautyServiceDAL_P.BindingModels;
using BeautyServiceDAL_P.ViewModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.Interfaces
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
