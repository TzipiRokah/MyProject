using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Dal;

namespace Bll
{
    public class StatusBll
    {
        public static List<StatusDTO> GetAllStatus()
        {
            return StatusDTO.ConvertStatusToDTO(StatusDal.GetAllStatus());
        }
    }
}
