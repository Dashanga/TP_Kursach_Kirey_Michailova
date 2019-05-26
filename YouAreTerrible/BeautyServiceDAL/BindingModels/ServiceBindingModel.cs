using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL.BindingModels
{
    public class ServiceBindingModel
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public List<ServiceResourseBindingModel> ServiceResourses { get; set; }
    }
}
