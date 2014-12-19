using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrebitAdminPanelNew.Model
{
    public class CP_Property
    {
        //[JsonProperty("usertype")]
        public int UserType { get; set; }
        public string Date { get; set; }
        public string UserName { get; set; }
    }
    public class CP_serviceReturnType
    {

        //[JsonProperty("usertype")]
        public string totalCount { get; set; }

    }
}