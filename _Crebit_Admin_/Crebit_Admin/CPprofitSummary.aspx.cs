using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using db;
using GCM.SendToNotificationHub;
using System.Configuration;

namespace CrebitAdminPanelNew
{
    public partial class CPprofitSummary : System.Web.UI.Page
    {
        public int dateAmountAbstractor = 0;
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
                    Response.Redirect("Login.aspx");
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
                        //table_data.InnerHtml = getElectricityFilterData(0, null);
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");

                    }
                }
                catch (Exception ex) { Trace.Warn(ex.Message); Response.Redirect("Login.aspx"); }
            }

        }

        protected void SendNotificationAsync(object sender, EventArgs e)
        {
            string Message = message.Value;
            string ConnectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            string hubName = ConfigurationManager.AppSettings["Microsoft.ServiceBus.HubName"];
            SendGCMNotification.SendNotificationAsync(Message, ConnectionString, hubName);
        
        }
    }
}