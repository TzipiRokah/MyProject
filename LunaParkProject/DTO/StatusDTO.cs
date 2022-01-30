using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace DTO
{
    public class StatusDTO
    {
        public int StatusId { get; set; }
        public string StatusDetails { get; set; }

        public StatusDTO(StatusDTO sDTO)
        {
            StatusId = sDTO.StatusId;
            StatusDetails = sDTO.StatusDetails;
        }

        public StatusDTO(Status sDB)
        {
            StatusId = sDB.StatusId;
            StatusDetails = sDB.StatusDetails;
        }

        public static List<StatusDTO> ConvertStatusToDTO(List<Status> list)
        {
            var x = from sDTO in list
                    select new StatusDTO(sDTO);
            return x.ToList();
        }

        public static Status ConvertDTOToStatus(Status sDTO)
        {
            Status sDB = new Status()
            {
                StatusId = sDTO.StatusId,
                StatusDetails = sDTO.StatusDetails
            };
            return sDB;
        }
    }
}
