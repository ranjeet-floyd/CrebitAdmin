using CrebitAdminRestApi.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrebitAdminPanelNew.Controller
{
    public class UserCountController : ApiController
    {
        //HttpRequestMessage req;
        public IHttpActionResult Post([FromBody]DAS_Property UserType)
        {
            //DAS_Property das = new DAS_Property();
            DAS_services das_service = new DAS_services();
            DAS_serviceReturnType das_serviceReturnType = das_service.GetUserCount(UserType);
            if (das_service._IsSuccess)
            {
               // return req.CreateResponse<DAS_serviceReturnType>(HttpStatusCode.OK, das_serviceReturnType);
                return Ok<DAS_serviceReturnType>(das_serviceReturnType); 
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