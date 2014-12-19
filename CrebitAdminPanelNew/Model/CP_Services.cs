using db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrebitAdminPanelNew.Model
{
    public class CP_Services
    {
        public CP_serviceReturnType cp_serviceReturnType = null;
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public CP_serviceReturnType GetUserCount(CP_Property cp_Property)
        {

            this._IsSuccess = true;
            this.SpName = "CB_ADMIN_CPprofitSummary";
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@UserType", cp_Property.UserType);
                param[1] = new SqlParameter("@Date", String.IsNullOrEmpty(cp_Property.Date) ? Convert.DBNull : Convert.ToDateTime(cp_Property.Date).Date);
                param[2] = new SqlParameter("@UserName", cp_Property.UserName);
                DataBase db = new DataBase();
                DataSet ds = db.GetDataSet(this.SpName, param);

                if (ds != null)
                {

                    DataRowCollection drc = ds.Tables[0].Rows;
                    foreach (DataRow item in drc)
                    {
                        //string dr = "" + item["column1"].ToString();
                        //cp_serviceReturnType = new CP_serviceReturnType() { totalCount = dr };
                    }
                }
            }
            catch (Exception ex) { }

            return cp_serviceReturnType;

        }

    }
}