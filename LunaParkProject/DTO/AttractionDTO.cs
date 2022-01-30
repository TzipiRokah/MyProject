using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace DTO
{
    public class AttractionDTO:IComparable
    {
        public int AttractionId { get; set; }
        public string AttractionName { get; set; }
        public Nullable<int> AttractionIfActive { get; set; }
        public int AttractionMaxPeople { get; set; }
        public Nullable<int> AttractionNowPeople { get; set; }
        public int AttractionCountQueue { get; set; }
        public int AttractionTime { get; set; }
        public int AttractionTimeOUt { get; set; }
        public Nullable<int> AttractionLastAction { get; set; }
        public Nullable<int> AttractionCost { get; set; }
        public int TimeWait { get; set; }

        public AttractionDTO()
        {

        }

        public AttractionDTO(Attraction aDB)
        {
            AttractionId = aDB.AttractionId;
            AttractionName = aDB.AttractionName;
            AttractionIfActive = aDB.AttractionIfActive;
            AttractionMaxPeople = aDB.AttractionMaxPeople;
            AttractionNowPeople = aDB.AttractionNowPeople;
            AttractionCountQueue = aDB.AttractionCountQueue;
            AttractionTime = aDB.AttractionTime;
            AttractionTimeOUt = aDB.AttractionTimeOUt;
            AttractionLastAction = aDB.AttractionLastAction;
            AttractionCost = aDB.AttractionCost;
        }
        public AttractionDTO(AttractionDTO aDTO)
        {
            this.AttractionId = aDTO.AttractionId;
            this.AttractionName = aDTO.AttractionName;
            this.AttractionIfActive = aDTO.AttractionIfActive;
            AttractionMaxPeople = aDTO.AttractionMaxPeople;
            AttractionNowPeople = aDTO.AttractionNowPeople;
            AttractionCountQueue = aDTO.AttractionCountQueue;
            AttractionTime = aDTO.AttractionTime;
            AttractionTimeOUt = aDTO.AttractionTimeOUt;
            AttractionLastAction = aDTO.AttractionLastAction;
            AttractionCost = aDTO.AttractionCost;
        }

        public static List<AttractionDTO> ConvertAttractionToDTO(List<Attraction> list)
        {
            var x = from aDTO in list
                    select new AttractionDTO(aDTO);
            return x.ToList();
        }
        public static Attraction ConvertDTOToAttraction(AttractionDTO aDTO)
        {
            Attraction aDB = new Attraction()
            {
                AttractionId = aDTO.AttractionId,
                AttractionName = aDTO.AttractionName,
                AttractionIfActive = aDTO.AttractionIfActive,
                AttractionMaxPeople = aDTO.AttractionMaxPeople,
                AttractionNowPeople = aDTO.AttractionNowPeople,
                AttractionCountQueue = aDTO.AttractionCountQueue,
                AttractionTime = aDTO.AttractionTime,
                AttractionTimeOUt = aDTO.AttractionTimeOUt,
                AttractionLastAction = aDTO.AttractionLastAction,
                AttractionCost = aDTO.AttractionCost,
            };
            return aDB;
        }

        public static AttractionDTO ConvertAttractionToDTO(Attraction aDB)
        {
            AttractionDTO aDTO = new AttractionDTO()
            {
                AttractionId = aDB.AttractionId,
                AttractionName = aDB.AttractionName,
                AttractionIfActive = aDB.AttractionIfActive,
                AttractionMaxPeople = aDB.AttractionMaxPeople,
                AttractionNowPeople = aDB.AttractionNowPeople,
                AttractionCountQueue = aDB.AttractionCountQueue,
                AttractionTime = aDB.AttractionTime,
                AttractionTimeOUt = aDB.AttractionTimeOUt,
                AttractionLastAction = aDB.AttractionLastAction,
                AttractionCost = aDB.AttractionCost,
            };
            return aDTO;
        }

        public int CompareTo(object obj)
        {
            AttractionDTO a = (AttractionDTO)obj;
            return a.TimeWait-TimeWait;
        }
    }
}
