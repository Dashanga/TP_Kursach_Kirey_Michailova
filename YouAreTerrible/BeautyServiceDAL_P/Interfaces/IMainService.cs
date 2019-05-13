using System;
using System.Collections.Generic;
using BeautyServiceDAL_P.BindingModels;
using BeautyServiceDAL_P.ViewModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.Interfaces
{
    public interface IMainService
    {
        List<ApplicationViewModel> GetList();
        void CreateApplication(ApplicationBindingModel model);
        void SendApplication(ApplicationBindingModel model);
        void FinishApplication(ApplicationBindingModel model);
        //void PutResourseOnSklad(SkladResourseBindingModel model);
    }
}
