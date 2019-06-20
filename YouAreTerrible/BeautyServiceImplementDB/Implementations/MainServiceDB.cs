using BeautyModel;
using BeautyServiceDAL.BindingModels;
using BeautyServiceDAL.Interfaces;
using BeautyServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net.Mail;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BeautyServiceImplementDB.Implementations
{
    public class MainServiceDB : IMainService
    {
        private BeautyDbContext context;
        public MainServiceDB(BeautyDbContext context)
        {
             this.context = context;
        }
        public List<ApplicationViewModel> GetList()
        {
            List<ApplicationViewModel> result = context.Applications.Select(rec => new ApplicationViewModel
            {
                ApplicationId = rec.ApplicationId,
                ResourseId = rec.ResourseId,
                Count = rec.Count,
                Summa = rec.Sum,
                Status = rec.Status.ToString(),
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
            SqlFunctions.DateName("mm", rec.DateCreate) + " " +
            SqlFunctions.DateName("yyyy", rec.DateCreate),
                DateImplement = rec.DateImplement == null ? "" :
            SqlFunctions.DateName("dd",
            rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("mm",
            rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("yyyy",
            rec.DateImplement.Value)
            })
            .ToList();
            return result;
        }
        public void CreateApplication(ApplicationBindingModel model)
        {
            context.Applications.Add(new Application
            {
                DateCreate = DateTime.Now,
                ResourseId = model.ResourseId,
                Count = model.Count,
                Sum = model.Summa,
                Status = ApplicationStatus.Создана
            });
            context.SaveChanges();
        }
        public void SendApplication(ApplicationBindingModel model)
        {
            Application element = context.Applications.FirstOrDefault(rec => rec.ApplicationId == model.ApplicationId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != ApplicationStatus.Создана)
            {
                throw new Exception("Заявка не в статусе \"Создана\"");
            }
            //код отправка по почте
            SendEmail(element.Provider.Mail, "Оповещение по заказам",
                    string.Format("Заказ №{0} от {1} передеан в работу"));


            element.Status = ApplicationStatus.Отправлена;
            context.SaveChanges();
        }
        public bool ApplicationFinished(ApplicationBindingModel model)
        {
            Application element = context.Applications.FirstOrDefault(rec => rec.ApplicationId == model.ApplicationId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != ApplicationStatus.Отправлена)
            {
                throw new Exception("Заявка не в статусе \"Отправлена\"");
            }
            //if (код проверки выполнена ли)
            //{
            //    return true;
            //}
            return false;
        }
        public void FinishApplication(ApplicationBindingModel model)
        {
            Application element = context.Applications.FirstOrDefault(rec => rec.ApplicationId == model.ApplicationId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != ApplicationStatus.Отправлена)
            {
                throw new Exception("Заявка не в статусе \"Отправлена\"");
            }
            if (ApplicationFinished(model) != true)
            {
                throw new Exception("Заявка ещё не выполнена");
            }
            element.DateImplement = DateTime.Now;
            element.Status = ApplicationStatus.Выполнена;
            context.SaveChanges();
        }
        private void SendEmail(string mailAddress, string subject, string text)
        {
            MailMessage objMailMessage = new MailMessage();
            SmtpClient objSmtpClient = null;
            try
            {
                objMailMessage.From = new
                MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                objMailMessage.To.Add(new MailAddress(mailAddress));
                objMailMessage.Subject = subject;
                objMailMessage.Body = text;
                objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                objSmtpClient = new SmtpClient("smtp.gmail.com", 587);
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.EnableSsl = true;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpClient.Credentials = new
               NetworkCredential(ConfigurationManager.AppSettings["MailLogin"],
               ConfigurationManager.AppSettings["MailPassword"]);
                objSmtpClient.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMailMessage = null;
                objSmtpClient = null;
            }
        }
    }
}
