using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.BindingModels
{
    public class ServiceBindingModel
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public decimal ServicePrice { get; set; }
        public List<ServiceResourseBindingModel> ServiceResourses { get; set; }
    }
}
