using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class EmployeeDal
    {
        public static List<Employee> GetAllEmployee()
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                return DB.Employee.ToList();
            }

        }

        public static List<Employee> AddEmployee(Employee e)
        {
            using (LunaParkEntities DB = new LunaParkEntities())
            {
                DB.Employee.Add(e);
                DB.SaveChanges();
                return DB.Employee.ToList();
            }
        }
    }
}
