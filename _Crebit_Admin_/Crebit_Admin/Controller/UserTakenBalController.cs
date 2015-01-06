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
    public class UserTakenBalController : ApiController
    {

        [Route("api/UserTakenBal")]
        [HttpPost]

        public HttpResponseMessage Post(HttpRequestMessage req, CP_Property cp_Property)
        {
            UserTakenBalServices userTakenBalservices = new UserTakenBalServices();
            UserTakenBal_ReturnType userTakenbal_returntype = userTakenBalservices.UserTakenBalCount(cp_Property);

             if (userTakenBalservices._IsSuccess)
            {
                return req.CreateResponse<UserTakenBal_ReturnType>(HttpStatusCode.OK, userTakenbal_returntype);
                
                
            }
            else
                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");
        }
    
    }
}