using BeautyServiceDAL_P.BindingModels;
using BeautyServiceDAL_P.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.Interfaces
{
    interface IReportService
    {
        List<MovementResourseViewModel> GetMovementResourses(ReportBindingModel model);
        void SaveMovementResourses(ReportBindingModel model);
    }
}
