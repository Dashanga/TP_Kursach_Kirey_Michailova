using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.ViewModel
{
    public class SkladViewModel
    {
        public int SkladId { get; set; }
        [DisplayName("Название магазина")]
        public string SkladName { get; set; }
        public List<SkladResourseViewModel> SkladResourses { get; set; }
    }
}
