using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrebitAdminRestApi.Model
{
    public class DAS_Property
    {
        //[JsonProperty("usertype")]
        public int UserType { get; set; }
        public string Date { get; set; }

    }

    public class DAS_serviceReturnType
    {

        //[JsonProperty("usertype")]
        public string totalCount { get; set; }

    }
}