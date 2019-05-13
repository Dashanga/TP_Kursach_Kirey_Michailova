using System;
using System.Collections.Generic;
using BeautyServiceDAL_P.BindingModels;
using BeautyServiceDAL_P.ViewModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.Interfaces
{
    public interface ISkladService
    {
        List<SkladViewModel> GetList();
        SkladViewModel GetElement(int id);
        void AddElement(SkladBindingModel model);
        void UpdElement(SkladBindingModel model);
        void DelElement(int id);
    }
}
