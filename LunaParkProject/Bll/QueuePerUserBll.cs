using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using DTO;

namespace Bll
{
    public class QueuePerUserBll
    {
        public static List<QueuePerUserDTO> GetAllQueuePerUser()
        {
            return QueuePerUserDTO.ConvertQueuePerUserToDTO(QueuePerUserDal.GetAllQueuePerUser());
        }

        public static List<QueuePerUserDTO> GetQueuePerUserByUserId(int UserId)
        {
            return QueuePerUserDTO.ConvertQueuePerUserToDTO(QueuePerUserDal.GetQueuesByUserId(UserId));
        }

        public static QueuePerUserDTO GetQueuePerUserById(int id)
        {
            return new QueuePerUserDTO(QueuePerUserDal.GetQueuePerUserById(id));
        }

        public static QueuePerUserDTO GetQueuePerUserByIdRevers(int id)
        {
            return new QueuePerUserDTO(QueuePerUserDal.GetQueuePerUserByQueueIdRevers(id));
        }

        //פונקציות לוגיות לחישוב מצב שבו המשתמש רוכש שתי אטרקציות בשעה זהה
        //public static QueuesDTO GetIfSameHour(int UserId, int AttractionId)
        //{
        //    int i;
        //    UsersDTO u = UsersBll.GetUserById(UserId);
        //    List<QueuesDTO> list = QueuesBll.GetQueuesByAttractionId(AttractionId).ToList();
        //    for (i = 0; i < list.Count() && list[i].MaxPeopleInAttraction >= u.UsersCount; i++) ;
        //    if (i <= list.Count)
        //        return list[i];
        //    return null;
        //}

        //public static QueuesDTO GetCorrectQueue(int UserId, int AttractionId, DateTime time)
        //{
        //    int i;
        //    List<QueuePerUserDTO> l = QueuePerUserDTO.ConvertQueuePerUserToDTO(QueuePerUserDal.GetQueuesByUserId(UserId, time));
        //    for (i = 0; i < l.Count(); i++)
        //    {
        //        var q = QueuesBll.GetQueuesById(l[i].QueueId);
        //        if (q.Hour == time)
        //        {
        //            break;
        //        }
        //    }
        //    if (i > l.Count())
        //        return null;
        //    else
        //    {
        //        QueuesDTO queue= GetIfSameHour(UserId, AttractionId);
        //        return GetCorrectQueue(UserId, AttractionId, queue.Hour);
        //    }
        //}

        public static AttractionDTO GetCorrectQueue(int UserId, int AttractionId, int Tickets, DateTime StartTime)
        {
            int i;
            AttractionDTO DoubleAttr = new AttractionDTO();
            AttractionDTO a = AttractionBll.GetAllAttractionById(AttractionId);
            UsersDTO u = UsersBll.GetUserById(UserId);
            List<QueuePerUserDTO> l = GetQueuePerUserByUserId(UserId);
            int SumTime = a.AttractionTime + a.AttractionTimeOUt;
            DateTime EndTime = StartTime.AddMinutes(SumTime);
            for (i = 0; i < l.Count() && Tickets <= u.UsersCount; i++)
            {
                    //l[i].CountTickets
                    QueuesDTO q = QueuesBll.GetQueuesById(l[i].QueueId);
                    DoubleAttr = AttractionBll.GetAllAttractionById(q.AttractionId);
                    DateTime temp = q.Hour.AddMinutes(DoubleAttr.AttractionTime + DoubleAttr.AttractionTimeOUt);
                    if (temp >= StartTime && q.Hour <= StartTime || EndTime >= q.Hour && StartTime <= q.Hour)
                        u.UsersCount -= l[i].CountTickets;
            }
            if (u.UsersCount<Tickets && l.Count!=0)
                return DoubleAttr;
            return null;
        }

        public static List<QueuePerUserDTO> UpdateQueuePerUser(int QueuePerUserId, QueuePerUserDTO queuesDTO)
        {
            return QueuePerUserDTO.ConvertQueuePerUserToDTO(QueuePerUserDal.UpdateQueuePerUser(QueuePerUserId, QueuePerUserDTO.ConvertDTOToQueuePerUser(queuesDTO)));
        }

        public static List<QueuePerUserDTO> AddQueuePerUser(QueuePerUserDTO q)
        {
            List<QueuePerUserDTO> l = GetAllQueuePerUser();
            QueuePerUserDTO queue = l.FirstOrDefault(x => x.QueueId == q.QueueId && x.UserId == q.UserId);
            if (queue != null)
            {
                q.CountTickets+=queue.CountTickets;
                return UpdateQueuePerUser(queue.QueuePerUserId, q);
            }
            else
                return QueuePerUserDTO.ConvertQueuePerUserToDTO(QueuePerUserDal.AddQueuePerUser(QueuePerUserDTO.ConvertDTOToQueuePerUser(q)));
        }

        public static List<QueuePerUserDTO> RemoveQueuePerUser(QueuePerUserDTO q)
        {
            List<QueuePerUserDTO> l = GetAllQueuePerUser();
            QueuePerUserDTO queue = l.FirstOrDefault(x => x.QueueId == q.QueueId && x.UserId == q.UserId);
            if (queue != null)
            {
                if (q.CountTickets == queue.CountTickets)
                    return QueuePerUserDTO.ConvertQueuePerUserToDTO(QueuePerUserDal.RemoveQueuePerUser(QueuePerUserDTO.ConvertDTOToQueuePerUser(q)));
                else
                {
                    queue.CountTickets -= q.CountTickets;
                    return UpdateQueuePerUser(queue.QueuePerUserId, queue);
                }
            }
            else
                return QueuePerUserDTO.ConvertQueuePerUserToDTO(QueuePerUserDal.RemoveQueuePerUser(QueuePerUserDTO.ConvertDTOToQueuePerUser(q)));
        }

