using db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrebitAdminRestApi.Model
{
    public class TranSuccess
    {
        public UserSuccessTranReturnType UserSuccess_serviceReturnType = null;
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public string htmlStr = "";
         
        public UserSuccessTranReturnType GetSuccess(UserSuccess_Tran userSuccess_tran)
        {

            this._IsSuccess = true;
            this.SpName = "CB_ADMIN_UserSuccessTran";
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Date", String.IsNullOrEmpty(userSuccess_tran.Date) ? Convert.DBNull : Convert.ToDateTime(userSuccess_tran.Date).Date);
                param[1] = new SqlParameter("@UserName", String.IsNullOrEmpty(userSuccess_tran.UserName) ? Convert.DBNull : userSuccess_tran.UserName);
                DataBase db = new DataBase();
                DataSet ds = db.GetDataSet(this.SpName, param);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    DataRowCollection drc = ds.Tables[0].Rows;
                    ////retriving data from table 
                    foreach (DataRow item in drc)
                    {

                        string Id = item["Id"].ToString();
                        string UserName = item["UserName"].ToString();
                        string ApiTransactionId = "" + item["ApiTransactionId"].ToString();
                        string OperaterName = item["OperaterName"].ToString();
                        string Amount = item["Amount"].ToString();
                        string ServiceType = "" + item["ServiceType"].ToString();
                        string CreditAccountNo = "" + item["CreditAccountNo"].ToString();
                        string Date = "";
                        if (item["Date"] != null)
                        {
                             Date = Convert.ToDateTime(item["Date"]).ToString("d MMM yyyy h:mm tt ");
                        }
                        
                        //string Date = Convert.ToDateTime(item["Date"]).ToString("d MMM yyyy h:mm tt ");
                        string CyberSessionId = "" + item["CyberSessionId"].ToString();
                        string Source = "" + item["Source"].ToString();
                        int Status = Convert.ToInt32(item["Status"]);
                        string APiId = "" + item["ApiTransactionId"].ToString();
                        int ServiceId = Convert.ToInt32(item["ServiceId"]);
                        //string statusHtml = "";
                        string statusText = string.Empty;
                        //string RegDate = Convert.ToDateTime(item["RegDate"]).ToString("d MMM yyyy h:mm tt ");
                        string AvailBal = "" + item["AvailBal"].ToString();
                        string TakenBal = "" + item["TakenBal"].ToString();
                        string GivenBal = "" + item["GivenBal"].ToString();
                      
                        switch (Status)
                        {
                            case 1:
                                statusText = "Success";
                                break;
                            case 0:
                                statusText = "Failed";

                                break;
                            case 2:
                                statusText = "Pending";
                                break;
                            case 3:
                                statusText = "In Progress";
                                break;
                            case 4:
                                statusText = "Reject";
                                break;
                            case 5:
                                statusText = "Received";
                                break;
                            case 7:
                                statusText = "Not Known";
                                break;
                            case 8:
                                statusText = "Awaiting";
                                break;
                            case 9:
                                statusText = "Refunded";
                                break;
                            default:
                                statusText = "Others";
                                break;

                        }


                        htmlStr += "<tr><td>" + Id + "</td><td>" + UserName + "	</td><td>" + ApiTransactionId + "	</td><td>" + OperaterName + "/" + ServiceType
                               + "</td><td>" + Amount + "</td><td>" + APiId +
                               "</td><td>" + CreditAccountNo +
                           "</td><td>" + CyberSessionId + "</td><td>" + Date + "	</td><td>" + statusText + "</td><td><div class='btn-group'><button type='button' value='Check Status'  class='btn btn-default'  data-toggle='modal' data-target='.status_model' > </button></div></td></tr>";
                    }

                }
            }
            catch (Exception ex) { }
            return UserSuccess_serviceReturnType;
        }
    }
}