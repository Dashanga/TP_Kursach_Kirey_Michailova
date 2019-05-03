using BeautyServiceDAL.BindingModels;
using BeautyServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL.Interfaces
{
    public interface IMainService
    {
        List<ApplicationViewModel> GetList();
        void CreateOrder(ApplicationBindingModel model);
        void SendOrder(ApplicationBindingModel model);
        void FinishOrder(ApplicationBindingModel model);
        void PutResourseOnSklad(SkladResourseBindingModel model);
    }
}
