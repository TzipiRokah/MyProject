using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bll;

namespace LunaParkProject.Controllers
{
    [RoutePrefix("LunaPark/Status")]
    public class StatusController : ApiController
    {
        [Route("GetAll")]
        public IHttpActionResult GetStatus()
        {
            try
            {
                var x = StatusBll.GetAllStatus();
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
