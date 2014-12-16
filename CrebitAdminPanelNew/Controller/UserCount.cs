using db;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using CrebitAdminPanelNew.Model;
namespace CrebitAdminPanelNew.Controller
{
    public class UserCount : ApiController
    {
          
        [Route("Admin/GetUserCount")]
        [HttpPost]
        public HttpResponseMessage GetuserCount(HttpRequestMessage req, DAS_Property das_Property)
        {

            if (das_Property != null)
            {
                DAS_services das_service = new DAS_services();
                DAS_serviceReturnType das_serviceReturnType = das_service.GetUserCount(das_Property);
                if (das_service._IsSuccess)
                    return req.CreateResponse<DAS_serviceReturnType>(HttpStatusCode.OK, das_serviceReturnType);
                else
                    return req.CreateErrorResponse(HttpStatusCode.InternalServerError, "ServerError");

            }
            return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

    }
}
    