using BeautyModel;
using BeautyServiceDAL.BindingModels;
using BeautyServiceDAL.Interfaces;
using BeautyServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceImplementDB.Implementations
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
            List<SkladViewModel> result = source.Sklads
            .Select(rec => new SkladViewModel
            {
                SkladId = rec.SkladId,
                SkladName = rec.SkladName,
                SkladResourses = source.SkladResourses
            .Where(recPC => recPC.SkladId == rec.SkladId)
           .Select(recPC => new SkladResourseViewModel
           {
               SkladResourseId = recPC.SkladResourseId,
               SkladId = recPC.SkladId,
               ResourseId = recPC.ResourseId,
               ResourseName = source.Resourses
            .FirstOrDefault(recC => recC.ResourseId ==
           recPC.ResourseId)?.ResourseName,
               Count = recPC.Count
           })
           .ToList()
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
                    SkladName = element.SkladName,
                    SkladResourses = source.SkladResourses
                .Where(recPC => recPC.SkladId == element.SkladId)
               .Select(recPC => new SkladResourseViewModel
               {
                   SkladResourseId = recPC.SkladResourseId,
                   SkladId = recPC.SkladId,
                   ResourseId = recPC.ResourseId,
                   ResourseName = source.Resourses
                .FirstOrDefault(recC => recC.ResourseId ==
               recPC.ResourseId)?.ResourseName,
                   Count = recPC.Count
               })
               .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(SkladBindingModel model)
        {
            Sklad element = source.Sklads.FirstOrDefault(rec => rec.SkladName ==
            model.SkladName);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            int maxId = source.Sklads.Count > 0 ? source.Sklads.Max(rec => rec.SkladId) : 0;
            source.Sklads.Add(new Sklad
            {
                SkladId = maxId + 1,
                SkladName = model.SkladName
            });
        }
        public void UpdElement(SkladBindingModel model)
        {
            Sklad element = source.Sklads.FirstOrDefault(rec =>
            rec.SkladName == model.SkladName && rec.SkladId !=
           model.SkladId);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
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
                // при удалении удаляем все записи о компонентах на удаляемом складе
                source.SkladResourses.RemoveAll(rec => rec.SkladId == id);
                source.Sklads.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
