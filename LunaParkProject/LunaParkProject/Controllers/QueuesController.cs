using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bll;
using DTO;
using LunaParkProject.Classes;

namespace LunaParkProject.Controllers
{
    [RoutePrefix("LunaPark/Queues")]
    public class QueuesController : ApiController
    {

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetQueues()
        {
            try
            {
                var x = QueuesBll.GetAllQueues();
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetAllByHour")]
        public IHttpActionResult GetQueuesByHour()
        {
            try
            {
                var x = QueuesBll.GetAllQueuesByHour(DateTime.Now);
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("GetById/{QueuesId}")]
        public IHttpActionResult GetQueuesById(int QueuesId)
        {
            try
            {
                var x = QueuesBll.GetQueuesById(QueuesId);
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("GetQueuesByAttractionId/{AttractionId}")]
        public IHttpActionResult GetQueuesByAttractionId(int AttractionId)
        {
            try
            {
                var x = QueuesBll.GetQueuesByAttractionId(AttractionId);
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("AddQueues")]
        public IHttpActionResult AddQueue([FromBody]QueuesDTO qDTO)
        {
            return Ok(QueuesBll.AddQueues(qDTO));
        }

        [HttpPut]
        [Route("UpdateQueue/{QueueId}")]
        public IHttpActionResult UpdateQueue(int QueueId,[FromBody]QueuesDTO qDTO)
        {
            return Ok(QueuesBll.UpdateQueue(qDTO));
        }

        [HttpPut]
        [Route("UpdateMaxPeopleFromCurrHour")]
        public IHttpActionResult UpdateMaxPeopleFromCurrHour([FromBody]UpdateMaxPeople u)
        {
            try
            {
               return Ok(QueuesBll.UpdateMaxPeopleFromCurrHour(DateTime.Now,u.AttractionId,u.AttractionMaxPeople));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("ResetQueues")]
        public IHttpActionResult ResetQueues(DateTimeParameters Times)
        {
            try
            {
                return Ok(QueuesBll.FillQueues(Times.Open, Times.Close));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

