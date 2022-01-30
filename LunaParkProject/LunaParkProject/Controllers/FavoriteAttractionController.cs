using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bll;

namespace LunaParkProject.Controllers
{
    [RoutePrefix("LunaPark/FavoriteAttraction")]
    public class FavoriteAttractionController : ApiController
    {
        [Route("GetAll")]
        public IHttpActionResult GetFavoriteAttraction()
        {
            try
            {
                var x = FavoriteAttractionBll.GetAllFavoriteAttraction();
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
