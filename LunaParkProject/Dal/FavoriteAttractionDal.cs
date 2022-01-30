using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class FavoriteAttractionDal
    {
        public static List<FavoriteAttraction> GetAllFavoriteAttraction()
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.FavoriteAttraction.ToList();
            }

        }
    }
}
