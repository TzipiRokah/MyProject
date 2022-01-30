using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bll;
using DTO;

namespace LunaParkProject.Controllers
{
    [RoutePrefix("LunaPark/Employee")]
    public class EmployeeController : ApiController
    {
        [Route("GetAll")]
        public IHttpActionResult GetEmployee()
        {
            try
            {
                var x = EmployeeBll.GetAllEmployee();
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("AddEmployee")]
        public IHttpActionResult AddEmployee([FromBody]EmployeeDTO eDTO)
        {
            return Ok(EmployeeBll.AddEmployee(eDTO));
        }
    }
}
