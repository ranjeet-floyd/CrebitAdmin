<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoardAdmin.aspx.cs" Inherits="Crebit_Admin.DashBoardAdmin" %>

<!DOCTYPE html>
<html lang="en" style="overflow: auto">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="Crebit Request Management" />
    <meta name="author" content="Ranjeet" />
    <link rel="icon" href="../../favicon.ico" />
    <title>Crebit Admin Dashboard</title>
    <!-- Bootstrap core CSS -->
    <link href="bootstrap.min.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="dashboard.css" rel="stylesheet" />
    <style type="text/css">
        #StatusList {
            display: none;
        }
    </style>
    <link href="../css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.custom.js" type="text/javascript"></script>
    <script src="Scripts/cookies.js" type="text/javascript"></script>
   

</head>

<body>
    <form id="Form1" runat="server">
        <div class="navbar navbar-inverse navbar-fixed-top" role="navigation">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed float-left" data-toggle="collapse" data-target=".left_menu">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <button type="button" class="navbar-toggle collapsed float-right" data-toggle="collapse" data-target=".subData">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand " href="#">Crebit &gt; <span id="link_page">Bank Transfer</span></a>
                </div>
                <div class="navbar-collapse collapse left_menu">
                    <ul id="ul_navbar" class="nav navbar-nav navbar-right">
                       <li><a id="adminDashboard"class="active" href="DashBoardAdmin.aspx?u=<%=QueryString%>">DashBoardAdmin</a></li>
                         <li><a id="a_electricity" href="Electricity_page.aspx?u=<%=QueryString%>">Electricity</a></li>
                        <li><a id="a_bank"  href="Bank Transfer.aspx?u=<%=QueryString%>">Bank Transfer</a></li>
                        <li><a id="a_refund" href="RefundRequest.aspx?u=<%=QueryString%>">RefundRequest </a></li>
                        <li><a id="a1" href="Transaction_Page.aspx?u=<%=QueryString%>">Transaction</a></li>
                        <li><a id="a_Dashboard" href="DashBoard.aspx?u=<%=QueryString%>">DashBoard</a></li>
                       <li><a id="a_CpProfitSummary" href="CPprofitSummary.aspx?u=<%=QueryString%>">CPprofitSummary</a></li>
                        <li><a href="#">Profile</a></li>
                        <li><a href="Login.aspx">Logout</a></li>
                    </ul>

                </div>
            </div>
        </div>

        <br/><br/>
   
         <%--Table Row  one Start--%>
         <div class="table-responsive" >
            <div class="row placeholders">

                      
                 <%--CyberPlate Table start--%>
               <a id="transHref" href="Transaction_Page.aspx?u=<%=QueryString%>">
                       <div class="col-xs-6 col-sm-3 placeholder">
                   <table class="table table-striped" style="border: 1px solid black; width: 15%; margin-left: 25%; margin-right: 10%">
                    
                    <thead>
                        <tr class="TableColor">
                            <th>#CP </th>
                            <th>Count </th>
                            <th> Amount</th>
                            </tr>
                    </thead>
                    <tr>
                        <td style="background-color: #000; color: #fff;">TotalSuccess</td>
                        <td style="color: #000;"><%=CP_SuccessCount%></td>
                        <td style="color: #000;">Rs.<%=CP_SuccessAmount%></td>
                        </tr>
                    <tr>
                        <td class="TableColor">TotalFailed</td>
                        <td style="color: #000;"><%=CP_FailedCount%></td>
                        <td style="color: #000;">Rs.<%=CP_FailedAmount%></td>
                        </tr>
                    <tr>
                        <td style="background-color: #000; color: #fff;">TodaySuccess</td>
                          <td style="color: #000;"><%=CP_Today_SuccessCount%></td>
                          <td style="color: #000;">Rs.<%=CP_Today_SuccessAmount%></td>
                      
                        </tr>
                    <tr>
                        <td class="TableColor">TodayFailed</td>
                        <td style="color: #000;"><%=CP_Today_FailedCount%></td>
                        <td style="color: #000;">Rs.<%=CP_Today_FailedAmount%></td>
                      
                        </tr>
                                                         
                </table>
                    </div>
               </a>
                <%--CyberPlate Table End --%>
                    <%--////////////////   Crebit Fund Transfer Table Start ////////////////--%>
                 <a id="A5" href="Transaction_Page.aspx?u=<%=QueryString%>">
                <div class="col-xs-6 col-sm-3 placeholder">
                    <table class="table table-striped" style="border: 1px solid black; width: 15%; margin-left: 15%; margin-right: 10%">
                    <thead>
                        <tr class="TableColor">
                            <th>#CrebitFund </th>
                            <th>Count   </th>
                            <th> Amount</th>
                            </tr>
                    </thead>
                  
                        <%--Total Count And Amount--%>
                     <tr>
                        <td style="background-color: #000; color: #fff;">Total E-E </td>
                        <td style="color: #000;"><%=E_E_Count%></td>
                        <td style="color: #000;">Rs.<%=E_E_Amount%></td>
                        </tr>
                    <tr>
                        <td class="TableColor">Total E-P</td>
                        <td style="color: #000;"><%=E_P_Count%></td>
                        <td style="color: #000;">Rs.<%=E_P_Amount%></td>
                        </tr>
                    
                        
                    <%--Today Count And Amount--%>
                    <tr>
                            <td style="background-color: #000; color: #fff;">Today E-E</td>
                          <td style="color: #000;"><%=Today_E_E_Count%></td>
                        <td style="color: #000;">Rs.<%=Today_E_E_Amount%></td>
                        
                        </tr>
                    <tr>
                        <td class="TableColor">Today E-P</td>
                        <td style="color: #000;"><%=Today_E_P_Count%></td>
                        <td style="color: #000;">Rs.<%=Today_E_P_Amount%></td>
                      
                        </tr>
                    
                </table>
            </div>
                     </a>
                <%--Crebit Fund Transfer Table END--%>
                    <%--USER Table Start--%>
        <a id="a6" href="DashBoard.aspx?u=<%=QueryString%>">
                <div class="col-xs-6 col-sm-3 placeholder">
                    <table class="table table-striped" style="border: 1px solid black; width: 15%; margin-left: 15%; margin-right: 10%">
                    <thead>
                        <tr class="TableColor">
                            <th>#User</th>
                            <th>Count   </th>
                            <th> AvailBalance</th>
                            </tr>
                    </thead>
                    <tr>
                        <td style="background-color: #000; color: #fff;">TotalEnterprise</td>
                        <td style="color: #000;"><%=EnterpriseCount%></td>
                        <td style="color: #000;">Rs.<%=EnterpriseAmount%></td>
                        </tr>
                        
                         <tr>
                        <td class="TableColor">ToatalPersonal</td>
                        <td style="color: #000;"><%=PersonalCount%></td>
                        <td style="color: #000;">Rs.<%=PersonalAmount%></td>
                        </tr>
                     
                </table>
            </div>
       </a>
                <%--USER Table END--%>


                 <%--FundTrasnfer Profit Table Start--%>
      <a id="a3" href="RefundRequest.aspx?u=<%=QueryString%>">
               
                 <div class="col-xs-6 col-sm-3 placeholder">
                    <table class="table table-striped" style="border: 1px solid black; width: 15%; margin-left: 15%; margin-right: 10%">
                    <thead>
                        <tr class="TableColor">
                            <th>#FundProfit </th>
                            <th>Count</th>
                            <th>Profit</th>
                            </tr>
                    </thead>
                        
                        <%--Total Count And Profit--%>
                     <tr>
                        <td style="background-color: #000; color: #fff;">Total E-P</td>
                        <td style="color: #000;"><%=E_P_Count%></td>
                        <td style="color: #000;">Rs.<%=Fund_E_to_P_Profit%></td>
                        </tr>
                   
                         <%--Today Count And profit--%>
                       <tr>
                        <td class="TableColor">Today E-P</td>
                        <td style="color: #000;"><%=Today_E_P_Count%></td>
                        <td style="color: #000;">Rs.<%=Fund_Today_E_to_P_Profit%></td>
                        </tr>
                    
                </table>
            </div>
        </a>
            <%--FundTrasnfer Profit Table END--%>


               



                </div>
    </div>
        
        <%--Table  Row one  End--%>
        
        
        
         <%-- Table Row Two Start--%>

          <div class="table-responsive">
            <div class="row placeholders">

                
        <%--Bank Table Start--%>
                <a id="a7"  href="Bank Transfer.aspx?u=<%=QueryString%>">
                <div class="col-xs-6 col-sm-3 placeholder">
                    <table class="table table-striped" style="border: 1px solid black; width: 15%; margin-left: 20%; margin-right: 10%">
                    <thead>
                        <tr class="TableColor">
                            <th>#Bank </th>
                            <th>Count   </th>
                            <th> Amount</th>
                            </tr>
                    </thead>
                    <tr>
                        <td style="background-color: #000; color: #fff;">TotalSuccess</td>
                        <td style="color: #000;"><%=Bank_SuccessCount%></td>
                        <td style="color: #000;">Rs.<%=Bank_SuccessAmount%></td>
                        </tr>
                    <tr>
                        <td class="TableColor">ToatalFailed</td>
                        <td style="color: #000;"><%=Bank_FailedCount%></td>
                        <td style="color: #000;">Rs.<%=Bank_FailedAmount%></td>
                        </tr>
                    <tr>
                        <tr>
                        <td class="TableColor">ToatalInProgress</td>
                        <td style="color: #000;"><%=Bank_InProgressCount%></td>
                        <td style="color: #000;">Rs.<%=Bank_InProgressAmount%></td>
                        </tr>
                    <tr>


                        <td style="background-color: #000; color: #fff;">TodaySuccess</td>
                          <td style="color: #000;"><%=Bank_Today_SuccessCount%></td>
                          <td style="color: #000;">Rs.<%=Bank_Today_SuccessAmount%></td>
                      
                        </tr>
                    <tr>
                        <td class="TableColor">TodayFailed</td>
                        <td style="color: #000;"><%=Bank_Today_FailedCount%></td>
                        <td style="color: #000;">Rs.<%=Bank_Today_FailedAmount%></td>
                      
                        </tr>

                    <tr>
                        <td style="background-color: #000; color: #fff;">TodayInProgress</td>
                        <td style="color: #000;"><%=Bank_Today_InProgressCount%></td>
                        <td style="color: #000;">Rs.<%=Bank_Today_InProgressAmount%></td>
                    </tr>
                </table>
            </div>
                    </a>
                <%--Bank Table END--%>

                  <%--Electricity Table Start--%>
                <a id="a8" href="Electricity_page.aspx?u=<%=QueryString%>">
                <div class="col-xs-6 col-sm-3 placeholder">
                    <table class="table table-striped" style="border: 1px solid black; width: 15%; margin-left: 15%; margin-right: 10%">
                    <thead>
                        <tr class="TableColor">
                            <th>#Electricity </th>
                            <th>Count   </th>
                            <th> Amount</th>
                            </tr>
                    </thead>
                    <tr>
                        <td style="background-color: #000; color: #fff;">TotalSuccess</td>
                        <td style="color: #000;"><%=Electricity_SuccessCount%></td>
                        <td style="color: #000;">Rs.<%=Electricity_SuccessAmount%></td>
                        </tr>
                    <tr>
                        <td class="TableColor">ToatalFailed</td>
                        <td style="color: #000;"><%=Electricity_FailedCount%></td>
                        <td style="color: #000;">Rs.<%=Electricity_FailedAmount%></td>
                        </tr>
                    <tr>
                        <tr>
                        <td class="TableColor">ToatalInProgress</td>
                        <td style="color: #000;"><%=Electricity_InProgressCount%></td>
                        <td style="color: #000;">Rs.<%=Electricity_InProgressAmount%></td>
                        </tr>
                    <tr>


                        <td style="background-color: #000; color: #fff;">TodaySuccess</td>
                          <td style="color: #000;"><%=Electricity_Today_SuccessCount%></td>
                          <td style="color: #000;">Rs.<%=Electricity_Today_SuccessAmount%></td>
                      
                        </tr>
                    <tr>
                        <td class="TableColor">TodayFailed</td>
                        <td style="color: #000;"><%=Electricity_Today_FailedCount%></td>
                        <td style="color: #000;">Rs.<%=Electricity_Today_FailedAmount%></td>
                      
                        </tr>

                    <tr>
                        <td style="background-color: #000; color: #fff;">TodayInProgress</td>
                        <td style="color: #000;"><%=Electricity_Today_InProgressCount%></td>
                        <td style="color: #000;">Rs.<%=Electricity_Today_InProgressAmount%></td>
                    </tr>
                </table>
            </div>
                    </a>
                <%--Electicity Table END--%>

              

                <%--Refund Request Table Start--%>
      <a id="a9" href="RefundRequest.aspx?u=<%=QueryString%>">
               
                 <div class="col-xs-6 col-sm-3 placeholder">
                    <table class="table table-striped" style="border: 1px solid black; width: 15%; margin-left: 15%; margin-right: 10%">
                    <thead>
                        <tr class="TableColor">
                            <th>#RefundRequest </th>
                            <th>Count   </th>
                            <th> Amount</th>
                            </tr>
                    </thead>
                  
                        <%--Total Count And Amount--%>
                     <tr>
                        <td style="background-color: #000; color: #fff;">TotalRefund</td>
                        <td style="color: #000;"><%=RR_RefundCount%></td>
                        <td style="color: #000;">Rs.<%=RR_RefundAmount%></td>
                        </tr>
                    <tr>
                        <td class="TableColor">ToatalReject</td>
                        <td style="color: #000;"><%=RR_RejectCount%></td>
                        <td style="color: #000;">Rs.<%=RR_RejectAmount%></td>
                        </tr>
                    <tr>
                        <tr>
                        <td class="TableColor">ToatalInProgress</td>
                        <td style="color: #000;"><%=RR_InProgressCount%></td>
                        <td style="color: #000;">Rs.<%=RR_InProgressAmount%></td>
                        </tr>
                    <tr>

                    <%--Today Count And Amount--%>
                        <td style="background-color: #000; color: #fff;">TodayRefund</td>
                          <td style="color: #000;"><%=RR_Today_RefundCount%></td>
                        <td style="color: #000;">Rs.<%=RR_Today_RefundAmount%></td>
                        
                        </tr>
                    <tr>
                        <td class="TableColor">TodayReject</td>
                        <td style="color: #000;"><%=RR_Today_RejectCount%></td>
                        <td style="color: #000;">Rs.<%=RR_Today_RejectAmount%></td>
                      
                        </tr>

                    <tr>
                        <td style="background-color: #000; color: #fff;">TodayInProgress</td>
                        <td style="color: #000;"><%=RR_Today_InProgressCount%></td>
                        <td style="color: #000;">Rs.<%=RR_Today_InProgressAmount%></td>
                    </tr>
                </table>
            </div>
        </a>
                <%--Refund Request Table END--%>


                    <%--  CyberPlate Profit By Admin,EnterPrise, Personal  Table start--%>
               <a id="A2" href="Transaction_Page.aspx?u=<%=QueryString%>">
                       <div class="col-xs-6 col-sm-3 placeholder">
                   <table class="table table-striped" style="border: 1px solid black; width: 15%; margin-left: 15%; margin-right: 10%">
                    
                    <thead>
                        <tr class="TableColor">
                            <th>#CpProfit </th>
                            <th>Count </th>
                            <th>Profit</th>
                            </tr>
                    </thead>
                    <tr>
                        <td style="background-color: #000; color: #fff;">TotalAdminProfit</td>
                        <td style="color: #000;"><%=CP_AdminCount%></td>
                        <td style="color: #000;">Rs.<%=CP_AdminProfit%></td>
                       </tr> 
                       <tr>
                        <td class="TableColor">TotalEntProfit</td>
                        <td style="color: #000;"><%=CP_EntCount%></td>
                        <td style="color: #000;">Rs.<%=CP_EntProfit%></td>
                        </tr>

                       <tr>
                        <td style="background-color: #000; color: #fff;">TotalPersonalProfit</td>
                        <td style="color: #000;"><%=CP_PerCount%></td>
                        <td style="color: #000;">Rs.<%=CP_PerProfit%></td>
                        </tr>

                       <tr>
                        
                        <td style="background-color: #000; color: #fff;">TodayAdminProfit</td>
                        <td style="color: #000;"><%=Today_CP_AdminCount%></td>
                        <td style="color: #000;">Rs.<%=Today_CP_AdminProfit%></td>
                       </tr> 
                        <tr>
                        <td style="background-color: #000; color: #fff;">TodayEntProfit</td>
                        <td style="color: #000;"><%=Today_CP_EntCount%></td>
                        <td style="color: #000;">Rs.<%=Today_CP_EntProfit%></td>
                        </tr>

                       <tr>
                        <td class="TableColor">TodayPersonalProfit</td>
                        <td style="color: #000;"><%=Today_CP_PerCount%></td>
                        <td style="color: #000;">Rs.<%=Today_CP_PerProfit%></td>
                        </tr>
                      
                                                         
                </table>
                    </div>
               </a>
               <%--  CyberPlate Profit By Admin,EnterPrise, Personal  Table END--%>
              


    </div>
    </div>
    
        <%--  Table  Row Two END--%>



          <%--Table Row  Three Start--%>
         <div class="table-responsive" >
         <div class="row placeholders">
  

                      <%--Crebit  Charges Count Table Start--%>
      <a id="a11" href="RefundRequest.aspx?u=<%=QueryString%>">
               
                 <div class="col-xs-6 col-sm-3 placeholder">
                    <table class="table table-striped" style="border: 1px solid black; width: 15%; margin-left: 20%; margin-right: 10%">
                    <thead>
                        <tr class="TableColor">
                            <th>#CrebitCharges</th>
                            <th>Count</th>
                            <th>Amount</th>
                            </tr>
                    </thead>

                        <%--Total Count And Amount--%>
                     <tr>
                        <td style="background-color: #000; color: #fff;">TotalEntCharges</td>
                        <td style="color: #000;"><%=Crebit_Monthly_Charge_SuccessCount%></td>
                        <td style="color: #000;">Rs.<%=Crebit_Monthly_Charge_SuccessAmount%></td>
                        </tr>
                        <tr>
                        <td style="background-color: #000; color: #fff;">TotalPersonalCharges</td>
                        <td style="color: #000;"><%=CrebitCharges_PerCount%></td>
                        <td style="color: #000;">Rs.<%=CrebitCharges_PerAmount%></td>
                        </tr>
                    
                    <%--Today Count And Amount--%>
                        <tr>
                        <td style="background-color: #000; color: #fff;">TodayEntCharges</td>
                        <td style="color: #000;"><%=Today_Crebit_Monthly_Charge_SuccessCount%></td>
                        <td style="color: #000;">Rs.<%=Today_Crebit_Monthly_Charge_SuccessAmount%></td>
                        </tr>
                        <tr>
                        <td style="background-color: #000; color: #fff;">TodayPersonalCharges</td>
                        <td style="color: #000;"><%=Today_CrebitCharges_PerCount%></td>
                        <td style="color: #000;">Rs.<%=Today_CrebitCharges_PerAmount%></td>
                        </tr>
                   
            </table>
            </div>
        </a>
                <%--Crebit Charges Count Table END--%>
        




             <%--Electricity Profit Count Table Start--%>
      <a id="a4" href="RefundRequest.aspx?u=<%=QueryString%>">
               
                 <div class="col-xs-6 col-sm-3 placeholder">
                    <table class="table table-striped" style="border: 1px solid black; width: 15%; margin-left: 15%; margin-right: 10%">
                    <thead>
                        <tr class="TableColor">
                            <th>#ElectricityProfit</th>
                            <th>Count</th>
                            <th>Profit</th>
                            </tr>
                    </thead>
                  
                        
                        <%--Total Count And Amount--%>
                     <tr>
                        <td style="background-color: #000; color: #fff;">Total</td>
                        <td style="color: #000;"><%=Elec_ProfitCount%></td>
                        <td style="color: #000;">Rs.<%=Elec_ProfitAmount%></td>
                        </tr>
                    <%--Today Count And Amount--%>
                        <tr>
                        <td class="TableColor">Today</td>
                        <td style="color: #000;"><%=Today_Elec_ProfitCount%></td>
                        <td style="color: #000;">Rs.<%=Today_Elec_ProfitAmount%></td>
                        </tr>
                   
            </table>
            </div>
        </a>
                <%--Electricity Profit Count Table END--%>


      
                    <%--Bank Profit Count Table Start--%>
      <a id="a10" href="RefundRequest.aspx?u=<%=QueryString%>">
               
                 <div class="col-xs-6 col-sm-3 placeholder">
                    <table class="table table-striped" style="border: 1px solid black; width: 15%; margin-left: 15%; margin-right: 10%">
                    <thead>
                        <tr class="TableColor">
                            <th>#BankProfit</th>
                            <th>Count</th>
                            <th>Profit</th>
                            </tr>
                    </thead>
                        <%--Total Count And Amount--%>
                     <tr>
                        <td style="background-color: #000; color: #fff;">Total</td>
                        <td style="color: #000;"><%=Bank_ProfitCount%></td>
                        <td style="color: #000;">Rs.<%=Bank_ProfitAmount%></td>
                        </tr>
                    <%--Today Count And Amount--%>
                        <tr>
                        <td class="TableColor">Today</td>
                        <td style="color: #000;"><%=Today_Bank_ProfitCount%></td>
                        <td style="color: #000;">Rs.<%=Today_Bank_ProfitAmount%></td>
                        </tr>
                   
            </table>
            </div>
        </a>
                <%--Bank Profit Count Table END--%>
        

            
                </div>
                </div>
                <%--Table Row  Three END--%>

       
        

        <!-- Bootstrap core JavaScript
	================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->

        <%-- <script src="jquery.min.js"></script>--%>
        <script src="bootstrap.min.js"></script>
        <script src="docs.min.js"></script>
        <%--  <script src="dashboard.html.0.js"></script>--%>

        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug 

   <!-- <script src="ie10-viewport-bug-workaround.js"></script> -->

    </form>
</body>
</html>
