using CrebitAdminPanelNew.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrebitAdminPanelNew.Controller
{
    public class UserProfitController : ApiController
    {

        public IHttpActionResult Post([FromBody]CP_Property UserType)
        {
            //DAS_Property das = new DAS_Property();
            CP_Services das_service = new CP_Services();
            CP_serviceReturnType cp_serviceReturnType = das_service.GetUserCount(UserType);
            if (das_service._IsSuccess)
            { return Ok(cp_serviceReturnType); }
            else { return NotFound(); }
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}