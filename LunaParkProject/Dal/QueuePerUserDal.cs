using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class QueuePerUserDal
    {
        public static List<QueuePerUser> GetAllQueuePerUser()
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.QueuePerUser.ToList();
            }
        }

        public static QueuePerUser GetQueuePerUserById(int id)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.QueuePerUser.First(x => x.QueuePerUserId == id);
            }
        }

        public static QueuePerUser GetQueuePerUserByQueueIdRevers(int id)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.QueuePerUser.First(x => x.QueueId == id);
            }
        }

        public static List<QueuePerUser> GetQueuesByUserId(int UserId)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.QueuePerUser.Where(x => x.UserId == UserId).ToList();
            }
        }

        public static List<QueuePerUser> GetQueuePerUserByQueueId(int QueueId)
        {

            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.QueuePerUser.Where(x => x.QueueId == QueueId).ToList();
            }
        }

        public static List<QueuePerUser> GetQueuePerUserByUserId(int UserId)
        {

            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.QueuePerUser.Where(x => x.UserId == UserId).ToList();
            }
        }

        public static List<QueuePerUser> GetQueuePerUserBetweenQueueIdToLastQueueId(int QueueId, int LastQueueId)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.QueuePerUser.Where(x => x.QueueId >= QueueId && x.QueueId <= LastQueueId).ToList();
            }
        }

        public static List<QueuePerUser> AddQueuePerUser(QueuePerUser q)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                DB.QueuePerUser.Add(q);
                DB.SaveChanges();
                return DB.QueuePerUser.ToList();
            }
        }


        public static List<QueuePerUser> RemoveQueuePerUser(QueuePerUser q)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                QueuePerUser q1 = DB.QueuePerUser.FirstOrDefault(x => x.QueuePerUserId == q.QueuePerUserId);
                if (q1 != null)
                {
                    DB.QueuePerUser.Remove(q1);
                    DB.SaveChanges();
                }
                return DB.QueuePerUser.ToList();
            }
        }

        public static List<QueuePerUser> UpdateQueuePerUser(int QueuePerUserId, QueuePerUser qDB)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                var q1 = DB.QueuePerUser.FirstOrDefault(w => w.QueuePerUserId == QueuePerUserId);
                if (q1 == null)
                    return null;
                else
                {
                    //q1.QueuePerUserId = qDB.QueuePerUserId;
                    q1.QueueId = qDB.QueueId;
                    q1.UserId = qDB.UserId;
                    q1.CountTickets = qDB.CountTickets;
                    DB.SaveChanges();
                    return DB.QueuePerUser.ToList();
                }

            }
        }
    }
}
