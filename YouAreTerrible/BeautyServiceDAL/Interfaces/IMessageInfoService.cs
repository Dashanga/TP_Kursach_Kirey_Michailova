using BeautyServiceDAL.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyServiceDAL.Interfaces
{
    public interface IMessageInfoService
    {
        void AddElement(MessageInfoBindingModel model);
    }
}
