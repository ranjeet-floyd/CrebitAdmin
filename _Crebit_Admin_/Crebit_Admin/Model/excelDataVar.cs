using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrebitAdminPanelNew.Model
{
    public class excelDataVar { public string OperaterName { get; set; } public DateTime Date { get; set; } public string ApiTransactionId { get; set; } }

    public class UserNameDataVar 
    {
        public string UserName { get; set; }
        public string AvailAmount { get; set; }
        public string Usertype { get; set; }
        public string IsActive { get; set; }
    }

    public class DistinctUserNameDataVar
    {
        public string DistinctUserName { get; set; }
        public string DistinctAvailAmount { get; set; }
        public string DistinctUserType { get; set; }
        public string DistinctIsActive { get; set; }
    }


}