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
        void CreateApplication(ApplicationBindingModel model);
        void SendApplication(ApplicationBindingModel model);
        void FinishApplication(ApplicationBindingModel model);
        bool ApplicationFinished(ApplicationBindingModel model);
    }
}
