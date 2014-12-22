using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using db;
using CrebitAdminPanelNew.Model;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using ClosedXML.Excel; 
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
                CrebitDbDic = new Dictionary<string, DBDataVar>();
                //Getting Data From DataBase and Putting it in CrebitDb Dictionary , HashSet_DB,HashSet_collection 
                foreach (DataRow item in drcDB)
                {
                    CrebitDbDic[item["ApiTransactionId"].ToString()] = new DBDataVar() { OperaterName = Convert.ToString(item["OperaterName"]).Trim(), Date = Convert.ToDateTime(item["Date"]), ApiTransactionId = Convert.ToString(item["ApiTransactionId"]) };
                    _API_HashSet_DB.Add(Convert.ToString(item["ApiTransactionId"]));
                    _API_HashSet_Collection.Add(Convert.ToString(item["ApiTransactionId"]));
                }
            }
           
            
            try
            {

                HttpPostedFile file = templateExcel.PostedFile;
                string excelConnectionString = string.Empty;
                // delete the Uploaded Excel File after process
                string filePaths = Server.MapPath("App_Data");

               //Empty Directory
                if (Directory.Exists(filePaths))
                    {
                        System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(filePaths);

                        foreach (FileInfo files in downloadedMessageInfo.GetFiles())
                        {
                            files.Delete();
                        }
                        foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
                        {
                            dir.Delete(true);
                        }
                    
                    }
                string fileExtension = System.IO.Path.GetExtension(file.FileName);

                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    if (Directory.Exists(filePaths))
                    {
                        EmptyDir(filePaths); //clean directory
                        string fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "_" + file.FileName;
                        file.SaveAs(filePaths + "//" + fileName);
                        //SaveDataToDB(filePaths + "//" + fileName, fileExtension);
                        string fileLocation = filePaths + "//" + fileName;


                        if (fileExtension == ".xls" || fileExtension == ".xlsx")
                        {
                            //excelConnectionString = "Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};DBQ=" + fileName + ";";Excel 12.0 
                            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0 Xml;HDR=Yes;IMEX=2\"";
                            //connection String for xls file format.
                            if (fileExtension == ".xls")
                            {
                                excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                            }
                            //connection String for xlsx file format.
                            else if (fileExtension == ".xlsx")
                            {
                                excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0 Xml;HDR=Yes;IMEX=2\"";
                            }
                        }

                    } else throw new Exception("App_Data Folder do not Exist. Please create.");
                } else throw new Exception("Only .xls and .xlsx formats are acceptable.");
                        
                        string query = "SELECT [OperaterName],[Date],[ApiTransactionId] FROM [Sheet1$]";
                using (OleDbConnection conn = new OleDbConnection(excelConnectionString))
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
                    //Get distinct Data B/w DB_Data and Excel Sheet Data
                    _API_HashSet_Collection.ExceptWith(_API_HashSet_DB);


                    //Getting Data using  key (KeyTrans) and putting it into dictionary
                    foreach (String keyTrans in _API_HashSet_Collection)
                    {
                        if (excelDic.ContainsKey(keyTrans))
                            findDic[keyTrans] = new finalDataVar() { OperaterName = excelDic[keyTrans].OperaterName, Date = excelDic[keyTrans].Date, ApiTransactionId = "CyberPlate::" + excelDic[keyTrans].ApiTransactionId };
                        else if (CrebitDbDic.ContainsKey(keyTrans))
                            findDic[keyTrans] = new finalDataVar() { OperaterName = CrebitDbDic[keyTrans].OperaterName, Date = CrebitDbDic[keyTrans].Date, ApiTransactionId = "Crebit::" + CrebitDbDic[keyTrans].ApiTransactionId };
                    }

                    // retrive Unmatched Data from dictionary
                    foreach (var dt in findDic)
                    {
                        htmlStr += "<tr><td>" + dt.Value.OperaterName + "</td><td>" + dt.Value.Date + "</td><td>" + dt.Value.ApiTransactionId + "</td><tr>";

                    }



                }
            }
            catch (Exception ex) { ExcelTypemsg.Text = "" + ex.Message; }
            table_data.InnerHtml = htmlStr;

            
        }


        //Empty Dir.
        private void EmptyDir(string dirPath)
        {
            System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(dirPath);

            foreach (FileInfo file in downloadedMessageInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
            {
                dir.Delete(true);
            }
        }


      //Export Success and Failed Transaction To Excel

        //protected void btnExport_Click(object sender, EventArgs e)
        //{
        //    string ConnectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        //    SqlConnection thisConnection = new SqlConnection(ConnectionString);
        //    SqlCommand thisCommand = thisConnection.CreateCommand();
        //    thisCommand.CommandType = CommandType.StoredProcedure;
        //    thisCommand.CommandText = "CB_ADMIN_ExportTo_Excel";
        //    thisCommand.Parameters.AddWithValue("@FromDate", fromDate.Value);
        //    thisCommand.Parameters.AddWithValue("@ToDate", toDate.Value);
        //    DataBase db = new DataBase();
        //    DataSet ds = db.SelectAdaptQry(thisCommand);


        //    if (ds != null && ds.Tables.Count > 0)
        //    {

        //    ////////////////////////////////////////
        //       // System.Data.DataTable dtMainSQLData = new System.Data.DataTable();
        //        //da.Fill(dtMainSQLData);
        //        DataColumnCollection dcCollection = ds.Tables[0].Columns;
        //        // Export Data into EXCEL Sheet
        //        Microsoft.Office.Interop.Excel._Application ExcelApp = new Excel.Application();
        //        ExcelApp.Application.Workbooks.Add(Type.Missing);

                   

        //            // ExcelApp.Cells.CopyFromRecordset(objRS);
        //            for (int i = 1; i < ds.Tables[0].Rows.Count + 1; i++)
        //            {
        //                for (int j = 1; j < ds.Tables[0].Columns.Count + 1; j++)
        //                {
        //                    if (i == 1)

        //                        ExcelApp.Cells[i, j] = dcCollection[j - 1].ToString();

        //                    else

        //                        ExcelApp.Cells[i, j] = ds.Tables[0].Rows[i - 1][j - 1].ToString();



        //                }
        //            }
        //            ExcelApp.ActiveWorkbook.SaveCopyAs("E:\\1.xlsx");
        //            ExcelApp.ActiveWorkbook.Saved = true;
        //            ExcelApp.Quit();
        //            byte[] Content = File.ReadAllBytes("E:\\1.xlsx");
        //            Response.ContentType = ".xlsx";
        //            Response.AddHeader("content-disposition", "attachment; filename=" + 1 + ".xlsx");
        //            Response.BufferOutput = true;;
        //            Response.OutputStream.Write(Content, 0, Content.Length);
        //            Response.End();


        //           // MessageBox.Show("Data Exported Successfully");
                   
        //        }
        //}

        //Export Success and Failed Transaction To Excel
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection thisConnection = new SqlConnection(ConnectionString);
            SqlCommand thisCommand = thisConnection.CreateCommand();
            thisCommand.CommandType = CommandType.StoredProcedure;
            thisCommand.CommandText = "CB_ADMIN_ExportTo_Excel";
            thisCommand.Parameters.AddWithValue("@FromDate", fromDate.Value);
            thisCommand.Parameters.AddWithValue("@ToDate", toDate.Value);
            DataBase db = new DataBase();
            DataSet ds = db.SelectAdaptQry(thisCommand);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        thisCommand.Connection = thisConnection;
                        sda.SelectCommand = thisCommand;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "Customers");

                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }} } } }
    }
    }







