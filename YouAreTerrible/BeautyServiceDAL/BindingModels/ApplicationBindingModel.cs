using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL.BindingModels
{
    public class ApplicationBindingModel
    {
        public int ApplicationId { get; set; }
        public int ResourseId { get; set; }
        public int Count { get; set; }
        public decimal Summa { get; set; }
    }
}
