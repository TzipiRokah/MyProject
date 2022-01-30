using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using DTO;

namespace Bll
{
    public class RateBll
    {
        public static List<RateDTO> GetAllRate()
        {
            return RateDTO.ConvertRateToDTO(RateDal.GetAllRates());
        }

        public static List<RateDTO> GetRatesByLevelId(int AttractionId)
        {
            return RateDTO.ConvertRateToDTO(RateDal.GetRatesByLevelId(AttractionId));
        }

        public static List<RateDTO> AddRate(RateDTO r)
        {
            return RateDTO.ConvertRateToDTO(RateDal.AddRate(RateDTO.ConvertDTOToRate(r)));
        }
    }
}
