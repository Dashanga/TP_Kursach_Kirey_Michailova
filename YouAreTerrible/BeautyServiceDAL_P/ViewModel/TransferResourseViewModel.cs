using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.ViewModel
{
    public class TransferResourseViewModel
    {
        public string ResourseId { get; set; }
        public string ResourseName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string DateTransfer { get; set; }
    }
}
