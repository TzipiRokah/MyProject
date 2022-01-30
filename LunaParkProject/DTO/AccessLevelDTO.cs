using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace DTO
{
    public class AccessLevelDTO
    {
        public int AccessLevelId { get; set; }
        public string AccessDetails { get; set; }



        public AccessLevelDTO(AccessLevel aDB)
        {
            this.AccessLevelId = aDB.AccessLevelId;
            this.AccessDetails = aDB.AccessDetails;
        }

        public AccessLevelDTO(AccessLevelDTO aDTO)
        {
            this.AccessLevelId = aDTO.AccessLevelId;
            this.AccessDetails = aDTO.AccessDetails;
        }

        public static List<AccessLevelDTO> ConvertAccessLevelToDTO(List<AccessLevel> list)
        {
            var x = from aDTO in list
                    select new AccessLevelDTO(aDTO);
            return x.ToList();
        }
        public static AccessLevel ConvertDTOToAccessLevel(AccessLevelDTO aDTO)
        {
            AccessLevel aDB = new AccessLevel()
            {
                AccessLevelId = aDTO.AccessLevelId,
                AccessDetails = aDTO.AccessDetails
            };
            return aDB;
        }
    }
}
