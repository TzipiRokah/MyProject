using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Dal;

namespace Bll
{
    public class UsersBll
    {
        public static List<UsersDTO> GetAllUsers()
        {
            return UsersDTO.ConvertUsersToDTO(UserDal.GetAllUser());
        }

        public static UsersDTO GetUserById(int id)
        {
            return new UsersDTO(UserDal.GetUserById(id));
        }

        public static UsersDTO GetUserByNameAndPassword(string name, string password)
        {
            return new UsersDTO(UserDal.GetUserByNameAndPassword(name, password));
        }

        public static List<UsersDTO> AddUser(UsersDTO u)
        {
          return UsersDTO.ConvertUsersToDTO(UserDal.AddUser(UsersDTO.ConvertDTOToUsers(u)));
        }
    }
}
