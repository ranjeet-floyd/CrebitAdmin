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
    public class UserTakenBalServices
    {
        public UserTakenBal_ReturnType userTakenbal_returntype = null;
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        // userTakenBal
        public double userTakenBal = 0.0;

        public UserTakenBal_ReturnType UserTakenBalCount(CP_Property cp_Property)
        {

            this._IsSuccess = true;
            this.SpName = "CB_ADMIN_Cb_TakenBalance";
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@UserType", ((cp_Property.UserType <= 0) ? Convert.DBNull : cp_Property.UserType));
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
                        string TakenBal = "" + item["TakenAmount"].ToString();
                        userTakenBal += double.Parse(TakenBal);
                    }
                    userTakenbal_returntype = new UserTakenBal_ReturnType()
                   {
                       userTakenBal = Math.Round(userTakenBal, 2)
                   };

                }
                else
                {
                    userTakenbal_returntype = new UserTakenBal_ReturnType()
                    {
                        userTakenBal =0.0
                    };
                    
                }

        }
            catch (Exception ex) { }

            return userTakenbal_returntype;
        }
    }
}