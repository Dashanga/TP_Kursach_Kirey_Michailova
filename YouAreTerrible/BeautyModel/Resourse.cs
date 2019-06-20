using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyModel
{
    public class Resourse
    {
        public int ResourseId { get; set; }
        public string ResourseName { get; set; }
        public decimal ResoursePrice { get; set; }
        public virtual List<ServiceResourse> ServiceResourses { get; set; }
        public virtual List<SkladResourse> SkladResourses { get; set; }
    }
}
