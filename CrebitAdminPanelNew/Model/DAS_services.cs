using db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrebitAdminPanelNew.Model
{
    public class DAS_services
    {
        public DAS_serviceReturnType das_serviceReturnType = null;
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        DataSet ds = null;
        DataBase db = new DataBase();
        public DAS_serviceReturnType GetUserCount(DAS_Property das_Property)
        {
           
            this._IsSuccess = true;
            this.SpName = "CB_ADMIN_UserCount";
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@UserType", das_Property.UserType);
                ds = db.GetDataSet(this.SpName, param);
                if (ds != null)
                {

                    string dr = ds.ToString();
                    das_serviceReturnType = new DAS_serviceReturnType() { totalCount = dr };

                }
            }
            catch (Exception ex) { }

            return das_serviceReturnType;

        }

    }
}