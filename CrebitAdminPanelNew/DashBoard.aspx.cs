using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using db;
using CrebitAdminPanelNew.Model;
namespace CrebitAdminPanelNew
{
    public partial class DashBoard : System.Web.UI.Page
    {
        private string UserId = string.Empty;
        protected OleDbConnection oledbConn = null;
        public string QueryString;
        public int type = 0;
        public string value = null;
        //public string fromDate;
        //public string toDate;
        public string htmlStr = string.Empty;
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
                        //table_data.InnerHtml = GetdashBoardDetails(0, "0");
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
        protected void btnMatcher_Click(object sender, EventArgs e)
        {
            //List<DBDataVar> listDB = null;
            Dictionary<String, finalDataVar> findDic = new Dictionary<string, finalDataVar>();
            HashSet<string> _API_HashSet_Collection = new HashSet<string>();
            Dictionary<String, DBDataVar> CrebitDbDic = null;
            HashSet<string> _API_HashSet_DB = new HashSet<string>();
            string ConnectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection thisConnection = new SqlConnection(ConnectionString);
            SqlCommand thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandType = CommandType.StoredProcedure;
            thisCommand.CommandText = "CB_ADMIN_DASHBOARD_MatchTransId";
            thisCommand.Parameters.AddWithValue("@FromDate", fromDate.Value);
            thisCommand.Parameters.AddWithValue("@ToDate", toDate.Value);
            thisCommand.Parameters.AddWithValue("@OperaterId", operatorType.Value);
            DataBase db = new DataBase();
            DataSet ds = db.SelectAdaptQry(thisCommand);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection drcDB = ds.Tables[0].Rows;
                //listDB = new List<DBDataVar>();

                CrebitDbDic = new Dictionary<string, DBDataVar>();
              
                //Getting Data From DataBase and Putting it in CrebitDb Dictionary , HashSet_DB,HashSet_collection 
                foreach (DataRow item in drcDB)
                {
                    CrebitDbDic[item["ApiTransactionId"].ToString()] = new DBDataVar() { OperaterName = Convert.ToString(item["OperaterName"]).Trim(), Date = Convert.ToDateTime(item["Date"]), ApiTransactionId = Convert.ToString(item["ApiTransactionId"]) };
                    _API_HashSet_DB.Add(Convert.ToString (item["ApiTransactionId"]));
                    _API_HashSet_Collection.Add(Convert.ToString(item["ApiTransactionId"]));
                }
            }
            try
            {
                string connString = "";
                // delete the Uploaded Excel File after process
                string[] filePaths = Directory.GetFiles(Server.MapPath("~/Uploads/"));
                foreach (string filePath in filePaths)
                  File.Delete(filePath);
                string strFileType = Path.GetExtension(templateExcel.FileName).ToLower();
                string fileName = Path.GetFileName(templateExcel.PostedFile.FileName);
                templateExcel.PostedFile.SaveAs(Server.MapPath("~/Uploads/" + fileName));
               
                if (strFileType.Trim() == ".xls")
                {
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePaths[0] + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (strFileType.Trim() == ".xlsx")
                {
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePaths[0] + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }
                
                string query = "SELECT [OperaterName],[Date],[ApiTransactionId] FROM [Sheet1$]";
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataSet dsExcel = new DataSet();
                    da.Fill(dsExcel);
                    DataRowCollection drc = dsExcel.Tables[0].Rows;
                    Dictionary<String, excelDataVar> excelDic = new Dictionary<string, excelDataVar>();
                    HashSet<string> _API_HashSet_Excel = new HashSet<string>();
                    //Getting Data From Excel file and Putting it in Excel Dictionary , HashSet_Excel,HashSet_collection 
                    foreach (DataRow item in drc)
                    {
                        excelDic[item["ApiTransactionId"].ToString()] = new excelDataVar() { OperaterName = Convert.ToString(item["OperaterName"]).Trim(), Date = Convert.ToDateTime(item["Date"]), ApiTransactionId = Convert.ToString(item["ApiTransactionId"]) };
                        _API_HashSet_Excel.Add(Convert.ToString(item["ApiTransactionId"]));
                        _API_HashSet_Collection.Add(Convert.ToString(item["ApiTransactionId"]));
                    }
                    // Get common TransId b/w DB_Data and Excel Sheet Data
                    _API_HashSet_DB.IntersectWith(_API_HashSet_Excel);
                    //Get Disint Data B/w DB_Data and Excel Sheet Data
                    _API_HashSet_Collection.ExceptWith(_API_HashSet_DB);

                    //Getting Data using  key (KeyTrans) and putting it into dictionary
                    foreach (String keyTrans in _API_HashSet_Collection)
                    {
                        if(excelDic.ContainsKey(keyTrans))
                          findDic[keyTrans] = new finalDataVar() { OperaterName =excelDic[keyTrans].OperaterName , Date = excelDic[keyTrans].Date, ApiTransactionId = excelDic[keyTrans].ApiTransactionId };
                        else if(CrebitDbDic.ContainsKey(keyTrans))
                           findDic[keyTrans] = new finalDataVar() { OperaterName =CrebitDbDic[keyTrans].OperaterName , Date = CrebitDbDic[keyTrans].Date, ApiTransactionId = CrebitDbDic[keyTrans].ApiTransactionId };
                    }

                    // retrive Unmatched Data from dictionarySSSS
                    foreach (var dt in findDic)
                    {
                        htmlStr += "<tr><td>" + dt.Value.OperaterName + "</td><td>" + dt.Value.Date + "</td><td>" + dt.Value.ApiTransactionId + "</td><tr>";

                    }

                    
        
                }
            }
            catch (Exception ex) { ExcelTypemsg.Text = "Selected Excel File Is not in Valid Format "; }
            table_data.InnerHtml = htmlStr;
            

            }

       
    }
}











