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

    public class UserSuccessTranReturnType
    {

        //[JsonProperty("usertype")]
        public string UserSuccess_serviceReturnType { get; set; }
    }


    public class UserSuccess_Tran
    {
        //[JsonProperty("usertype")]
        public string Date { get; set; }
        public string UserName { get; set; }
    }
    

}