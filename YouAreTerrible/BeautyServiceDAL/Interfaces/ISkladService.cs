using BeautyServiceDAL.BindingModels;
using BeautyServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL.Interfaces
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
