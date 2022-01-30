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
    [RoutePrefix("LunaPark/AttractionStatus")]
    public class AttractionStatusController : ApiController
    {
        [Route("GetAll")]
        public IHttpActionResult GetAttractionStatus()
        {
            try
            {
                var x = AttractionStatusBll.GetAllAttractionStatus();
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut]
        [Route("UpdateAttractionStatus/{AttractionStatusId}")]
        public IHttpActionResult UpdateAttractionStatus(int AttractionStatusId, [FromBody]AttractionStatusDTO aDTO)
        {
            try
            {
                return Ok(AttractionStatusBll.UpdateAttractionStatus(aDTO));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
