using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.ViewModel
{
    public class ApplicationViewModel
    {
        public int ApplicationId { get; set; }
        public int ResourseId { get; set; }
        [DisplayName("Ресурс")]
        public string ResourseName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        public decimal Summa { get; set; }
        [DisplayName("Статус")]
        public string Status { get; set; }
        [DisplayName("Дата создания")]
        public string DateCreate { get; set; }
        [DisplayName("Дата выполнения")]
        public string DateImplement { get; set; }
    }
}
