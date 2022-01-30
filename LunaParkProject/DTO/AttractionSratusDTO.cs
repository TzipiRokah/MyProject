using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace DTO
{
    public class AttractionStatusDTO
    {
        public int AttractionStatusId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> AttractionId { get; set; }
        public Nullable<System.DateTime> AttractionStatusDateTime { get; set; }
        public Nullable<int> EmployeeReportId { get; set; }

        public AttractionStatusDTO()
        {

        }

        public AttractionStatusDTO(AttractionStatusDTO aDTO)
        {
            AttractionStatusId = aDTO.AttractionStatusId;
            StatusId = aDTO.StatusId;
            AttractionId = aDTO.AttractionId;
            AttractionStatusDateTime = aDTO.AttractionStatusDateTime;
            EmployeeReportId = aDTO.EmployeeReportId;
        }
        public AttractionStatusDTO(AttractionStatus aDB)
        {
            AttractionStatusId = aDB.AttractionStatusId;
            StatusId = aDB.StatusId;
            AttractionId = aDB.AttractionId;
            AttractionStatusDateTime = aDB.AttractionStatusDateTime;
            EmployeeReportId = aDB.EmployeeReportId;
        }

        public static List<AttractionStatusDTO> ConvertAttractionStatusToDTO(List<AttractionStatus> list)
        {
            var x = from aDTO in list
                    select new AttractionStatusDTO(aDTO);
            return x.ToList();
        }

        public static AttractionStatus ConvertDTOToAttractionStatus(AttractionStatusDTO aDTO)
        {
            AttractionStatus aDB = new AttractionStatus()
            {
                AttractionStatusId = aDTO.AttractionStatusId,
                StatusId = aDTO.StatusId,
                AttractionId = aDTO.AttractionId,
                AttractionStatusDateTime = aDTO.AttractionStatusDateTime,
                EmployeeReportId = aDTO.EmployeeReportId
            };
            return aDB;
        }
    }
}
