using CrebitAdminPanelNew.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrebitAdminPanelNew.Controller
{
    public class UserProfitController : ApiController
    {
        [Route("api/UserProfit")]
        [HttpPost]

        public HttpResponseMessage Post(HttpRequestMessage req,CP_Property cp_Property)
        {
            //DAS_Property das = new DAS_Property();
            CP_Services cp_service = new CP_Services();
            CP_serviceReturnType cp_serviceReturnType = cp_service.ProfitCount(cp_Property);
            if (cp_service._IsSuccess)
            {
                return req.CreateResponse<CP_serviceReturnType>(HttpStatusCode.OK, cp_serviceReturnType);
                
                
            }
            else
                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
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