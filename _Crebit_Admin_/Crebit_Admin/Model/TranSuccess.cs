using CrebitAdminPanelNew.Model;
using db;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrebitAdminPanelNew.Model
{
    public class TranSuccess
    {
        public UserSuccessTranReturnType transReturn = null;
        public List<UserSuccessTranReturnTypes> transReurns = null;
        public bool _IsSuccess { get; set; }
        private string SpName { get; set; }
        public string htmlStr = "";

        public UserSuccessTranReturnType GetSuccess(UserSuccess_Tran userSuccess_tran)
        {

            this._IsSuccess = true;
            this.SpName = "CB_ADMIN_UserSuccessTran";
            transReturn = new UserSuccessTranReturnType();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Date", String.IsNullOrEmpty(userSuccess_tran.Date) ? Convert.DBNull : Convert.ToDateTime(userSuccess_tran.Date).Date);
                param[1] = new SqlParameter("@UserName", String.IsNullOrEmpty(userSuccess_tran.UserName) ? Convert.DBNull : userSuccess_tran.UserName);
                DataBase db = new DataBase();
                DataSet ds = db.GetDataSet(this.SpName, param);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    transReurns = new List<UserSuccessTranReturnTypes>();

                    var Json = JsonConvert.SerializeObject(ds.Tables[0], Formatting.None);
                    transReurns = JsonConvert.DeserializeObject<List<UserSuccessTranReturnTypes>>(Json);
                    transReturn.dL_TransactionReturns = transReurns;


                }

            }
            catch (Exception ex) { }
            return transReturn;
        }
    }
}