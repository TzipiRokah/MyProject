using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bll;

namespace LunaParkProject.Controllers
{
    [RoutePrefix("LunaPark/AccessLevel")]
    public class AccessLevelController : ApiController
    {
        [Route("GetAll")]
        public IHttpActionResult GetAccessLevel()
        {
            try
            {
                var x = AccessLevelBll.GetAllAccessLevel();
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
