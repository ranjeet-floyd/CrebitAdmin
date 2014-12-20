using db;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CrebitAdminRestApi.Model
{
    public class CP_Services
    {
        public CP_serviceReturnType cp_serviceReturnType = null;
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        // userProfit
        public double totalProfit=0.0;
        public double MSEB_ElecProfit=0.0;
        public double FundProfit=0.0;
        public double MoneyTransferProfit = 0.0;
        public double CyberPlateProfit = 0.0;
        //admin Profit
        public double totalAdminProfit = 0.0;
        public double MSEB_ElecAdminProfit=0.0;
        public double FundAdminProfit=0.0;
        public double MoneyTransferAdminProfit = 0.0;
        public double CyberPlateAdminProfit = 0.0;
        //taken bal
        public double CpTakenBal = 0.0;
        
        public CP_serviceReturnType GetProfitCount(CP_Property cp_Property)
        {

            this._IsSuccess = true;
            this.SpName = "CB_ADMIN_CPprofitSummary";
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@UserType", cp_Property.UserType);
                param[1] = new SqlParameter("@Date", String.IsNullOrEmpty(cp_Property.Date) ? Convert.DBNull : Convert.ToDateTime(cp_Property.Date).Date);
                param[2] = new SqlParameter("@UserName", String.IsNullOrEmpty(cp_Property.UserName) ? Convert.DBNull : cp_Property.UserName);
                DataBase db = new DataBase();
                DataSet ds = db.GetDataSet(this.SpName, param);

                if (ds != null)
                {
                     
                    DataRowCollection drc = ds.Tables[0].Rows;
                  ////retriving data from table 
                    foreach (DataRow item in drc)
                    {
                        string Profit =""+item["Profit"].ToString();
                        string UserName = ""+item["UserName"].ToString();
                        string OperatorId = "" + item["OperatorId"].ToString();
                        string PrevBal = ""+item["PrevBal"].ToString();
                        string AdminProfit = item["AdminProfit"].ToString();
                        string UserType = "" + item["UserType"].ToString();
                        string RegDate = Convert.ToDateTime(item["RegDate"]).ToString("d MMM yyyy h:mm tt ");
                        string AvailBal = "" + item["AvailBal"].ToString();
                        string TakenBal = "" + item["TakenBal"].ToString();
                        string GivenBal = "" + item["GivenBal"].ToString();
                     
                        totalProfit+=double.Parse(Profit);
                        totalAdminProfit += double.Parse(AdminProfit);
                        CpTakenBal += double.Parse(TakenBal);
                        switch (OperatorId)
                        {               
                            case "40": 
                            MSEB_ElecProfit += float.Parse(Profit);
                            MSEB_ElecAdminProfit += double.Parse(AdminProfit);
                            break;
                            case "1100": 
                            FundProfit += float.Parse(Profit); 
                            FundAdminProfit +=double.Parse(AdminProfit);
                            break;
                            case "1300":
                            MoneyTransferProfit += float.Parse(Profit); 
                            MoneyTransferAdminProfit += double.Parse(AdminProfit);
                            break;
                        }
                    }
                    CyberPlateProfit = totalProfit - (MSEB_ElecProfit + FundProfit + MoneyTransferProfit);
                    CyberPlateAdminProfit = totalAdminProfit - (MSEB_ElecAdminProfit + FundAdminProfit + MoneyTransferAdminProfit);
                    cp_serviceReturnType = new CP_serviceReturnType() { CyberPlateProfit = CyberPlateProfit, CyberPlateAdminProfit = CyberPlateAdminProfit, CpTakenBal = CpTakenBal };
                }
            }
            catch (Exception ex) { }

            return cp_serviceReturnType;

        }

    }
}