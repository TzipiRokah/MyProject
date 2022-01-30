using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bll
{
    public class QueuesBll
    {
        public static List<QueuesDTO> GetAllQueues()
        {
            return QueuesDTO.ConvertQueuesToDTO(QueuesDal.GetAllQueues());
        }

        public static List<QueuesDTO> GetAllQueuesByHour(DateTime hour)
        {
            return QueuesDTO.ConvertQueuesToDTO(QueuesDal.GetQueuesByHour(hour));
        }

        public static QueuesDTO GetQueuesById(int id)
        {
            return new QueuesDTO(QueuesDal.GetQueuesById(id));
        }

        public static List<QueuesDTO> GetQueuesByAttractionId(int attractionId)
        {
            return QueuesDTO.ConvertQueuesToDTO(QueuesDal.GetQueuesByAttractionId(attractionId));
        }

        public static List<QueuesDTO> AddQueues(QueuesDTO q)
        {
            return QueuesDTO.ConvertQueuesToDTO(QueuesDal.AddQueue(QueuesDTO.ConvertDTOToQueues(q)));
        }

        public static List<QueuesDTO> UpdateQueue(QueuesDTO queuesDTO)
        {
            return QueuesDTO.ConvertQueuesToDTO(QueuesDal.UpdateQueue(QueuesDTO.ConvertDTOToQueues(queuesDTO)));
        }

        //אם נוצר מצב של מינוס כרטיסים
        //public static List<QueuesDTO> UpdateIfLessTickets()
        //{

        //}

        public static List<QueuesDTO> UpdateMaxPeopleFromCurrHour(DateTime TimeNow, int AttractionId, int AttractionMaxPeople)
        {
            AttractionDTO a = AttractionBll.GetAllAttractionById(AttractionId);
            //אם מספר המושבים קטן, ולכן מספר כרטיסים שנמכרו מבוטלים
            //if (AttractionMaxPeople < a.AttractionMaxPeople)
            //    UpdateIfLessTickets();
            List<UpdateMaxPeopleFromCurrHour_Result> l = QueuesDal.UpdateMaxPeopleFromThisHour(TimeNow, AttractionId, AttractionMaxPeople, a.AttractionMaxPeople);
            foreach (var item in l)
            {
                QueuePerUserBll.MessageToLostTicket(item);
            }
            return GetAllQueues();
        }

        public static List<QueuesDTO> FillQueues(DateTime Open, DateTime Close)
        {
            QueuesDal.ResetQueues();
            List<AttractionDTO> l = AttractionBll.GetAllAttraction();
            for (int i = 0; i < l.Count(); i++)
            {
                DateTime tempOpen = Open;
                DateTime temp = tempOpen;
                while (temp < Close)
                {
                    temp = tempOpen.AddMinutes(l[i].AttractionTime + l[i].AttractionTimeOUt);
                    Queues q = new Queues();
                    q.AttractionId = l[i].AttractionId;
                    q.Hour = tempOpen;
                    q.MaxPeopleInAttraction = l[i].AttractionMaxPeople;
                    q.QueueStatus = 1;
                    QueuesDal.AddQueue(q);
                    tempOpen = temp;
                }
            }
            return GetAllQueues();
        }


        static CancellationTokenSource m_ctSource;
        public static void RunPrepareDaily(DateTime date)//מקבלת תאריך מדויק
        {
            m_ctSource = new CancellationTokenSource();
            var dateNow = DateTime.Now;
            TimeSpan ts;//אובייקט שמייצג את מרווח הזמן שנותר עד להפעלת התהליך
            if (date > dateNow)
                ts = date - dateNow;
            else//אם התאריך המבוקש עבר כבר-מקדם אותו למועד הבא
            {
                date = date.AddDays(1);//במקרה שלנו- קידום התאריך ביום(יכול להיות גם הוספת דקות/שעות)
                ts = date - dateNow;
            }
            //שימתין את פרק הזמן שנקבע, ואח"כ יקרא לפונקציה שרצינו שתופעל פעם ב... threadהפעלת ה 
            Task.Delay(ts).ContinueWith((x) =>
            {
                DateTime dstart = new DateTime(date.Year, date.Month, date.Day, 9, 0, 0);
                DateTime dend = new DateTime(date.Year, date.Month, date.Day, 17, 0, 0);
                FillQueues(dstart, dend);//קריאה לפונקציה המבוקשת
                RunPrepareDaily(date);//קריאה חוזרת לפונקציה...
            }, m_ctSource.Token);

        }
    }
}
