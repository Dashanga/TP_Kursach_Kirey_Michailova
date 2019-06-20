using BeautyServiceDAL_P.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL_P.Interfaces
{
    public interface IProviderService
    {
        List<ProviderViewModel> GetList();
        Boolean ProviderExist(String mail, String password);
    }
}
