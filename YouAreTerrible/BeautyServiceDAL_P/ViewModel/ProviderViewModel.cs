using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.ViewModel
{
    public class ProviderViewModel
    {
        public int ProviderId { get; set; }
        [DisplayName("Имя поставщика")]
        public string ProviderName { get; set; }
        [DisplayName("Фамилия поставщика")]
        public string ProviderSurname { get; set; }
        [DisplayName("Отчество поставщика")]
        public string ProviderPatronymic { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
