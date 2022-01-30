using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace DTO
{
    public class RateDTO
    {
        public int RateId { get; set; }
        public Nullable<int> AttractionId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> RateDateTime { get; set; }
        public Nullable<int> RateLevel { get; set; }

        public RateDTO(RateDTO rDTO)
        {
            RateId = rDTO.RateId;
            AttractionId = rDTO.AttractionId;
            UserId = rDTO.UserId;
            RateDateTime = rDTO.RateDateTime;
            RateLevel = rDTO.RateLevel;
        }
        public RateDTO(Rate rDB)
        {
            RateId = rDB.RateId;
            AttractionId = rDB.AttractionId;
            UserId = rDB.UserId;
            RateDateTime = rDB.RateDateTime;
            RateLevel = rDB.RateLevel;
        }

        public RateDTO()
        {

        }

        public static List<RateDTO> ConvertRateToDTO(List<Rate> list)
        {
            var x = from rDTO in list
                    select new RateDTO(rDTO);
            return x.ToList();
        }
        public static Rate ConvertDTOToRate(RateDTO rDTO)
        {
            Rate rDB = new Rate()
            {
                RateId = rDTO.RateId,
                AttractionId = rDTO.AttractionId,
                UserId = rDTO.UserId,
                RateDateTime = rDTO.RateDateTime,
                RateLevel = rDTO.RateLevel
            };
            return rDB;
        }
    }
}
