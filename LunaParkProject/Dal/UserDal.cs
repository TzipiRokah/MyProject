using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class UserDal
    {
        public static List<Users> GetAllUser()
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.Users.ToList();
            }
        }

        public static Users GetUserById(int id)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.Users.First(x=>x.UserId==id);
            }
        }

        public static Users GetUserByNameAndPassword(string name,string password)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.Users.First(x => x.UserEnterance == name && x.UserPassword==password);
            }
        }

        public static List<Users> AddUser(Users u)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                DB.Users.Add(u);
                DB.SaveChanges();
                return DB.Users.ToList();
            }
        }
    }
}
