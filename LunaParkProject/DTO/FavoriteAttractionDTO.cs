using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace DTO
{
    public class FavoriteAttractionDTO
    {
        public int FavoriteAttractionId { get; set; }
        public Nullable<int> AttractionId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> FavoriteAttractionRate { get; set; }

        public FavoriteAttractionDTO(FavoriteAttractionDTO fDTO)
        {
            FavoriteAttractionId = fDTO.FavoriteAttractionId;
            AttractionId = fDTO.AttractionId;
            UserId = fDTO.UserId;
            FavoriteAttractionRate =fDTO.FavoriteAttractionRate;
        }
        public FavoriteAttractionDTO(FavoriteAttraction fDB)
        {
            FavoriteAttractionId = fDB.FavoriteAttractionId;
            AttractionId = fDB.AttractionId;
            UserId = fDB.UserId;
            FavoriteAttractionRate = fDB.FavoriteAttractionRate;
        }

        public static List<FavoriteAttractionDTO> ConvertFavoriteAttractionToDTO(List<FavoriteAttraction> list)
        {
            var x = from fDTO in list
                    select new FavoriteAttractionDTO(fDTO);
            return x.ToList();
        }
        public static FavoriteAttraction ConvertDTOToFavoriteAttraction(FavoriteAttraction fDTO)
        {
            FavoriteAttraction eDB = new FavoriteAttraction()
            {
                FavoriteAttractionId = fDTO.FavoriteAttractionId,
                AttractionId = fDTO.AttractionId,
                UserId = fDTO.UserId,
                FavoriteAttractionRate = fDTO.FavoriteAttractionRate
            };
            return eDB;
        }
    }
}
