using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.BindingModels
{
    public class ApplicationResourseBindingModel
    {
        public int ApplicationResourseId { get; set; }
        public int ApplicationId { get; set; }
        public int ResourseId { get; set; }
    }
}
