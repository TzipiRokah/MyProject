using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class QueuesDal
    {
        public static List<Queues> GetAllQueues()
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                List<Queues> l = DB.Queues.ToList();
                return l;
            }
        }

        public static List<Queues> GetQueuesByHour(DateTime Hour)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.Queues.Where(x => x.Hour > Hour).ToList();
            }
        }

        public static Queues GetQueuesById(int id)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.Queues.First(x => x.QueueId == id);
            }
        }

        public static List<Queues> GetQueuesByAttractionId(int attractionId)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.Queues.Where(x => x.AttractionId == attractionId && x.Hour> DateTime.Now && x.QueueStatus==1).ToList();
            }
        }

        public static Queues GetQueuesByAttractionIdAndHour(DateTime Hour, int AttractionId, int AttractionTime)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                DateTime tempTime = Hour.AddMinutes(AttractionTime);
                Queues q= DB.Queues.FirstOrDefault(x => x.AttractionId == AttractionId && x.Hour >= Hour && x.Hour <= tempTime);
                if (q != null)
                    return q;
                else
                    return null;
            }
        }

        public static int GetLastQueuePerAttractionId(int AttractionId)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                int num= DB.LastQueuePerAttractionProc(AttractionId);
                return num;
            }
        }

        //public static IQueryable GetQueuesByNullTickets(DateTime TimeNow, int AttractionId)
        //{
        //    using (LunaParkEntities DB = new LunaParkEntities())
        //    {
        //        return DB.FindQueuesWithNullTickets(TimeNow, AttractionId);
        //    }
        //}

        public static List<Queues> UpdateQueue(Queues qDB)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                var q1 = DB.Queues.FirstOrDefault(w => w.QueueId == qDB.QueueId);
                if (q1 == null)
                    return null;
                //else
                //    if(q1.MaxPeopleInAttraction<=0)
                else
                {
                    q1.QueueId = qDB.QueueId;
                    q1.AttractionId = qDB.AttractionId;
                    q1.Hour = qDB.Hour;
                    q1.MaxPeopleInAttraction = qDB.MaxPeopleInAttraction;
                    q1.QueueStatus = qDB.QueueStatus;
                    DB.SaveChanges();
                    return DB.Queues.ToList();
                }

            }
        }
        public static List<Queues> AddQueue(Queues q)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                DB.Queues.Add(q);
                DB.SaveChanges();
                return DB.Queues.ToList();
                
            }

        }

        public static List<UpdateMaxPeopleFromCurrHour_Result> UpdateMaxPeopleFromThisHour(DateTime TimeNow, int AttractionId, int AttractionMaxPeople, int MaxPeopleNow)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                List<UpdateMaxPeopleFromCurrHour_Result> l =  DB.UpdateMaxPeopleFromCurrHour(TimeNow, AttractionId, AttractionMaxPeople, MaxPeopleNow).ToList();
                DB.SaveChanges();
                return l.ToList();
            }
        }

        public static void ResetQueues()
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                DB.ResetQueues();
            }
        }
    }
}
