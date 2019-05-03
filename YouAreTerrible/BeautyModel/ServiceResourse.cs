using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyModel
{
    public class ServiceResourse
    {
        public int ServiceResourseId { get; set; }
        public int ServiceId { get; set; }
        public int ResourseId { get; set; }
        public int Count { get; set; }
        //public virtual Resourse Resourse { get; set; }
    }
}
