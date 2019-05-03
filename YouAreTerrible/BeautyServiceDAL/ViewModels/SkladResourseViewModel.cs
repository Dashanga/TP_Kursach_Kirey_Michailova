using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL.ViewModels
{
    public class SkladResourseViewModel
    {
        public int SkladResourseId { get; set; }
        public int SkladId { get; set; }
        public int ResourseId { get; set; }
        [DisplayName("Название ресурса")]
        public string ResourseName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
