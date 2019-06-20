using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyModel
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public int ResourseId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public ApplicationStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Resourse Resourse { get; set; }
    }
}
