using System;
using BeautyModel;
using BeautyServiceDAL_P.BindingModels;
using BeautyServiceDAL_P.Interfaces;
using BeautyServiceDAL_P.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceImplementListP.Implementations
{
    public class SkladServiceList : ISkladService
    {
        private DataListSingleton source;
        public SkladServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<SkladViewModel> GetList()
        {
            List<SkladViewModel> result = source.Sklads.Select(rec => new
            SkladViewModel
            {
                SkladId = rec.SkladId,
                SkladName = rec.SkladName
            })
            .ToList();
            return result;
        }
        public SkladViewModel GetElement(int id)
        {
            Sklad element = source.Sklads.FirstOrDefault(rec => rec.SkladId == id);
            if (element != null)
            {
                return new SkladViewModel
                {
                    SkladId = element.SkladId,
                    SkladName = element.SkladName
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(SkladBindingModel model)
        {
            Sklad element = source.Sklads.FirstOrDefault(rec => rec.SkladName
            == model.SkladName);
            if (element != null)
            {
                throw new Exception("Уже есть ресурс с таким названием");
            }
            int maxId = source.Sklads.Count > 0 ? source.Sklads.Max(rec =>
           rec.SkladId) : 0;
            source.Sklads.Add(new Sklad
            {
                SkladId = maxId + 1,
                SkladName = model.SkladName
            });
        }
        public void UpdElement(SkladBindingModel model)
        {
            Sklad element = source.Sklads.FirstOrDefault(rec => rec.SkladName
            == model.SkladName && rec.SkladId != model.SkladId);
            if (element != null)
            {
                throw new Exception("Уже есть ресурс с таким названием");
            }
            element = source.Sklads.FirstOrDefault(rec => rec.SkladId == model.SkladId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.SkladName = model.SkladName;
        }

        public void DelElement(int id)
        {
            Sklad element = source.Sklads.FirstOrDefault(rec => rec.SkladId == id);
            if (element != null)
            {
                source.Sklads.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
