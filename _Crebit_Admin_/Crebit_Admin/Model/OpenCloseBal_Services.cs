using CrebitAdminPanelNew.Model;
using db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Crebit_Admin.Model
{
    public class OpenCloseBal_Services
    {
        public OpenCloseBal_serviceReturnType openCloseBal_serviceReturnType = null;
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public double OpeningBal = 0.0;
        public double ClosingBal = 0.0;

        public OpenCloseBal_serviceReturnType OpenCloseBal(CP_Property cp_Property)
        {
         this._IsSuccess = true;
         this.SpName = "CB_ADMIN_UserOpenCloseBal_Script_function";
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

                        string openBal = "" + item["OpeningBal"].ToString();
                        string closeBal = "" + item["ClosingBal"].ToString();

                        OpeningBal += double.Parse(openBal);
                        ClosingBal += double.Parse(closeBal);
                    }

                    openCloseBal_serviceReturnType = new OpenCloseBal_serviceReturnType()
                    {
                        OpeningBal=Math.Round(OpeningBal,2),
                        ClosingBal = Math.Round(ClosingBal, 2)
                    };

                }
                else
                {
                    openCloseBal_serviceReturnType = new OpenCloseBal_serviceReturnType()
                    {
                        OpeningBal = 0.0,
                        ClosingBal = 0.0
                    };
                }

            }
            catch (Exception ex) { }

            return openCloseBal_serviceReturnType;

        }

    }
}