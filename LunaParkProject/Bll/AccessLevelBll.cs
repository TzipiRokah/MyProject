using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Dal;

namespace Bll
{
    public class AccessLevelBll
    {
        public static List<AccessLevelDTO> GetAllAccessLevel()
        {
            return AccessLevelDTO.ConvertAccessLevelToDTO(AccessLevelDal.GetAllAccessLevel());
        }
    }
}
