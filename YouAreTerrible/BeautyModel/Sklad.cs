using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyModel
{
    public class Sklad
    {
        public int SkladId { get; set; }
        public string SkladName { get; set; }
        public virtual List<SkladResourse> SkladResourses { get; set; }
    }
}