        public static string DelayMail(string AttractionName, DateTime Hour)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("לקוח יקר, שלום וברכה, אנו מודיעים לך על עיכוב תורך לאטרקציה");
            sb.AppendLine(AttractionName);
            sb.AppendLine("בשעה ");
            sb.AppendLine(Hour.ToLongTimeString()+" "+Hour.ToLongDateString());
            sb.AppendLine("נבקש ממך לשנות את תורך ולהופיע בשעה אחרת. ");
            sb.AppendLine("תודה רבה");
            string body = sb.ToString();
            return body;
        }

        public static string MalfunctionMail(string AttractionName, DateTime Hour)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("לקוח יקר, שלום וברכה, לצערנו נתקלנו בתקלה באטרקציה שרכשת לה כרטיס ");
            sb.AppendLine(AttractionName);
            sb.AppendLine("בשעה ");
            sb.AppendLine(Hour.ToLongTimeString() + " " + Hour.ToLongDateString());
            sb.AppendLine("אנו מתנצלים על אי הנוחות, נשמח לזכות אותך בתור נוסף לפעם אחרת. ");
            sb.AppendLine("עמכם הסליחה");
            string body = sb.ToString();
            return body;
        }

        public static string MessageToLostTicketMail(string AttractionName, DateTime Hour)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("לקוח יקר, שלום וברכה, לצערנו נתקלנו בתקלה באטרקציה שרכשת לה כרטיס ");
            sb.AppendLine(AttractionName);
            sb.AppendLine("בשעה ");
            sb.AppendLine(Hour.ToLongTimeString() + " " + Hour.ToLongDateString());
            sb.AppendLine("אנו מתנצלים על אי הנוחות, נשמח לזכות אותך בתור נוסף להיום. נא הזמן תור חדש. ");
            sb.AppendLine("עמכם הסליחה");
            string body = sb.ToString();
            return body;
        }

        public static List<QueuePerUserDTO> DelayQueue(DateTime DelayTime, int AttractionId)
        {
            AttractionDTO a = new AttractionDTO(AttractionDal.GetAllAttractionById(AttractionId));
            QueuesDTO q = new QueuesDTO(QueuesDal.GetQueuesByAttractionIdAndHour(DelayTime, AttractionId,a.AttractionTime));
            List<QueuePerUserDTO> l = QueuePerUserDTO.ConvertQueuePerUserToDTO(QueuePerUserDal.GetQueuePerUserByQueueId(q.QueueId));
            foreach (var item in l)
            {              
                UsersDTO u = UsersBll.GetUserById(item.UserId);
                MessageBll.GmailMessage(u.UserGmail, "הודעה על עיכוב תורך", DelayMail(a.AttractionName,q.Hour));
            }
            //איפוס התור לאפס כרטיסים מאחר והוא לא בשימוש
            q.MaxPeopleInAttraction = 0;
            q.QueueStatus = 3;
            QueuesBll.UpdateQueue(q);
            return l;
        }

        public static List<QueuePerUserDTO> MalfunctionQueues(DateTime MalfunctionTime, int AttractionId)
        {
            AttractionDTO a = new AttractionDTO(AttractionDal.GetAllAttractionById(AttractionId));
            //עדכון סטטוס המתקן ל2 סימון תקלה
            a.AttractionIfActive = 2;
            AttractionBll.UpdateAttraction(a);
            QueuesDTO q = new QueuesDTO(QueuesDal.GetQueuesByAttractionIdAndHour(MalfunctionTime, AttractionId, a.AttractionTime));
            int LastQueueId = QueuesDal.GetLastQueuePerAttractionId(AttractionId);
            List<QueuePerUserDTO> l = QueuePerUserDTO.ConvertQueuePerUserToDTO(QueuePerUserDal.GetQueuePerUserBetweenQueueIdToLastQueueId(q.QueueId, LastQueueId));
            foreach (var item in l)
            {
                UsersDTO u = UsersBll.GetUserById(item.UserId);
                MessageBll.GmailMessage(u.UserGmail, "הודעה על תקלה", MalfunctionMail(a.AttractionName, q.Hour));
            }
            q.QueueStatus = 2;
            QueuesBll.UpdateQueue(q);
            return l;
        }

        //A message for people who bought tickets and seats broke
        public static List<QueuePerUserDTO> MessageToLostTicket(UpdateMaxPeopleFromCurrHour_Result u)
        {
            for (int i = u.MaxPeopleInAttraction; i < 0 ; i++)
            {
                QueuePerUserDTO q = GetQueuePerUserByIdRevers(u.QueueId);
                if (q.CountTickets >= 0)
                {
                    UsersDTO user = UsersBll.GetUserById(q.UserId);
                    AttractionDTO a = AttractionBll.GetAllAttractionById(u.AttractionId);
                    MessageBll.GmailMessage(user.UserGmail, "הודעה על תקלה", MessageToLostTicketMail(a.AttractionName,u.Hour));
                    q.CountTickets--;
                    UpdateQueuePerUser(q.QueuePerUserId, q);
                    u.MaxPeopleInAttraction++;
                    QueuesBll.UpdateQueue(new QueuesDTO(u.QueueId, u.AttractionId, u.Hour, u.MaxPeopleInAttraction,1));
                }
            }

            return GetAllQueuePerUser();
        }
    }
}
