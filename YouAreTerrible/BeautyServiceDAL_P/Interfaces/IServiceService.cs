using System;
using System.Collections.Generic;
using BeautyServiceDAL_P.BindingModels;
using BeautyServiceDAL_P.ViewModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.Interfaces
{
    public interface IServiceService
    {
        List<ServiceViewModel> GetList();
        ServiceViewModel GetElement(int id);
        void AddElement(ServiceBindingModel model);
        void UpdElement(ServiceBindingModel model);
        void DelElement(int id);
    }
}
