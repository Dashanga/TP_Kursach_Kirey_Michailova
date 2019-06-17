using BeautyModel;
using BeautyServiceDAL_P.BindingModels;
using BeautyServiceDAL_P.Interfaces;
using BeautyServiceDAL_P.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceImplementDataBase.Implementations
{
    public class SkladServiceDB : ISkladService
    {
        private BeautyDbContext context;
        public SkladServiceDB(BeautyDbContext context)
        {
            this.context = context;
        }
        public List<SkladViewModel> GetList()
        {
            List<SkladViewModel> result = context.Sklads.Select(rec => new
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
            Sklad element = context.Sklads.FirstOrDefault(rec => rec.SkladId == id);
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
            Sklad element = context.Sklads.FirstOrDefault(rec => rec.SkladName ==
           model.SkladName);
            if (element != null)
            {
                throw new Exception("Уже есть магазин с таким названием");
            }
            context.Sklads.Add(new Sklad
            {
                SkladName = model.SkladName
            });
            context.SaveChanges();
        }
        public void UpdElement(SkladBindingModel model)
        {
            Sklad element = context.Sklads.FirstOrDefault(rec => rec.SkladName ==
           model.SkladName && rec.SkladId != model.SkladId);
            if (element != null)
            {
                throw new Exception("Уже есть магазин с таким названием");
            }
            element = context.Sklads.FirstOrDefault(rec => rec.SkladId == model.SkladId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.SkladName = model.SkladName;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Sklad element = context.Sklads.FirstOrDefault(rec => rec.SkladId == id);
            if (element != null)
            {
                context.Sklads.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
    
}
