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
    [RoutePrefix("LunaPark/Rate")]
    public class RateController : ApiController
    {
        [Route("GetAll")]
        public IHttpActionResult GetRate()
        {
            try
            {
                var x = RateBll.GetAllRate();
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("GetRatesByLevelId/{AttractionId}")]
        public IHttpActionResult GetRatesByLevelId(int AttractionId)
        {
            try
            {
                var x = RateBll.GetRatesByLevelId(AttractionId);
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("AddRate")]
        public IHttpActionResult AddRate([FromBody]RateDTO rDTO)
        {
            return Ok(RateBll.AddRate(rDTO));
        }
    }
}
