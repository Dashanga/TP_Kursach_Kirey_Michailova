using BeautyModel;
using BeautyServiceDAL_P.Interfaces;
using BeautyServiceDAL_P.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceImplementDataBase.Implementations
{
    public class ProviderServiceDB : IProviderService
    {
        private BeautyDbContext context;
        public ProviderServiceDB(BeautyDbContext context)
        {
            this.context = context;
        }
        public List<ProviderViewModel> GetList()
        {
            List<ProviderViewModel> result = context.Providers.Select(rec => new
           ProviderViewModel
            {
                ProviderId = rec.ProviderId,
                ProviderName = rec.ProviderName,
                ProviderSurname = rec.ProviderSurname,
                ProviderPatronymic = rec.ProviderPatronymic,
                Mail = rec.Mail,
                Password = rec.Password
            })
            .ToList();
            return result;
        }
        public Boolean ProviderExist (String mail, String password)
        {
            Provider element = context.Providers.FirstOrDefault(rec => rec.Password ==
           password && rec.Mail == mail);
            if (element != null)
            {
                return true;
            }
            else
            {
                throw new Exception("Неверный логин или пароль");
            }
        }
    }
}
