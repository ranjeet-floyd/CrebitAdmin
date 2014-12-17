using db;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
                //string ConnectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                //SqlConnection thisConnection = new SqlConnection(ConnectionString);
                //SqlCommand thisCommand = thisConnection.CreateCommand();
                //thisCommand.CommandType = CommandType.StoredProcedure;
                //thisCommand.CommandText = "CB_ADMIN_UserCount";
                //thisCommand.Parameters.AddWithValue("@UserType", das_Property.UserType);
                //ds = db.SelectAdaptQry(thisCommand);
                 
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@UserType", das_Property.UserType);
                      DataBase db = new DataBase();
                      DataSet ds  = db.GetDataSet(this.SpName, param);
                if (ds != null)
                {
                    
                    DataRowCollection drc = ds.Tables[0].Rows;
                    foreach (DataRow item in drc)
                    {
                        string dr = ds.ToString();
                        das_serviceReturnType = new DAS_serviceReturnType() { totalCount = dr };
                    }
                }
            }
            catch (Exception ex) { }

            return das_serviceReturnType;

        }

    }
}