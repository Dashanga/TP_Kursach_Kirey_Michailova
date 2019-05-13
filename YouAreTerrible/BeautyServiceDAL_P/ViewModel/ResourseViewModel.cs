using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.ViewModel
{
    public class ResourseViewModel
    {
        public int ResourseId { get; set; }
        [DisplayName("Название ресурса")]
        public string ResourseName { get; set; }
        [DisplayName("Цена")]
        public decimal ResoursePrice { get; set; }
    }
}
