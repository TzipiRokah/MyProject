using Bll;
using DTO;
using LunaParkProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LunaParkProject.Controllers
{
    [RoutePrefix("LunaPark/QueuePerUser")]
    public class QueuePerUserController : ApiController
    {
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetQueuePerUser()
        {
            try
            {
                var x = QueuePerUserBll.GetAllQueuePerUser();
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("GetById/{QueuePerUserId}")]
        public IHttpActionResult GetQueuePerUserById(int QueuePerUserId)
        {
            try
            {
                var x = QueuePerUserBll.GetQueuePerUserById(QueuePerUserId);
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("GetByUserId/{UserId}")]
        public IHttpActionResult GetQueuePerUserByUserId(int UserId)
        {
            try
            {
                var x = QueuePerUserBll.GetQueuePerUserByUserId(UserId);
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("GetCorrectQueue")]
        public IHttpActionResult GetCorrectQueue(CorrectQueue q)
        {
            try
            {
                var x = QueuePerUserBll.GetCorrectQueue(q.UserId,q.AttractionId, q.Tickets, q.StartTime);
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("AddQueuePerUser")]
        public IHttpActionResult AddQueuePerUser([FromBody]QueuePerUserDTO qDTO)
        {
            return Ok(QueuePerUserBll.AddQueuePerUser(qDTO));
        }

        [Route("RemoveQueuePerUser")]
        public IHttpActionResult RemoveQueuePerUser([FromBody]QueuePerUserDTO qDTO)
        {
            return Ok(QueuePerUserBll.RemoveQueuePerUser(qDTO));
        }

        [HttpPut]
        [Route("DelayQueue")]
        public IHttpActionResult DelayQueue([FromBody] UpdateMaxPeople u)
        {
            try
            {
                return Ok(QueuePerUserBll.DelayQueue(u.TimeNow, u.AttractionId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("MalfunctionQueues")]
        public IHttpActionResult MalfunctionQueues([FromBody] UpdateMaxPeople u)
        {
            try
            {
                return Ok(QueuePerUserBll.MalfunctionQueues(u.TimeNow, u.AttractionId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
