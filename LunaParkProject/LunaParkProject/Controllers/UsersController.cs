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
    [RoutePrefix("LunaPark/Users")]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetUsers()
        {
            try
            {
                var x = UsersBll.GetAllUsers();
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("GetUserByNameAndPassword/{name}/{password}")]
        public IHttpActionResult GetUserByNameAndPassword(string name, string password)
        {
            try
            {
                var x = UsersBll.GetUserByNameAndPassword(name, password);
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("AddUser")]
        public IHttpActionResult AddGadjet([FromBody]UsersDTO uDTO)
        {
            return Ok(UsersBll.AddUser(uDTO));
        }
    }
}
