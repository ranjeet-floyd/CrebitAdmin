using db;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CrebitAdminRestApi.Model
{
    public class DAS_services
    {
        public DAS_serviceReturnType das_serviceReturnType = null;
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public DAS_serviceReturnType GetUserCount(DAS_Property das_Property)
        {

            this._IsSuccess = true;
            this.SpName = "CB_ADMIN_UserCount";
            try
            {
               
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@UserType", das_Property.UserType);
                param[1] = new SqlParameter("@Date", String.IsNullOrEmpty( das_Property.Date)  ? Convert.DBNull : Convert.ToDateTime(das_Property.Date).Date);
                DataBase db = new DataBase();
                DataSet ds = db.GetDataSet(this.SpName, param);

                if (ds != null)
                {

                    DataRowCollection drc = ds.Tables[0].Rows;
                    foreach (DataRow item in drc)
                    {
                        string dr = "" + item["column1"].ToString();
                        das_serviceReturnType = new DAS_serviceReturnType() { totalCount = dr };
                    }
                }
            }
            catch (Exception ex) { }

            return das_serviceReturnType;

        }

    }
}