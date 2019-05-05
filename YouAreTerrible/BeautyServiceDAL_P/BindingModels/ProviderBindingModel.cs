using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.BindingModels
{
    public class ProviderBindingModel
    {
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderSurname { get; set; }
        public string ProviderPatronymic { get; set; }
    }
}
