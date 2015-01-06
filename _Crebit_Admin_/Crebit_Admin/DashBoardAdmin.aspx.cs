using CrebitAdminPanelNew;
using CrebitAdminPanelNew.Model;
using db;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Crebit_Admin
{
    public partial class DashBoardAdmin : System.Web.UI.Page
    {
        //Total Success Failed Count And Amount
        public int SuccessCount,FailedCount;
        public int Today_SuccessCount, Today_FailedCount;
        
        public float SuccessAmount, FailedAmount;
        public float Today_SuccessAmount, Today_FailedAmount;
        
        //CP Success Failed Count And Amount
        public int CP_SuccessCount, CP_FailedCount;
        public int CP_Today_SuccessCount, CP_Today_FailedCount;
        public float CP_SuccessAmount, CP_FailedAmount;
        public float CP_Today_SuccessAmount, CP_Today_FailedAmount;
        


        
        // Bank Success, Failed, InProgress Count
        public int Bank_SuccessCount,Bank_FailedCount,Bank_InProgressCount;
        public int Bank_Today_SuccessCount,Bank_Today_FailedCount,Bank_Today_InProgressCount;


      
         // Bank Success, Failed, InProgress Amount
        public float Bank_SuccessAmount,Bank_FailedAmount,Bank_InProgressAmount;
        public float Bank_Today_SuccessAmount,Bank_Today_FailedAmount, Bank_Today_InProgressAmount;


              ////Electricity Success , Failed ,In Progress Count 
                public int Electricity_SuccessCount,Electricity_FailedCount,Electricity_InProgressCount;
                 public int Electricity_Today_SuccessCount,Electricity_Today_FailedCount,Electricity_Today_InProgressCount;
            ////Electricity Success , Failed ,In Progress Amount 
                   public float Electricity_SuccessAmount,Electricity_FailedAmount,Electricity_InProgressAmount;
                   public float Electricity_Today_SuccessAmount, Electricity_Today_FailedAmount, Electricity_Today_InProgressAmount;

                   ////Refund Request Refund,  Reject, InProgress Count
                   public int RR_RefundCount, RR_RejectCount, RR_InProgressCount;
                   public int RR_Today_RefundCount, RR_Today_RejectCount, RR_Today_InProgressCount;
                   ////Refund Request Refund,  Reject, InProgress Amount    
                   public float RR_RefundAmount, RR_RejectAmount, RR_InProgressAmount;
                   public float RR_Today_RefundAmount, RR_Today_RejectAmount, RR_Today_InProgressAmount; 

                      /// User Type Count and AvailBalance 
                   public int EnterpriseCount,PersonalCount;
                   public float EnterpriseAmount, PersonalAmount;

                    /// fund Transfer Count and Total Balance
                    public int E_E_Count,E_P_Count,Today_E_E_Count,Today_E_P_Count;
                    public float E_E_Amount, E_P_Amount, Today_E_E_Amount, Today_E_P_Amount;
                        
                   
                 // Fund Transfer Failed Count
                  public int Fund_FailedCount, Fund_Today_FailedCount;
                  public float Fund_FailedAmount, Fund_Today_FailedAmount;

        // CyberPlate ProfiCount By Admin, EnterPrise , Personal
                  public int TOTAL_CP_EntCount, TOTAL_Today_CP_EntCount;
                  public float TOTAL_CP_EntProfit, TOTAL_Today_CP_EntProfit;
        public int CP_AdminCount, CP_EntCount,CP_PerCount;
        public int Today_CP_AdminCount,Today_CP_EntCount,Today_CP_PerCount;
        // CyberPlate Profit Amount By Admin, EnterPrise , Personal
         public float CP_AdminProfit,CP_EntProfit,CP_PerProfit;
         public float Today_CP_AdminProfit, Today_CP_EntProfit, Today_CP_PerProfit;

        // Admin Profit By MSEB, FUND , Monthly Charge , Money Transfer

         public int Elect_CP_AdminCount, Fund_CP_AdminCount, MonthlyCharge_CP_AdminCount, Bank_CP_AdminCount;
         public int Elect_Today_CP_AdminCount, Fund_Today_CP_AdminCount, MonthlyCharge_Today_CP_AdminCount, Bank_Today_CP_AdminCount;
         public float Elect_CP_AdminProfit, Fund_CP_AdminProfit, MonthlyCharge_CP_AdminProfit, Bank_CP_AdminProfit;
         public float Elect_Today_CP_AdminProfit, Fund_Today_CP_AdminProfit, MonthlyCharge_Today_CP_AdminProfit, Bank_Today_CP_AdminProfit;


        ////Profit By Electricty, Fund, Bank 
         public int Elect_ENT_ProfitCount, Elect_PER_ProfitCount, Bank_ENT_ProfitCount, Bank_PER_ProfitCount, FUND_ENT_ProfitCount, FUND_PER_ProfitCount;
         public int Elect_Today_ENT_ProfitCount, Elect_Today_PER_ProfitCount, FUND_Today_ENT_ProfitCount, FUND_Today_PER_ProfitCount
         , Bank_Today_ENT_ProfitCount, Bank_Today_PER_ProfitCount;
         public float Elect_ENT_ProfitAmount, Elect_PER_ProfitAmount, FUND_ENT_ProfitAmount, FUND_PER_ProfitAmount, Bank_ENT_ProfitAmount, Bank_PER_ProfitAmount;
         public float Elect_Today_ENT_ProfitAmount, Elect_Today_PER_ProfitAmount, FUND_Today_ENT_ProfitAmount, FUND_Today_PER_ProfitAmount, Bank_Today_ENT_ProfitAmount, Bank_Today_PER_ProfitAmount;





          //Fund Tnasfer ProfitAmount By Enterprise TO  Persoanl Transfer
         public float Fund_E_to_P_Profit,Fund_Today_E_to_P_Profit;


         // Profit By Bank Count , Amount
             public int Bank_ProfitCount,Today_Bank_ProfitCount;
             public float Bank_ProfitAmount, Today_Bank_ProfitAmount;
             public float Bank_SuccessProfitAmount,Bank_InProgressProfitAmount;
             public float Bank_Today_InProgressProfitAmount, Bank_Today_SuccessProfitAmount;

             
         // Profit By Electricity Count , Amount
         public int Elec_ProfitCount,Today_Elec_ProfitCount;
         public float Elec_ProfitAmount , Today_Elec_ProfitAmount ;


        
                
        // crebit Monthly Charge Success Count And Amount From Persoanl User And Enterprise
           public int Crebit_Monthly_Charge_SuccessCount ,Today_Crebit_Monthly_Charge_SuccessCount ;
           public float Crebit_Monthly_Charge_SuccessAmount, Today_Crebit_Monthly_Charge_SuccessAmount;
           public int CrebitCharges_PerCount, Today_CrebitCharges_PerCount;
           public float CrebitCharges_PerAmount, Today_CrebitCharges_PerAmount;





                                           
     
        // Dictionary And HashSet to Get Distinct UserName and AvailBalance
                  //Dictionary<String, UserNameDataVar> UserTypeDic= new Dictionary<string, UserNameDataVar>();
                 // HashSet<string> DistinctE_T_FundTarnsfer = new HashSet<string>();
                  //Dictionary<String, DistinctUserNameDataVar> findDic = new Dictionary<string, DistinctUserNameDataVar>();

          
        public string QueryString;

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
                        GetTransactionData();
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

        protected void GetTransactionData()
        {
            
            try
            {
                //Total Success and Failed  Counts 
                SuccessCount=FailedCount=0;
                Today_SuccessCount=Today_FailedCount=0;
                SuccessAmount = FailedAmount = 0.0F;
                Today_SuccessAmount = Today_FailedAmount = 0.0F;       
                
                //CP Success and Failed  Amount
                  CP_SuccessCount=CP_FailedCount=CP_Today_SuccessCount = CP_Today_FailedCount =0;
                  CP_SuccessAmount=CP_FailedAmount=CP_Today_SuccessAmount=CP_Today_FailedAmount=0.0F;
                
                
              
                ////Bank Succes , Failed ,In Progress Count 
                Bank_SuccessCount=Bank_FailedCount=Bank_InProgressCount=0;
                Bank_Today_SuccessCount=Bank_Today_FailedCount=Bank_Today_InProgressCount=0;
                ////Bank Succes , Failed ,In Progress Amount 
                   Bank_SuccessAmount=Bank_FailedAmount=Bank_InProgressAmount=0.0F; 
                   Bank_Today_SuccessAmount=Bank_Today_FailedAmount= Bank_Today_InProgressAmount=0.0F;

                   ////Electricity Success , Failed ,In Progress Count 
                   Electricity_SuccessCount = Electricity_FailedCount = Electricity_InProgressCount = 0;
                   Electricity_Today_SuccessCount = Electricity_Today_FailedCount = Electricity_Today_InProgressCount = 0;
                   ////Electricity Success , Failed ,In Progress Amount 
                   Electricity_SuccessAmount = Electricity_FailedAmount = Electricity_InProgressAmount = 0.0F;
                   Electricity_Today_SuccessAmount = Electricity_Today_FailedAmount = Electricity_Today_InProgressAmount = 0.0F;


                   ////Refund Request Refund,  Reject, InProgress Count
                   RR_RefundCount = RR_RejectCount = RR_InProgressCount=0;
                   RR_Today_RefundCount = RR_Today_RejectCount = RR_Today_InProgressCount=0;
                   ////Refund Request Refund,  Reject, InProgress AMount
                   RR_RefundAmount = RR_RejectAmount = RR_InProgressAmount = 0.0F;
                   RR_Today_RefundAmount = RR_Today_RejectAmount = RR_Today_InProgressAmount = 0.0F;

                    /// User Type Count and AvailBalance 
                   EnterpriseCount=PersonalCount=0;
                   EnterpriseAmount=PersonalAmount=0.0F;

                // fund Transfer Count and AvailBalance
                   E_E_Count = E_P_Count = Today_E_E_Count = Today_E_P_Count = 0;
                   E_E_Amount = E_P_Amount = Today_E_E_Amount = Today_E_P_Amount = 0.0F;


                // Fund Failed Count 
                 Fund_FailedCount=Fund_Today_FailedCount=0;
                 Fund_FailedAmount=Fund_Today_FailedAmount=0.0F;


                // CyberPlate ProfiCount By Admin, EnterPrise , Personal
                 TOTAL_CP_EntCount = TOTAL_Today_CP_EntCount = 0;
                 TOTAL_CP_EntProfit = TOTAL_Today_CP_EntProfit = 0.0F;
                 CP_AdminCount= CP_EntCount=CP_PerCount=0;
                 Today_CP_AdminCount=Today_CP_EntCount=Today_CP_PerCount=0;
               // CyberPlate Profit By Admin, EnterPrise , Personal
                CP_AdminProfit=CP_EntProfit=CP_PerProfit=0.0F;
                Today_CP_AdminProfit=Today_CP_EntProfit=Today_CP_PerProfit=0.0F;

               
                //Admin Profit By Fund , Money, Monthly Charge, MSEB
                Elect_CP_AdminCount = Fund_CP_AdminCount = MonthlyCharge_CP_AdminCount = Bank_CP_AdminCount=0;
                Elect_Today_CP_AdminCount = Fund_Today_CP_AdminCount = MonthlyCharge_Today_CP_AdminCount = Bank_Today_CP_AdminCount=0;

                Elect_CP_AdminProfit = Fund_CP_AdminProfit = MonthlyCharge_CP_AdminProfit = Bank_CP_AdminProfit=0.0F;
                Elect_Today_CP_AdminProfit = Fund_Today_CP_AdminProfit = MonthlyCharge_Today_CP_AdminProfit = Bank_Today_CP_AdminProfit=0.0F;

                // Profit By Electricity , Fund And Money Transfer
                Elect_ENT_ProfitCount = Elect_PER_ProfitCount = Bank_ENT_ProfitCount = Bank_PER_ProfitCount = FUND_ENT_ProfitCount = FUND_PER_ProfitCount = 0;
                Elect_Today_ENT_ProfitCount = Elect_Today_PER_ProfitCount = FUND_Today_ENT_ProfitCount = FUND_Today_PER_ProfitCount= Bank_Today_ENT_ProfitCount = Bank_Today_PER_ProfitCount = 0;
                Elect_ENT_ProfitAmount = Elect_PER_ProfitAmount = FUND_ENT_ProfitAmount = FUND_PER_ProfitAmount = Bank_ENT_ProfitAmount= Bank_PER_ProfitAmount = 0.0F;
                Elect_Today_ENT_ProfitAmount = Elect_Today_PER_ProfitAmount = FUND_Today_ENT_ProfitAmount = FUND_Today_PER_ProfitAmount = Bank_Today_ENT_ProfitAmount = Bank_Today_PER_ProfitAmount = 0.0F;


                //Fund Tnasfer ProfitAMount By Enterprise To Persoanl Transfer
                Fund_E_to_P_Profit = Fund_Today_E_to_P_Profit = 0.0F;

                 // Profit By Bank Count , Amount
                Bank_ProfitCount=Today_Bank_ProfitCount=0;
                Bank_ProfitAmount= Today_Bank_ProfitAmount=0.0F;
                Bank_SuccessProfitAmount=Bank_InProgressProfitAmount=0.0F;
                Bank_Today_InProgressProfitAmount = Bank_Today_SuccessProfitAmount = 0.0F;

                // Profit By Electricity Count , Amount
                Elec_ProfitCount=Today_Elec_ProfitCount=0;
                Elec_ProfitAmount = Today_Elec_ProfitAmount = 0.0F;


                //Crebit  Monthly Charge Count ANd Amount 
                Crebit_Monthly_Charge_SuccessCount = Today_Crebit_Monthly_Charge_SuccessCount = 0;
                Crebit_Monthly_Charge_SuccessAmount = Today_Crebit_Monthly_Charge_SuccessAmount = 0.0F;
                CrebitCharges_PerCount = Today_CrebitCharges_PerCount = 0;
                CrebitCharges_PerAmount = Today_CrebitCharges_PerAmount = 0.0F;
           
                        
                string ConnectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                SqlConnection thisConnection = new SqlConnection(ConnectionString);
                SqlCommand thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandType = CommandType.StoredProcedure;
                thisCommand.CommandText = "CB_ADMIN_DashBoardAdmin";
                DataBase db = new DataBase();
                DataSet ds = db.SelectAdaptQry(thisCommand);
                
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataRowCollection drc = ds.Tables[0].Rows;
                    foreach (DataRow item in drc)
                    {
                        string Amount = ""+item["Amount"].ToString();
                        String Date = Convert.ToDateTime(item["Date"]).ToString("d MMM yyyy h:mm tt ");
                        int Status = Convert.ToInt32(item["Status"]);
                        string UserType =""+item["UserType"].ToString();
                        string CreditUserType=""+item["CreditUserType"].ToString();
                        int ServiceId = Convert.ToInt32(item["ServiceId"]);
                        int RefundStatus = Convert.ToInt32(item["RefundStatus"]);
                        string ReqDate = "" + item["ReqDate"].ToString();
                      //  string CreditAccountNo = "" + item["CreditAccountNo"].ToString();
                        
                        DateTime fromdate = Convert.ToDateTime(Date);
                        DateTime ReqCurrentdate = Convert.ToDateTime(ReqDate);
                        string dateReq = ReqCurrentdate.GetDateTimeFormats('d')[0];
                        string date = fromdate.GetDateTimeFormats('d')[0];
                        DateTime now = DateTime.Now;
                        string nowdate = now.GetDateTimeFormats('d')[0];



                        switch (RefundStatus)
                            { 
                                case 3:
                                            RR_InProgressCount +=1;
                                            RR_InProgressAmount +=float.Parse(Amount);
                                            if (nowdate.Equals(dateReq))
                                            {
                                                RR_Today_InProgressCount += 1;
                                                RR_Today_InProgressAmount += float.Parse(Amount);
                                            }
                                            break;
                                case 4:
                                            RR_RejectCount += 1;
                                            RR_RejectAmount += float.Parse(Amount);
                                            if (nowdate.Equals(dateReq))
                                            {
                                                RR_Today_RejectCount += 1;
                                                RR_Today_RejectAmount += float.Parse(Amount);
                                            }

                                            break;

                                case 9:
                                            RR_RefundCount += 1;
                                            RR_RefundAmount += float.Parse(Amount);
                                            if (nowdate.Equals(dateReq))
                                            {
                                                RR_Today_RefundCount += 1;
                                                RR_Today_RefundAmount += float.Parse(Amount);
                                            }
                                            break;
                            }
  
             
          

                        
                        
                        switch (Status)
                                {
                                    case 0:
                                        ////Total 
                                        FailedCount += 1;
                                        FailedAmount += float.Parse(Amount);
                                      
                                        //// Today
                                        if(nowdate.Equals(date))
                                        {
                                            Today_FailedCount +=1;
                                            Today_FailedAmount += float.Parse(Amount);
                                        }

                                        switch (ServiceId)
                                        {
                                            case 38:
                                                Electricity_FailedCount += 1;
                                                Electricity_FailedAmount += float.Parse(Amount);
                                                if (nowdate.Equals(date))
                                                {
                                                    Electricity_Today_FailedCount += 1;
                                                    Electricity_Today_FailedAmount += float.Parse(Amount);
                                                }
                                                break;
                                                
                                              case 55:
                                               Fund_FailedCount += 1;
                                                Fund_FailedAmount += float.Parse(Amount);
                                                if (nowdate.Equals(date))
                                                {
                                                    Fund_Today_FailedCount += 1;
                                                    Fund_Today_FailedAmount += float.Parse(Amount);
                                                }
                                                break;

                                            
                                              case 57:
                                                Bank_FailedCount += 1;
                                                Bank_FailedAmount += float.Parse(Amount);
                                                //// Today
                                                if (nowdate.Equals(date))
                                                {
                                                    Bank_Today_FailedCount += 1;
                                                    Bank_Today_FailedAmount += float.Parse(Amount);
                                                }
                                                break;
                                        }
                                break;
                                 
                            case 1:
                                
                                        ////Total
                                        SuccessCount += 1;
                                        SuccessAmount += float.Parse(Amount);
                                    
                                        ////Today
                                        if(nowdate.Equals(date))
                                        {
                                        Today_SuccessCount +=1;
                                        Today_SuccessAmount += float.Parse(Amount);
                                        }


                                        switch (ServiceId)
                                        {
                                            case 38:
                                                Electricity_SuccessCount += 1;
                                                Electricity_SuccessAmount += float.Parse(Amount);
                                                if (nowdate.Equals(date))
                                                {
                                                    Electricity_Today_SuccessCount += 1;
                                                    Electricity_Today_SuccessAmount += float.Parse(Amount);
                                                }
                                                break;
                                            case 55:
                                                if (UserType == "1" && CreditUserType == "1")
                                                {
                                                    E_E_Count += 1;
                                                    E_E_Amount += float.Parse(Amount);

                                                    if (nowdate.Equals(date))
                                                    {
                                                        Today_E_E_Count += 1;
                                                        Today_E_E_Amount += float.Parse(Amount);
                                                    }
                                                }

                                                if (UserType == "1" && CreditUserType == "2")
                                                {
                                                    E_P_Count += 1;
                                                    E_P_Amount += float.Parse(Amount);
                                                    Fund_E_to_P_Profit += (float.Parse(Amount) / 200);
                                                    if (nowdate.Equals(date))
                                                    {
                                                        Today_E_P_Count += 1;
                                                        Today_E_P_Amount += float.Parse(Amount);
                                                        Fund_Today_E_to_P_Profit += (float.Parse(Amount) / 200);
                                                    }
                                                }

                                                break;

                                            case 56:

                                                Crebit_Monthly_Charge_SuccessCount += 1;
                                                Crebit_Monthly_Charge_SuccessAmount += float.Parse(Amount);
                                                if (nowdate.Equals(date))
                                                {
                                                    Today_Crebit_Monthly_Charge_SuccessCount += 1;
                                                    Today_Crebit_Monthly_Charge_SuccessAmount += float.Parse(Amount);
                                                }

                                                break;
                                            case 57:
                                                Bank_SuccessCount += 1;
                                                Bank_SuccessAmount += float.Parse(Amount);
                                                Bank_SuccessProfitAmount += (float.Parse(Amount) / 100);
                                                //// Today
                                                if (nowdate.Equals(date))
                                                {
                                                    Bank_Today_SuccessCount += 1;
                                                    Bank_Today_SuccessAmount += float.Parse(Amount);
                                                    Bank_Today_SuccessProfitAmount += (float.Parse(Amount) / 100);
                                                }
                                                break;
                                        }                                   
                                        break;

                            case 3:
                                        switch (ServiceId)
                                        {
                                            case 38:
                                                Electricity_InProgressCount += 1;
                                                Electricity_InProgressAmount += float.Parse(Amount);
                                                if (nowdate.Equals(date))
                                                {
                                                    Electricity_Today_InProgressCount += 1;
                                                    Electricity_Today_InProgressAmount += float.Parse(Amount);
                                                }
                                                break;
                                            //case 55: 
                                            //    InPro_FundAmount += float.Parse(Amount); 
                                            //    break;
                                            case 57:
                                                Bank_InProgressCount += 1;
                                                Bank_InProgressAmount += float.Parse(Amount);
                                                Bank_InProgressProfitAmount += (float.Parse(Amount)/100);
                                                //// Today
                                                if (nowdate.Equals(date))
                                                {
                                                    Bank_Today_InProgressCount += 1;
                                                    Bank_Today_InProgressAmount += float.Parse(Amount);
                                                    Bank_Today_InProgressProfitAmount += (float.Parse(Amount) / 100);
                                                }
                                                break;
                                        }

                                        break;
                             }
                            }



                 // UserCount And Total AVail Balance
                    DataRowCollection drcNew = ds.Tables[1].Rows;

                    foreach (DataRow item in drcNew)
                    {
                        string UserType = "" + item["UserType"].ToString();
                        string CurrBal = "" + item["CurrBal"].ToString();

                        if (UserType == "1")
                        {
                            EnterpriseCount += 1;
                            EnterpriseAmount += float.Parse(CurrBal);

                        }
                        else if (UserType == "2")
                        {
                            PersonalCount += 1;
                            PersonalAmount += float.Parse(CurrBal);

                        }
                    }


                    //User Charges 30 rupees first Time 
                    DataRowCollection drcUserCharges = ds.Tables[2].Rows;
                    foreach (DataRow item in drcUserCharges)
                   {
                       string CreditAccountNo = "" + item["CreditAccountNo"].ToString();
                       string Date = "" + item["Date"].ToString();
                       
                       DateTime fromdate = Convert.ToDateTime(Date);
                       string date = fromdate.GetDateTimeFormats('d')[0];
                       DateTime now = DateTime.Now;
                       string nowdate = now.GetDateTimeFormats('d')[0];

                       CrebitCharges_PerCount += 1;

                       if (nowdate.Equals(date))
                       {
                           Today_CrebitCharges_PerCount += 1;
                       }
                    }
                    
                    
                    
                    // Total Profit  COunt And Amount By Admin and  User 
                     DataRowCollection drcProfit = ds.Tables[3].Rows;
                     foreach (DataRow item in drcProfit)
                     {
                         string UserProfit = "" + item["UserProfit"].ToString();
                         string OperatorId = "" + item["OperatorId"].ToString();
                         string AdminProfit = "" + item["AdminProfit"].ToString();
                         string Date = "" + item["Date"].ToString();
                         string UserType = "" + item["UserType"].ToString();

                         DateTime fromdate = Convert.ToDateTime(Date);
                         string date = fromdate.GetDateTimeFormats('d')[0];
                         DateTime now = DateTime.Now;
                         string nowdate = now.GetDateTimeFormats('d')[0];
                      
                         // Admin Profit
                         CP_AdminCount +=1;
                         CP_AdminProfit +=float.Parse(AdminProfit);
                         if (nowdate.Equals(date))
                          {
                             Today_CP_AdminCount +=1;
                             Today_CP_AdminProfit +=float.Parse(AdminProfit);
                         }

                         // Total Profit By Ent And Personal 
                         if (UserType=="1")
                         {
                         TOTAL_CP_EntCount +=1;
                         TOTAL_CP_EntProfit += float.Parse(UserProfit);
                              if (nowdate.Equals(date))
                                {
                                    TOTAL_Today_CP_EntCount += 1;
                                    TOTAL_Today_CP_EntProfit += float.Parse(UserProfit);
                                }

                         }
                         else if(UserType=="2")
                         {
                         CP_PerCount +=1;
                         CP_PerProfit += float.Parse(UserProfit);
                              if (nowdate.Equals(date))
                                {
                             Today_CP_PerCount +=1;
                             Today_CP_PerProfit +=float.Parse(UserProfit);
                              }
                         }


                         // Profit By CyberPlate 
                          switch (OperatorId)
                             {
                              case "40"://MSEB

                                  Elect_CP_AdminCount +=1;
                                  Elect_CP_AdminProfit += float.Parse(AdminProfit);
                                if (nowdate.Equals(date))
                                  {
                                      Elect_Today_CP_AdminCount += 1;
                                      Elect_Today_CP_AdminProfit += float.Parse(AdminProfit);
        		                    }

                              if (UserType=="1")
                               {
                                  
                                  Elect_ENT_ProfitCount +=1; 
                                  Elect_ENT_ProfitAmount +=float.Parse(UserProfit);
                                   if (nowdate.Equals(date))
                                   {
                                  Elect_Today_ENT_ProfitCount +=1; 
                                  Elect_Today_ENT_ProfitAmount +=float.Parse(UserProfit);
                                  
                                   }
                              }


                              else if (UserType=="2")
                              {
                               Elect_PER_ProfitCount +=1; 
                               Elect_PER_ProfitAmount +=float.Parse(UserProfit);
                                  if (nowdate.Equals(date))
                                   {
                                  Elect_Today_PER_ProfitCount +=1; 
                                  Elect_Today_PER_ProfitAmount +=float.Parse(UserProfit);
                                  }
                              
                              }
                                  break;
                              case "1100": //FundTransfer
                                  Fund_CP_AdminCount +=1;
                                  Fund_CP_AdminProfit += float.Parse(AdminProfit);
                                if (nowdate.Equals(date))
                                  {
                                      Fund_Today_CP_AdminCount += 1;
                                      Fund_Today_CP_AdminProfit += float.Parse(AdminProfit);
        		                    }

                              
                                  if (UserType=="1")
                               {
                                  
                                  FUND_ENT_ProfitCount +=1; 
                                  FUND_ENT_ProfitAmount +=float.Parse(UserProfit);
                                   if (nowdate.Equals(date))
                                   {
                                  FUND_Today_ENT_ProfitCount +=1; 
                                  FUND_Today_ENT_ProfitAmount +=float.Parse(UserProfit);
                                  
                                   }
                              }


                              else if (UserType=="2")
                              {
                               FUND_PER_ProfitCount +=1; 
                               FUND_PER_ProfitAmount +=float.Parse(UserProfit);
                                  if (nowdate.Equals(date))
                                   {
                                  FUND_Today_PER_ProfitCount +=1; 
                                  FUND_Today_PER_ProfitAmount +=float.Parse(UserProfit);
                                  }
                              
                              }

                                  break;

                              case "1200":
                                  MonthlyCharge_CP_AdminCount +=1;
                                  MonthlyCharge_CP_AdminProfit += float.Parse(AdminProfit);
                                if (nowdate.Equals(date))
                                  {
                                      MonthlyCharge_Today_CP_AdminCount += 1;
                                      MonthlyCharge_Today_CP_AdminProfit += float.Parse(AdminProfit);
       		                      }


                                  break;


                              case "1300": // Money Transfer (BANK)
                              
                                  Bank_CP_AdminCount +=1;
                                  Bank_CP_AdminProfit += float.Parse(AdminProfit);
                                if (nowdate.Equals(date))
                                  {
                                      Bank_Today_CP_AdminCount += 1;
                                      Bank_Today_CP_AdminProfit += float.Parse(AdminProfit);
       		                      }

                             if (UserType=="1")
                               {
                                  
                                  Bank_ENT_ProfitCount +=1; 
                                  Bank_ENT_ProfitAmount +=float.Parse(UserProfit);
                                   if (nowdate.Equals(date))
                                   {
                                  Bank_Today_ENT_ProfitCount +=1; 
                                  Bank_Today_ENT_ProfitAmount +=float.Parse(UserProfit);
                              }
                              }

                              else if (UserType=="2")
                              {
                               Bank_PER_ProfitCount +=1; 
                               Bank_PER_ProfitAmount +=float.Parse(UserProfit);
                                  if (nowdate.Equals(date))
                                   {
                                  Bank_Today_PER_ProfitCount +=1; 
                                  Bank_Today_PER_ProfitAmount +=float.Parse(UserProfit);
                                  }
                              
                              }
                             break;
                          }
                     }
                       

                    // Admin Profit By  CyberPlate 
                     CP_AdminCount = CP_AdminCount - (Elect_CP_AdminCount + Fund_CP_AdminCount + MonthlyCharge_CP_AdminCount + Bank_CP_AdminCount);
                     Today_CP_AdminCount = Today_CP_AdminCount - (Elect_Today_CP_AdminCount + Fund_Today_CP_AdminCount + MonthlyCharge_Today_CP_AdminCount + Bank_Today_CP_AdminCount);
                     CP_AdminProfit = CP_AdminProfit - (Elect_CP_AdminProfit + Fund_CP_AdminProfit + MonthlyCharge_CP_AdminProfit + Bank_CP_AdminProfit);
                     Today_CP_AdminProfit = Today_CP_AdminProfit - (Elect_Today_CP_AdminProfit + Fund_Today_CP_AdminProfit + MonthlyCharge_Today_CP_AdminProfit + Bank_Today_CP_AdminProfit);

                 /// Profit Count and Amount By Enterprise And Personal
                 CP_EntCount =TOTAL_CP_EntCount-(Elect_ENT_ProfitCount+Bank_ENT_ProfitCount+FUND_ENT_ProfitCount);  
                 CP_PerCount = CP_PerCount -(Elect_PER_ProfitCount +Bank_PER_ProfitCount  +FUND_PER_ProfitCount);
                
                 Today_CP_EntCount =TOTAL_Today_CP_EntCount - (Elect_Today_ENT_ProfitCount+FUND_Today_ENT_ProfitCount +Bank_Today_ENT_ProfitCount);
                 Today_CP_PerCount  =Today_CP_PerCount -(Elect_Today_PER_ProfitCount +FUND_Today_PER_ProfitCount+Bank_Today_PER_ProfitCount);

                 CP_EntProfit = TOTAL_CP_EntProfit - (Elect_ENT_ProfitAmount + Bank_ENT_ProfitAmount + FUND_ENT_ProfitAmount);
                 CP_PerProfit = CP_PerProfit - (Elect_PER_ProfitAmount + Bank_PER_ProfitAmount + FUND_PER_ProfitAmount);

                Today_CP_EntProfit =TOTAL_Today_CP_EntProfit -( Elect_Today_ENT_ProfitAmount+FUND_Today_ENT_ProfitAmount+Bank_Today_ENT_ProfitAmount);
                Today_CP_PerProfit =Today_CP_PerProfit-(Elect_Today_PER_ProfitAmount+FUND_Today_PER_ProfitAmount+ Bank_Today_PER_ProfitAmount);           
                               





                    //First Time Charge Amount Total And today
                    CrebitCharges_PerAmount = (CrebitCharges_PerCount * 30);
                    Today_CrebitCharges_PerAmount = (Today_CrebitCharges_PerCount * 30);


                   
                // CP Failed And Sucess Count 
                    CP_SuccessCount = SuccessCount - (Electricity_SuccessCount + E_E_Count + E_P_Count + Bank_SuccessCount + Crebit_Monthly_Charge_SuccessCount );
                    CP_Today_SuccessCount = Today_SuccessCount - (Electricity_Today_SuccessCount + Today_E_E_Count + Today_E_P_Count + Bank_Today_SuccessCount + Today_Crebit_Monthly_Charge_SuccessCount );
                    CP_FailedCount=FailedCount-(Electricity_FailedCount+Fund_FailedCount+Bank_FailedCount);
                    CP_Today_FailedCount = Today_FailedCount - (Electricity_Today_FailedCount + Fund_Today_FailedCount + Bank_Today_FailedCount);

                   //Cp Failed and Success Amount
                    CP_SuccessAmount = SuccessAmount - (Electricity_SuccessAmount + E_E_Amount + E_P_Amount + Bank_SuccessAmount + Crebit_Monthly_Charge_SuccessAmount );
                    CP_Today_SuccessAmount = Today_SuccessAmount - (Electricity_Today_SuccessAmount + Today_E_E_Amount + Today_E_P_Amount + Bank_Today_SuccessAmount + Today_Crebit_Monthly_Charge_SuccessAmount);

                   CP_FailedAmount = FailedAmount - (Electricity_FailedAmount + Fund_FailedAmount + Bank_FailedAmount);
                   CP_Today_FailedAmount = Today_FailedAmount - (Electricity_Today_FailedAmount + Fund_Today_FailedAmount + Bank_Today_FailedAmount);
                    
                   // Profit By Bank Count , Amount
                     Bank_ProfitCount = Bank_SuccessCount + Bank_InProgressCount;
                     Today_Bank_ProfitCount =Bank_Today_SuccessCount+Bank_Today_InProgressCount;
                     Bank_ProfitAmount = Bank_SuccessProfitAmount + Bank_InProgressProfitAmount;
                     Today_Bank_ProfitAmount = Bank_Today_InProgressProfitAmount + Bank_Today_SuccessProfitAmount;
                       
                       

                   // Profit By Electricity Count , Amount
                   Elec_ProfitCount = Electricity_SuccessCount+Electricity_InProgressCount;
                   Today_Elec_ProfitCount = Electricity_Today_SuccessCount+Electricity_Today_InProgressCount;
                   Elec_ProfitAmount = (Elec_ProfitCount * 5);
                   Today_Elec_ProfitAmount = (Today_Elec_ProfitCount*5);

                }
                }
            catch (Exception ex)
            {
            }
        }
    }
}