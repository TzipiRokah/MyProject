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
    [RoutePrefix("LunaPark/Attraction")]
    public class AtrractionController : ApiController
    {
        [Route("GetAll")]
        public IHttpActionResult GetAttraction()
        {
            try
            {
               var x = AttractionBll.GetAllAttraction();
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("GetById/{AttractionId}")]
        public IHttpActionResult GetAttractionById(int AttractionId)
        {
            try
            {
                var x = AttractionBll.GetAllAttractionById(AttractionId);
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("UpdateAttraction/{AttractionId}")]
        public IHttpActionResult UpdateAttraction(int AttractionId, [FromBody]AttractionDTO aDTO)
        {
            return Ok(AttractionBll.UpdateAttraction(aDTO));
        }

        //[Route("GetQuickWayByRate")]
        //public IHttpActionResult GetQuickWayByRate([FromBody]List<AttractionDTO> list)
        //{
        //    try
        //    {
        //        var x = AttractionBll.GetQuickWayByRate(list);
        //        return Ok(x);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}
    }
}
