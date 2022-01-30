using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace DTO
{
    public class UsersDTO
    {
        public int UserId { get; set; }
        public string UserEnterance { get; set; }
        public string UserPassword { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserGmail { get; set; }
        public string UserPhone { get; set; }
        public Nullable<int> UsersCount { get; set; }
        public Nullable<int> UserAccessLevel { get; set; }

        public UsersDTO(UsersDTO uDTO)
        {
            UserId = uDTO.UserId;
            UserEnterance = uDTO.UserEnterance;
            UserPassword = uDTO.UserPassword;
            UserFirstName = uDTO.UserFirstName;
            UserLastName = uDTO.UserLastName;
            UserGmail = uDTO.UserGmail;
            UserPhone = uDTO.UserPhone;
            UsersCount = uDTO.UsersCount;
            UserAccessLevel = uDTO.UserAccessLevel;
        }

        public UsersDTO(Users uDB)
        {
            UserId = uDB.UserId;
            UserEnterance = uDB.UserEnterance;
            UserPassword = uDB.UserPassword;
            UserFirstName = uDB.UserFirstName;
            UserLastName = uDB.UserLastName;
            UserGmail = uDB.UserGmail;
            UserPhone = uDB.UserPhone;
            UsersCount = uDB.UsersCount;
            UserAccessLevel = uDB.UserAccessLevel;
        }

        public static List<UsersDTO> ConvertUsersToDTO(List<Users> list)
        {
            var x = from uDTO in list
                    select new UsersDTO(uDTO);
            return x.ToList();
        }
        public UsersDTO()
        {

        }
        public static Users ConvertDTOToUsers(UsersDTO uDTO)
        {
            Users uDB = new Users()
            {
                UserId = uDTO.UserId,
                UserEnterance = uDTO.UserEnterance,
                UserPassword = uDTO.UserPassword,
                UserFirstName = uDTO.UserFirstName,
                UserLastName = uDTO.UserLastName,
                UserGmail = uDTO.UserGmail,
                UserPhone = uDTO.UserPhone,
                UsersCount = uDTO.UsersCount,
                UserAccessLevel = uDTO.UserAccessLevel
            };
            return uDB;
        }
    }
}
