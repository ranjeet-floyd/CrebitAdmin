using CrebitAdminRestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrebitAdminPanelNew.Controller
{
    public class UserSuccessTranController : ApiController
    {
        public IHttpActionResult Post([FromBody]UserSuccess_Tran userSuccess_tran)
        {
            //DAS_Property das = new DAS_Property();
            TranSuccess TranSuceess_service = new TranSuccess();
            UserSuccessTranReturnType UserSuccess_serviceReturnType = TranSuceess_service.GetSuccess(userSuccess_tran);
            if (TranSuceess_service._IsSuccess)
            {
                return Content<UserSuccessTranReturnType>(HttpStatusCode.OK, UserSuccess_serviceReturnType);

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