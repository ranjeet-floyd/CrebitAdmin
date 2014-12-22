using CrebitAdminRestApi.Model;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace CrebitAdminPanelNew.Controller
{
    public class UserProfitController : ApiController
    {

        public IHttpActionResult Post([FromBody]CP_Property cp_Property)
        {
            //DAS_Property das = new DAS_Property();
            CP_Services cp_service = new CP_Services();
            CP_serviceReturnType cp_serviceReturnType = cp_service.ProfitCount(cp_Property);
            if (cp_service._IsSuccess)
            {
                return Content<CP_serviceReturnType>(HttpStatusCode.OK, cp_serviceReturnType);
                
            }
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

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

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