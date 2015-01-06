using db;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CrebitAdminPanelNew.Model
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

        public CP_serviceReturnType ProfitCount(CP_Property cp_Property)
        {

            this._IsSuccess = true;
            this.SpName = "CB_ADMIN_CPprofitSummary";
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@UserType", ((cp_Property.UserType <=0 ) ? Convert.DBNull : cp_Property.UserType));
                param[1] = new SqlParameter("@Date", String.IsNullOrEmpty(cp_Property.Date) ? Convert.DBNull : Convert.ToDateTime(cp_Property.Date).Date);
                param[2] = new SqlParameter("@UserName", String.IsNullOrEmpty(cp_Property.UserName) ? Convert.DBNull : cp_Property.UserName);
                DataBase db = new DataBase();
                DataSet ds = db.GetDataSet(this.SpName, param);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    DataRowCollection drc = ds.Tables[0].Rows;
                    ////retriving data from table 
                    foreach (DataRow item in drc)
                    {

                        string Profit = "" + item["UserProfit"].ToString();
                        string OperatorId = "" + item["OperatorId"].ToString();
                        string AdminProfit = "" + item["AdminProfit"].ToString();

                        totalProfit += double.Parse(Profit);
                        totalAdminProfit += double.Parse(AdminProfit);
                        //CpTakenBal += double.Parse(TakenBal);
                        if (OperatorId == "40")
                        {
                            MSEB_ElecProfit += float.Parse(Profit);
                            MSEB_ElecAdminProfit += double.Parse(AdminProfit);
                        }
                        else if (OperatorId == "1100")
                        {
                            FundProfit += float.Parse(Profit);
                            FundAdminProfit += double.Parse(AdminProfit);

                        }
                        else if (OperatorId == "1300")
                        {
                            MoneyTransferProfit += float.Parse(Profit);
                            MoneyTransferAdminProfit += double.Parse(AdminProfit);

                        }
                    }
                    CyberPlateProfit = Math.Round(totalProfit - (MSEB_ElecProfit + FundProfit + MoneyTransferProfit), 2);
                    CyberPlateAdminProfit = Math.Round(totalAdminProfit - ( MSEB_ElecAdminProfit + FundAdminProfit + MoneyTransferAdminProfit), 2);

                    cp_serviceReturnType = new CP_serviceReturnType()
                    {
                        CyberPlateProfit = CyberPlateProfit,
                        CyberPlateAdminProfit = CyberPlateAdminProfit,
                        MSEB_ElecAdminProfit = Math.Round(MSEB_ElecAdminProfit, 2),
                        FundAdminProfit = Math.Round(FundAdminProfit, 2),
                        MoneyTransferAdminProfit = Math.Round(MoneyTransferAdminProfit, 2)
                    };

                }
                else {
                    cp_serviceReturnType = new CP_serviceReturnType()
                    {
                        CyberPlateProfit = 0.0,CyberPlateAdminProfit = 0.0,MSEB_ElecAdminProfit = 0.0,
                        FundAdminProfit = 0.0,MoneyTransferAdminProfit = 0.0};
                }

            }
            catch (Exception ex) { }

            return cp_serviceReturnType;

        }

    }
}