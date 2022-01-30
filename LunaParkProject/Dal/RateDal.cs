using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class RateDal
    {
        public static List<Rate> GetAllRates()
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.Rate.ToList();
            }

        }

        public static List<Rate> GetRatesByLevelId(int AttractionId)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.Rate.Where(x => x.AttractionId == AttractionId).ToList();
            }
        }

        public static List<Rate> AddRate(Rate r)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                DB.Rate.Add(r);
                DB.SaveChanges();
                return DB.Rate.ToList();

            }

        }
    }
}
