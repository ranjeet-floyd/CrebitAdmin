using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using db;

namespace CrebitAdminPanelNew
{
    public partial class Bank_Transfer : System.Web.UI.Page
    {
        public int SuccessCount, FailedCount, PendingCount, InProgressCount, otherCount, RejectCount, ReceivedCount, NotKnownCount, AwaitingCount;
        public int dateAmountAbstractor = 0;
        public float failed_AmountCount, success_AmountCount, Rejected_AmountCount, InPro_AmountCount;
        private string UserId = string.Empty;
        public string QueryString;
        public int type = 0;
        public string value = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            QueryString = Request.QueryString["u"];
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(QueryString))
                {
                    Server.Transfer("Login.aspx");
                }
                try
                {
                    int Id = 0;
                    string[] qArray = Request.QueryString["u"].ToString().Split('|');
                    string key = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(qArray[1]));
                    string userId = qArray[0].ToString();
                    Handler obj = new Handler();
                    Id = obj.Checker(userId, key);

                    if (Id != 0)
                    {
                        table_data.InnerHtml = GetBankTransFilterDetails(0, "0");
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("Login.aspx");
                }

            }

        }

        protected string GetBankTransFilterDetails(int type, string value)
        {

            string htmlStr = "";
            try
            {
                SuccessCount = FailedCount = PendingCount = InProgressCount = otherCount = RejectCount = ReceivedCount = NotKnownCount = AwaitingCount = 0;
                failed_AmountCount = success_AmountCount = Rejected_AmountCount = InPro_AmountCount = 0.0F;
                string ConnectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                SqlConnection thisConnection = new SqlConnection(ConnectionString);
                SqlCommand thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandType = CommandType.StoredProcedure;
                thisCommand.CommandText = "CB_ADMIN_BankTransferTable";
                thisCommand.Parameters.AddWithValue("@Type", type);
                thisCommand.Parameters.AddWithValue("@Value", value);

                DataBase db = new DataBase();
                DataSet ds = db.SelectAdaptQry(thisCommand);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string statusOption = "";
                    DataRowCollection drc = ds.Tables[0].Rows;
                    foreach (DataRow item in drc)
                    {

                        string Id = "" + item["Id"].ToString();
                        string UserName = "" + item["UserName"];
                        string CusMobile = "" + item["CusMobile"];
                        string BankName = "" + item["BankName"];
                        string Account = "" + item["Account"];
                        string IFSC = "" + item["IFSC"];
                        string Amount = item["Amount"].ToString();
                        string TransactionId = "" + item["TransactionId"];
                        string BankTransId = "" + item["BankTransId"];
                        string ReqDate = Convert.ToDateTime(item["RequestDate"]).ToString("d MMM yyyy h:mm tt ");
                        string Comments = "" + item["Comment"];
                        int StatusId = Convert.ToInt32(item["StatusId"]);
                        string statusHtml = "";
                        string statusText = string.Empty;

                        //DateTime theDateA = DateTime.Parse(ReqDate);
                      //abstract Amount With Currentdate 
                        if (dateAmountAbstractor == 0)
                        {
                            DateTime fromdate = Convert.ToDateTime(ReqDate);
                            string date = fromdate.GetDateTimeFormats('d')[0];
                            DateTime now = DateTime.Now;
                            string nowdate = now.GetDateTimeFormats('d')[0];

                            if (nowdate.Equals(date))
                            {
                                switch (StatusId)
                                {
                                    case 0:
                                        FailedCount += 1;
                                        failed_AmountCount += float.Parse(Amount);
                                        break;

                                    case 1:
                                        SuccessCount += 1;
                                        success_AmountCount += float.Parse(Amount);
                                        break;
                                                                           
                                    case 3:
                                        InProgressCount += 1;
                                        InPro_AmountCount += float.Parse(Amount);
                                        break;
                                    case 4:
                                        RejectCount += 1;
                                        Rejected_AmountCount += float.Parse(Amount);
                                        break;
                                }
                            }
                        }
                        else
                        {

                            switch (StatusId)
                            {
                                case 0:
                                    FailedCount += 1;
                                    failed_AmountCount += float.Parse(Amount);
                                    break;

                                case 1:
                                    SuccessCount += 1;
                                    success_AmountCount += float.Parse(Amount);
                                    break;
                                                                    
                                case 3:
                                    InProgressCount += 1;
                                    InPro_AmountCount += float.Parse(Amount);
                                    break;
                                case 4:
                                    RejectCount += 1;
                                    Rejected_AmountCount += float.Parse(Amount);
                                    break;
                                    
                            }
                        }
                        switch (StatusId)
                        {
                            case 1:
                                statusHtml = "<button disabled type='button' id='btn_" + Id + "' class='btn btn-success dropdown-toggle' data-toggle='dropdown'>";
                                //SuccessCount += 1;
                                statusText = "Success";
                                //statusOption += "<li ><a id='atag_" + Id + "_1' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>Success</a></li>";
                                //statusOption += "<li><a id='atag_" + Id + "_0' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>Failed</a></li>  
                                //statusOption += "<li ><a id='atag_" + Id + "_2' data-toggle='modal'  data-target='.status_model' onclick='setModelHiddenValu(this)'>Pending</a></li>";
                                //statusOption += "<li ><a id='atag_" + Id + "_3' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>In Progress</a></li>";
                                //statusOption += "<li ><a id='atag_" + Id + "_4' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>Reject</a></li>";
                                break;
                            case 0:
                                statusHtml = "<button disabled type='button' id='btn_" + Id + "' class='btn btn-danger dropdown-toggle' data-toggle='dropdown'>";
                                //FailedCount += 1;
                                statusText = "Failed";

                                break;
                            case 2:
                                statusHtml = "<button type='button' id='btn_" + Id + "' class='btn btn-warning dropdown-toggle' data-toggle='dropdown'>";
                               // PendingCount += 1;
                                statusText = "Pending";
                                statusOption += "<li ><a id='atag_" + Id + "_1' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>Success</a></li>";
                                statusOption += "<li><a id='atag_" + Id + "_0' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>Failed</a></li>";
                                //statusOption += "<li ><a id='atag_" + Id + "_2' data-toggle='modal'  data-target='.status_model' onclick='setModelHiddenValu(this)'>Pending</a></li>";
                                statusOption += "<li ><a id='atag_" + Id + "_3' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>In Progress</a></li>";
                                statusOption += "<li ><a id='atag_" + Id + "_4' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>Reject</a></li>";
                                break;
                            case 3:
                                statusHtml = "<button type='button' id='btn_" + Id + "' class='btn btn-info dropdown-toggle' data-toggle='dropdown'>";
                                //InProgressCount += 1;
                                statusText = "In Progress";
                                statusOption += "<li ><a id='atag_" + Id + "_1' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>Success</a></li>";
                                statusOption += "<li><a id='atag_" + Id + "_0' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>Failed</a></li>";
                                statusOption += "<li ><a id='atag_" + Id + "_2' data-toggle='modal'  data-target='.status_model' onclick='setModelHiddenValu(this)'>Pending</a></li>";
                                //statusOption += "<li ><a id='atag_" + Id + "_3' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>In Progress</a></li>";
                                statusOption += "<li ><a id='atag_" + Id + "_4' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>Reject</a></li>";
                                break;
                            case 4:
                                statusHtml = "<button disabled type='button' id='btn_" + Id + "' class='btn btn-warning dropdown-toggle' data-toggle='dropdown'>";
                                //RejectCount += 1;
                                statusText = "Reject";
                                break;
                            //case 5:
                            //    statusHtml = "<button type='button' id='btn_" + Id + "' class='btn btn-primary dropdown-toggle' data-toggle='dropdown'>";
                            //    ReceivedCount += 1;
                            //    statusText = "Received";
                            //    break;
                            //case 7:
                            //    statusHtml = "<button type='button' id='btn_" + Id + "' class='btn btn-warning dropdown-toggle' data-toggle='dropdown'>";
                            //    NotKnownCount += 1;
                            //    statusText = "Not Known";
                            //    break;
                            //case 8:
                            //    statusHtml = "<button type='button' id='btn_" + Id + "' class='btn btn-active  dropdown-toggle' data-toggle='dropdown'>";
                            //    AwaitingCount += 1;
                            //    statusText = "Awaiting";
                            //    break;
                            default:
                                statusHtml = "<button type='button' id='btn_" + Id + "' class='btn btn-default dropdown-toggle' data-toggle='dropdown'>";
                                //otherCount += 1;
                                statusText = "Others";
                                statusOption += "<li ><a id='atag_" + Id + "_1' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>Success</a></li>";
                                statusOption += "<li><a id='atag_" + Id + "_0' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>Failed</a></li>";
                                statusOption += "<li ><a id='atag_" + Id + "_2' data-toggle='modal'  data-target='.status_model' onclick='setModelHiddenValu(this)'>Pending</a></li>";
                                statusOption += "<li ><a id='atag_" + Id + "_3' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>In Progress</a></li>";
                                statusOption += "<li ><a id='atag_" + Id + "_4' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>Reject</a></li>";
                                break;
                        }


                        htmlStr += "<tr><td>" + Id + "</td><td id='user_" + Id + "'>" + UserName + "</td><td id='CusMOb_" + Id + "'>" + CusMobile + "	</td><td>" + Account + "	</td><td>" + IFSC +
                            "	</td><td>" + Amount + "	</td><td>" + TransactionId +
                        "<td>" + BankTransId + "</td></td><td>" + ReqDate + "</td><td>" + Comments + "</td><td>" + statusText + "<td><div class='btn-group dropup'>" + statusHtml;
                        htmlStr += "<span class='caret'></span><span class='sr-only'>Toggle Dropdown</span>  </button> ";
                        htmlStr += "<ul id='selectionToggle' class='dropdown-menu' role='menu'>" + statusOption;

                        //htmlStr += "<li ><a id='atag_" + Id + "_5' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>Received</a></li>";
                        //htmlStr += "<li ><a id='atag_" + Id + "_6' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>Others</a></li>";
                        //htmlStr += "<li ><a id='atag_" + Id + "_7' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>Not Known</a></li>";
                        //htmlStr += "<li ><a id='atag_" + Id + "_8' data-toggle='modal' data-target='.status_model' onclick='setModelHiddenValu(this)'>Awaiting</a></li>";
                        htmlStr += "</ul></div></td><td></tr>";
                    }
                }
                else
                    htmlStr = "<tr><td>No Data </td></tr>";
            }
            catch (Exception ex)
            {
                error_text.ForeColor = System.Drawing.Color.Red;
                error_text.Text = "Enter Correct Data!";
                Trace.Warn(ex.Message);
            }
            return htmlStr;
        }

        protected void btnFilter_ServerClick(object sender, EventArgs e)
        {
            dateAmountAbstractor = 1;
            try
            {
                type = Int32.Parse(SeletionList.Value);
                switch (type)
                {
                    case 4:
                       
                        value = inputtxtDate.Value.ToString();
                        break;
                    case 7:
                        value = statusList.Value;

                        break;
                    default:
                        value = inputControl.Text;
                        break;
                }
                table_data.InnerHtml = GetBankTransFilterDetails(type, value);
            }
            catch (Exception ex) { Trace.Warn(ex.Message); }
        }

        protected void btnInsert_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string tran = inputTransactionToggleForm.Value;
                string comment = inputCommentToggleForm.Value;
                int tblId = Int32.Parse(hdnBtnId.Value);
                int tbstatus = Int32.Parse(hdbBtnLi.Value);
                // Changes Made By Jhamman on 26th Nov 2014 
                //Getting User Mobile number and Cutomer Mobile Number When Status Changed 
                string tbUserName = hdUserName.Value;
                string tbCusMob = hdCumMob.Value;
                Handler obj = new Handler();
                obj.AddBankTranCommentData(tblId, tran, comment, tbstatus);
                table_data.InnerHtml = GetBankTransFilterDetails(0, "0");
                // Changes Made By Jhamman on 26th Nov 2014 
                // Sending Message To User and Cutomer about  Status .
                 switch (tbstatus)
                {
                         // BL_SMS Method Calling To sending Message.
                    case 0:BL_SMS.SendSMS(tbUserName, "Failed");
                    BL_SMS.SendSMS(tbCusMob, "Failed"); break;

                    case 1:BL_SMS.SendSMS(tbUserName, "Success");
                    BL_SMS.SendSMS(tbCusMob, "Success"); break;

                    case 4:  BL_SMS.SendSMS(tbUserName, "Success");
                    BL_SMS.SendSMS(tbCusMob, "Request Reject"); break;
                                     
                
                
                }
            }
            catch (Exception ex) { Trace.Warn(ex.Message); }
        }

        protected void btnClose_ServerClick(object sender, EventArgs e)
        {


        }
    }
}