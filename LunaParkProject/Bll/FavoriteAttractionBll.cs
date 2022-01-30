using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Dal;

namespace Bll
{
    public class FavoriteAttractionBll
    {
        public static List<FavoriteAttractionDTO> GetAllFavoriteAttraction()
        {
            return FavoriteAttractionDTO.ConvertFavoriteAttractionToDTO(FavoriteAttractionDal.GetAllFavoriteAttraction());
        }
    }
}
