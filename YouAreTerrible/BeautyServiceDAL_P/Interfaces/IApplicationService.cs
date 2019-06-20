using BeautyServiceDAL_P.BindingModels;
using BeautyServiceDAL_P.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.Interfaces
{
    public interface IApplicationService
    {
        List<ApplicationViewModel> GetList();
        void TakeApplicationInWork(ApplicationBindingModel model);
    }
}
