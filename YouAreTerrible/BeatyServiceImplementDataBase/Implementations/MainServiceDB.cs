using BeautyModel;
using BeautyServiceDAL_P.BindingModels;
using BeautyServiceDAL_P.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceImplementDataBase.Implementations
{
    public class MainServiceDB : IMainService
    {
        private BeautyDbContext context;
        public MainServiceDB(BeautyDbContext context)
        {
            this.context = context;
        }

        public void PutResourseOnSklad(SkladResourseBindingModel model)
        {
            SkladResourse element = context.SkladResourses.FirstOrDefault(rec =>
           rec.SkladId == model.SkladId && rec.ResourseId == model.ResourseId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.SkladResourses.Add(new SkladResourse
                {
                    SkladId = model.SkladId,
                    ResourseId = model.ResourseId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }
    }
}
