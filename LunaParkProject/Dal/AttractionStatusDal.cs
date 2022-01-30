using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class AttractionStatusDal
    {
        public static List<AttractionStatus> GetAllAttractionStatus()
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.AttractionStatus.ToList();
            }

        }

        public static List<AttractionStatus> UpdateAttractionStatus(AttractionStatus sDB)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                var s1 = DB.AttractionStatus.FirstOrDefault(w => w.AttractionStatusId == sDB.AttractionStatusId);
                if (s1 == null)
                    return null;
                else
                {
                    s1.AttractionStatusId = sDB.AttractionStatusId;
                    s1.AttractionId = sDB.AttractionId;
                    s1.StatusId = sDB.StatusId;
                    s1.AttractionStatusDateTime = sDB.AttractionStatusDateTime;
                    s1.EmployeeReportId = sDB.EmployeeReportId;
                    DB.SaveChanges();
                    return DB.AttractionStatus.ToList();
                }

            }


        }
    }
}
