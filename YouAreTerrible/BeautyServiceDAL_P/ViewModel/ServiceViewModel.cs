using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.ViewModel
{
    public class ServiceViewModel
    {
        public int ServiceId { get; set; }
        [DisplayName("Название услуги")]
        public string ServiceName { get; set; }
        [DisplayName("Цена")]
        public decimal ServicePrice { get; set; }
        public List<ServiceResourseViewModel> ServiceResourses { get; set; }
    }
}
