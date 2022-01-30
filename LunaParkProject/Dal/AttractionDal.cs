using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class AttractionDal
    {
        public static List<Attraction> GetAllAttraction()
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.Attraction.ToList();
            }

        }

        public static Attraction GetAllAttractionById(int id)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {

                return DB.Attraction.First(x=>x.AttractionId==id);
            }

        }

        public static List<Attraction> UpdateAttraction(Attraction aDB)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                var a1 = DB.Attraction.FirstOrDefault(w => w.AttractionId == aDB.AttractionId);
                if (a1 == null)
                    return null;
                else
                {
                    a1.AttractionId = aDB.AttractionId;
                    a1.AttractionName = aDB.AttractionName;
                    a1.AttractionIfActive = aDB.AttractionIfActive;
                    a1.AttractionMaxPeople = aDB.AttractionMaxPeople;
                    a1.AttractionNowPeople = aDB.AttractionNowPeople;
                    a1.AttractionCountQueue = aDB.AttractionCountQueue;
                    a1.AttractionTime = aDB.AttractionTime;
                    a1.AttractionTimeOUt = aDB.AttractionTimeOUt;
                    a1.AttractionLastAction = aDB.AttractionLastAction;
                    a1.AttractionCost = aDB.AttractionCost;
                    DB.SaveChanges();
                    return DB.Attraction.ToList();
                }

            }
        }
    }
}
