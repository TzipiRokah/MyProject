using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public Nullable<int> EmployeeAccessLevel { get; set; }
        public string EmployeeDetails { get; set; }

        public EmployeeDTO(EmployeeDTO eDTO)
        {
            EmployeeId = eDTO.EmployeeId;
            EmployeeAccessLevel = eDTO.EmployeeAccessLevel;
            EmployeeDetails = eDTO.EmployeeDetails;
        }
        public EmployeeDTO(Employee eDB)
        {
            EmployeeId = eDB.EmployeeId;
            EmployeeAccessLevel = eDB.EmployeeAccessLevel;
            EmployeeDetails = eDB.EmployeeDetails;
        }

        public EmployeeDTO()
        {

        }

        public static List<EmployeeDTO> ConvertEmployeeToDTO(List<Employee> list)
        {
            var x = from eDTO in list
                    select new EmployeeDTO(eDTO);
            return x.ToList();
        }

        public static Employee ConvertDTOToEmployee(EmployeeDTO eDTO)
        {
            Employee eDB = new Employee()
            {
                EmployeeId = eDTO.EmployeeId,
                EmployeeAccessLevel = eDTO.EmployeeAccessLevel,
                EmployeeDetails=eDTO.EmployeeDetails
            };
            return eDB;
        }
    }
}
