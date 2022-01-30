using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class StatusDal
    {
        public static List<Status> GetAllStatus()
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.Status.ToList();
            }
        }
    }
}
