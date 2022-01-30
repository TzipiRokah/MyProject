using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Dal;

namespace Bll
{
    public class AttractionStatusBll
    {
        public static List<AttractionStatusDTO> GetAllAttractionStatus()
        {
            return AttractionStatusDTO.ConvertAttractionStatusToDTO(AttractionStatusDal.GetAllAttractionStatus());
        }

        public static List<AttractionStatusDTO> UpdateAttractionStatus(AttractionStatusDTO aDTO)
        {
            return AttractionStatusDTO.ConvertAttractionStatusToDTO(AttractionStatusDal.UpdateAttractionStatus(AttractionStatusDTO.ConvertDTOToAttractionStatus(aDTO)));
        }
    }
}
