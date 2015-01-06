
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
        public double CyberPlateProfit { get; set; }
        public double CyberPlateAdminProfit { get; set; }
        public double MSEB_ElecAdminProfit  { get; set; }
        public double FundAdminProfit { get; set; }
        public double MoneyTransferAdminProfit { get; set; }
         
    }

    public class UserTakenBal_ReturnType
    {
        public double userTakenBal { get; set; }


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
        public List<UserSuccessTranReturnTypes> dL_TransactionReturns { get; set; }
    }



    public class UserSuccessTranReturnTypes
    {
        
        public string Id { get; set; }
        public string UserName { get; set; }
        public string ApiTransactionId { get; set; }
        public string OperaterName { get; set; }
        public string Amount { get; set; }
        public string ServiceType { get; set; }
        public string CreditAccountNo { get; set; }
        public string Date { get; set; }
        public string CyberSessionId { get; set; }
        public string Source { get; set; }
        public string Status { get; set; }
        public string APiId { get; set; }
        public string ServiceId { get; set; } 
    }


    public class UserSuccess_Tran
    {
        //[JsonProperty("usertype")]
        public string Date { get; set; }
        public string UserName { get; set; }
    }



    public class OpenCloseBal_serviceReturnType
    { 
    public double OpeningBal{get;set;}
    public double ClosingBal{get;set;}
        
    }
    

}