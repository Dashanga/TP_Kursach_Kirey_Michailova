using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyModel
{
    public class SkladResourse
    {
        public int SkladResourseId { get; set; }
        public int SkladId { get; set; }
        public int ResourseId { get; set; }
        public int Count { get; set; }
        public virtual Resourse Resourse { get; set; }
        public virtual Sklad Sklad { get; set; }
    }
}
