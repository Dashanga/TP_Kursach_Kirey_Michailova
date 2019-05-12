using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.ViewModel
{
    public class ServiceResourseViewModel
    {
        public int ServiceResourseId { get; set; }
        public int ServiceId { get; set; }
        public int ResourseId { get; set; }
        [DisplayName("Ресурс")]
        public string ResourseName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
