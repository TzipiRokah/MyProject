using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;

namespace Dal
{
    public class MessageDal
    {     

        public static List<Message> GetAllMessage()
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.Message.ToList();
            }

        }

        public static List<Message> AddMessage(Message m)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                DB.Message.Add(m);
                DB.SaveChanges();
                return DB.Message.ToList();
            }
        }

        public static List<Message> GmailMessage(string UserGmail, string subject, string body)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"]);
                    mail.From = new MailAddress(ConfigurationManager.AppSettings["MyMail"], ConfigurationManager.AppSettings["MailName"]);
                    mail.To.Add(UserGmail);
                    mail.IsBodyHtml = true;
                    mail.Subject = subject;
                    mail.Body = body;

                    SmtpServer.EnableSsl = true;
                    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                    SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["MyMail"],
                    ConfigurationManager.AppSettings["MailPassword"]);
                    
                    SmtpServer.Send(mail);

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }


                return DB.Message.ToList();
            }
        }

        public static List<Message> MailToManager(string subject, string body)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"]);
                    mail.From = new MailAddress(ConfigurationManager.AppSettings["MyMail"], ConfigurationManager.AppSettings["MailName"]);
                    mail.To.Add(ConfigurationManager.AppSettings["MyMail"]);
                    mail.IsBodyHtml = true;
                    mail.Subject = subject;
                    mail.Body = body;

                    SmtpServer.EnableSsl = true;
                    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                    SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["MyMail"],
                    ConfigurationManager.AppSettings["MailPassword"]);

                    SmtpServer.Send(mail);

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }


                return DB.Message.ToList();
            }
        }
    }
}
