using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Dal;

namespace Bll
{
    public class EmployeeBll
    {
        public static List<EmployeeDTO> GetAllEmployee()
        {
            return EmployeeDTO.ConvertEmployeeToDTO(EmployeeDal.GetAllEmployee());
        }

        public static List<EmployeeDTO> AddEmployee(EmployeeDTO e)
        {
            return EmployeeDTO.ConvertEmployeeToDTO(EmployeeDal.AddEmployee(EmployeeDTO.ConvertDTOToEmployee(e)));
        }
    }
}
