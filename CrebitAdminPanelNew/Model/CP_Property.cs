using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrebitAdminRestApi.Model
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
        public double CyberPlateProfit { get; set; }
        public double CyberPlateAdminProfit { get; set; }
        public double CpTakenBal { get; set; }

    }
}