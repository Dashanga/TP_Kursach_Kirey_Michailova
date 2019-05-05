using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.BindingModels
{
   public  class ServiceResourseBindingModel
    {
        public int ServiceResourseId { get; set; }
        public int ServiceId { get; set; }
        public int ResourseId { get; set; }
        public int Count { get; set; }
    }
}
