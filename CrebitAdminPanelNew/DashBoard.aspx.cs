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

public class excelDataVar { public string OperaterName { get; set; }public DateTime Date { get; set; }public int ApiTransactionId { get; set; } }
public class DBDataVar { public string OperaterName { get; set; }public DateTime Date { get; set; }public int ApiTransactionId { get; set; } }


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
            List<DBDataVar> listDB = null;
            string ConnectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection thisConnection = new SqlConnection(ConnectionString);
            SqlCommand thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandType = CommandType.StoredProcedure;
            thisCommand.CommandText = "CB_ADMIN_DASHBOARD";
            thisCommand.Parameters.AddWithValue("@FromDate", fromDate.Value);
            thisCommand.Parameters.AddWithValue("@ToDate", toDate.Value);
            thisCommand.Parameters.AddWithValue("@OperaterId", operatorType.Value);
            DataBase db = new DataBase();
            DataSet ds = db.SelectAdaptQry(thisCommand);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRowCollection drcDB = ds.Tables[0].Rows;
                listDB = new List<DBDataVar>();
                foreach (DataRow item in drcDB)
                {
                    listDB.Add(new DBDataVar() { OperaterName = Convert.ToString(item["OperaterName"]), Date = Convert.ToDateTime(item["Date"]), ApiTransactionId = Convert.ToInt32(item["ApiTransactionId"]) });

                }
            }
            else
            {
            }
            string connString = "";
            string strFileType = Path.GetExtension(templateExcel.FileName).ToLower();
            string fileName = Path.GetFileName(templateExcel.PostedFile.FileName);
            templateExcel.PostedFile.SaveAs(Server.MapPath("~/Uploads/" + fileName));
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Uploads/"));
            if (strFileType.Trim() == ".xls")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePaths + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
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
                //  grvData.DataSource = dstemplate.Tables[0];
                // grvData.DataBind();
                //  da.Dispose();
                DataRowCollection drc = dsExcel.Tables[0].Rows;
                List<excelDataVar> list = new List<excelDataVar>();

                foreach (DataRow item in drc)
                {
                    list.Add(new excelDataVar() { OperaterName = Convert.ToString(item["OperaterName"]), Date = Convert.ToDateTime(item["Date"]), ApiTransactionId = Convert.ToInt32(item["ApiTransactionId"]) });

                }

    ////// Compare CrebitDB ApiTransId  With ExcelTemplate TransactionId
                for (int i = 0; i < listDB.Count; i++)
                {
                    for (int j = 0; j < listDB.Count; j++)
                    {
                        if ((listDB[i].OperaterName.Equals(list[j].OperaterName)))
                        {
                            if (listDB[i].ApiTransactionId.Equals(list[j].ApiTransactionId))
                            {

                            }
                            else
                            {
                                htmlStr += "<tr><td>" +listDB[i].OperaterName + "</td><td>" + listDB[i].Date + "</td><td>"+" CrebitTrans:" + listDB[i].ApiTransactionId + "</td><tr>";

                            }
                        }
                        else { }
                    }
                }



                ////// Compare ExcelTemplate  ApiTransId  With  CrebitDBTransactionId

                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if ((listDB[i].OperaterName.Equals(list[j].OperaterName)))
                        {
                            if (listDB[i].ApiTransactionId.Equals(list[j].ApiTransactionId))
                            {

                            }
                            else
                            {
                                htmlStr += "<tr><td>" + listDB[i].OperaterName + "</td><td>" + listDB[i].Date + "</td><td>" + " WEBTrans:" + listDB[i].ApiTransactionId + "</td><tr>";

                            }
                        }
                        else { }
                    }
                }
                    table_data.InnerHtml =htmlStr;








                    // delete the Uploaded Excel File after process
                    //foreach (string filePath in filePaths)
                    //    File.Delete(filePath);


                
            }
            //    public void ListComparator()
            //    {
            //    try
            //    {
            //       // List<object> difference = listDB.Except(list).ToList();
            //        List<string> difference = Comparator(List<DBDataVar>listDB,List<excelDataVar>list);
            //        foreach (var value in difference)
            //        {
            //            Console.WriteLine(value);
            //        }
            //    }
            //    catch (System.NullReferenceException e)
            //    {
            //        Console.WriteLine(e.Message);    
            //    }

            //    Console.ReadLine();

            //}
            //public static List<string> dComparator(List<string> list1, List<string> list2)
            //{
            //    IEnumerable<string> differenceQuery = list1.Except(list2);
            //    List<string> differ = null;

            //    foreach (string s in differenceQuery)
            //        differ.Add(s);

            //    return differ;
            //}


        }
    }
}


 