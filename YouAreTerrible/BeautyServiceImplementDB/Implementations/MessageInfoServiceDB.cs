using BeautyModel;
using BeautyServiceDAL.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BeautyServiceImplementDB.Implementations
{
    public class MessageInfoServiceDB
    {
        private BeautyDbContext context;
        public MessageInfoServiceDB(BeautyDbContext context)
        {
            this.context = context;
        }
        public void AddElement(MessageInfoBindingModel model)
        {
            MessageInfo element = context.MessageInfos.FirstOrDefault(rec =>
            rec.MessageId == model.MessageId);
            if (element != null)
            {
                return;
            }
            var message = new MessageInfo
            {
                MessageId = model.MessageId,
                FromMailAddress = model.FromMailAddress,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body
            };
            var mailAddress = "kireytatyana@yandex.ru";
            //if (mailAddress.Success)
            //{
                var client = context.Providers.FirstOrDefault(rec => rec.Mail ==
               mailAddress);
                if (client != null)
                {
                    message.ProviderId = client.ProviderId;
                }
           // }
            context.MessageInfos.Add(message);
            context.SaveChanges();
        }
    }
}

