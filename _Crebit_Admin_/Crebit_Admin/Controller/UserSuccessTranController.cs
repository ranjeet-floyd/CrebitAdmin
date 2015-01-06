using CrebitAdminPanelNew.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrebitAdminPanelNew.Controller
{
    public class UserSuccessTranController : ApiController
    {
        [Route("api/UserSuccessTran")]
        [HttpPost]
        public HttpResponseMessage Post(HttpRequestMessage req,UserSuccess_Tran userSuccess_tran)
        {
            //DAS_Property das = new DAS_Property();
            TranSuccess TranSuceess_service = new TranSuccess();
            UserSuccessTranReturnType transReturn = TranSuceess_service.GetSuccess(userSuccess_tran);
            if (TranSuceess_service._IsSuccess)
            {
                
                return req.CreateResponse<UserSuccessTranReturnType>(HttpStatusCode.OK, transReturn);
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