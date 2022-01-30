using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Dal;

namespace Bll
{
    public class MessageBll
    {
        public static List<MessageDTO> GetAllMessage()
        {
            return MessageDTO.ConvertMessageToDTO(MessageDal.GetAllMessage());
        }

        public static List<MessageDTO> AddMessage(MessageDTO m)
        {
            return MessageDTO.ConvertMessageToDTO(MessageDal.AddMessage(MessageDTO.ConvertDTOToMessage(m)));
        }

        public static List<MessageDTO> GmailMessage(string UserGmail, string subject, string body)
        {
            return MessageDTO.ConvertMessageToDTO(MessageDal.GmailMessage(UserGmail,subject,body));
        }

        public static string MailMessageToManager(string UserName,string UserGmail, string subject, string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString());
            sb.AppendLine("מייל מאת ");
            sb.AppendLine("שם לקוח "+UserName);
            sb.AppendLine("כתובת מייל "+UserGmail);
            sb.AppendLine("נושא ההודעה "+subject);
            sb.AppendLine("גוף ההודעה: "+message);
            string body = sb.ToString();
            return body;
        }

        public static string NewsletterMail()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString());
            sb.AppendLine("לקוח יקר, שלום וברכה, תודה רבה שהצטרפת לניוזלטר שלנו!!!");
            sb.AppendLine("נשמח לספק לך את מקסימום החוויה בפארק שלנו. ");
            sb.AppendLine("תודה רבה, צוות לונה פארק ישראל");
            string body = sb.ToString();
            return body;
        }

        public static List<MessageDTO> Newsletter(string UserGmail)
        {
            return MessageDTO.ConvertMessageToDTO(MessageDal.GmailMessage(UserGmail,"רישום לקבלת העדכונים שלנו",NewsletterMail()));
        }

        public static List<MessageDTO> MailToManager(string UserName, string UserGmail, string subject, string message)
        {
            return MessageDTO.ConvertMessageToDTO(MessageDal.MailToManager(subject, MailMessageToManager(UserName,UserGmail,subject,message)));
        }
    }
}
