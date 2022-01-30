using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Dal;

namespace Bll
{
    public class AttractionBll
    {
        public static int ClosingdHour { get; set; } = 19;

        public static List<AttractionDTO> GetAllAttraction()
        {
            return AttractionDTO.ConvertAttractionToDTO(AttractionDal.GetAllAttraction());
        }

        public static AttractionDTO GetAllAttractionById(int id)
        {
            return AttractionDTO.ConvertAttractionToDTO(AttractionDal.GetAllAttractionById(id));
        }

        //פונקציה המקבלת אטרקציה ומחזירה זמן משוער להמתנה
        public static int GetWaitTimePerAttraction(AttractionDTO a)
        {
            int time;
            return time = a.AttractionCountQueue / a.AttractionMaxPeople * (a.AttractionTime + a.AttractionTimeOUt);
        }

        ////פונקציה המקבלת רשימת אטרקציות ומחזיר את הרשימה ממוינת על פי הדרוג
        //public static List<AttractionDTO> GetQuickWayByRate(List<AttractionDTO> list)
        //{
        //    int i, sumTime = 0;
        //    for (i = 0; i < list.Count; i++)
        //        list[i].TimeWait = GetWaitTimePerAttraction(list[i]);
        //    if (ClosingdHour - (DateTime.Now.Hour) > sumTime)
        //        sumTime += list[i].TimeWait;
        //    else
        //        list.Remove(list[i]);
        //    return list;
        //}

        //פונקציה הממינת לפי מספר מתקנים הגבוה ביותר
        public List<AttractionDTO> GetQuickWayByMaxAttraction(List<AttractionDTO> list)
        {
            int i, sum = 0;
            for (i = 0; i < list.Count; i++)
                list[i].TimeWait = GetWaitTimePerAttraction(list[i]);
            //מיון  האטרקציות מהקטן לגדול
            list.Sort();
            for (i = 0; i < list.Count && sum + list[i].TimeWait < ClosingdHour - (DateTime.Now.Hour); i++)
                sum += list[i].TimeWait;
            for (; i < list.Count; i++)
                list.Remove(list[i]);
            return list;
        }

        public static List<AttractionDTO> UpdateAttraction(AttractionDTO aDTO)
        {
            return AttractionDTO.ConvertAttractionToDTO(AttractionDal.UpdateAttraction(AttractionDTO.ConvertDTOToAttraction(aDTO)));
        }
    }
}