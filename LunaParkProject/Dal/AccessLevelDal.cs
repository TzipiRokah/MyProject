using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class AccessLevelDal
    {
        public static List<AccessLevel> GetAllAccessLevel()
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.AccessLevel.ToList();
            }

        }
    }
}
