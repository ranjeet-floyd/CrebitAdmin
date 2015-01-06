using Crebit_Admin.Model;
using CrebitAdminPanelNew.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Crebit_Admin.Controller
{
    public class OpeningClosingBalController : ApiController
    {

        [Route("api/OpeningClosingBal")]
        [HttpPost]
        public HttpResponseMessage UserCount(HttpRequestMessage req, CP_Property cp_property)
        {

            //DAS_Property das = new DAS_Property();
            OpenCloseBal_Services openCloseBal_Services = new OpenCloseBal_Services();
            OpenCloseBal_serviceReturnType openCloseBal_serviceReturnType = openCloseBal_Services.OpenCloseBal(cp_property);
            if (openCloseBal_Services._IsSuccess)
            {
                // return req.CreateResponse<DAS_serviceReturnType>(HttpStatusCode.OK, das_serviceReturnType);
                return req.CreateResponse<OpenCloseBal_serviceReturnType>(HttpStatusCode.OK, openCloseBal_serviceReturnType);
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