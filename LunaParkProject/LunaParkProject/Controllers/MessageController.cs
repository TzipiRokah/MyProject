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
    [RoutePrefix("LunaPark/Message")]
    public class MessageController : ApiController
    {
        [Route("GetAll")]
        public IHttpActionResult GetMessage()
        {
            try
            {
                var x = MessageBll.GetAllMessage();
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("AddMessage")]
        public IHttpActionResult AddMessage([FromBody]MessageDTO mDTO)
        {
            return Ok(MessageBll.AddMessage(mDTO));
        }

        [HttpGet]
        [Route("Newsletter/{UserGmail}")]
        public IHttpActionResult Newsletter(string UserGmail)
        {
            try
            {
                var x = MessageBll.Newsletter(UserGmail);
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("MailToManager")]
        public IHttpActionResult MailToManager([FromBody]MailToManager m)
        {
            return Ok(MessageBll.MailToManager(m.messageUserName, m.messageUserGmail, m.messageSubject, m.messageBody));
        }
    }
}
