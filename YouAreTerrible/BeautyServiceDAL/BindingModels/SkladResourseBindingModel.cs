using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL.BindingModels
{
    public class SkladResourseBindingModel
    {
        public int SkladResourseId { get; set; }
        public int SkladId { get; set; }
        public int ResourseId { get; set; }
        public int Count { get; set; }
    }
}
