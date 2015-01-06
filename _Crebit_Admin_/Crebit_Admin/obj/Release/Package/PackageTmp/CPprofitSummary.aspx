<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CPprofitSummary.aspx.cs" Inherits="CrebitAdminPanelNew.CPprofitSummary" Async="true" %>

<!DOCTYPE html>
<html lang="en" style="overflow: auto">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="Crebit Request Management" />
    <meta name="author" content="Ranjeet" />
    <link rel="icon" href="../../favicon.ico" />
    <title>Crebit CPprofitSummary</title>
    <!-- Bootstrap core CSS -->
    <link href="bootstrap.min.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="dashboard.css" rel="stylesheet" />
    <style type="text/css">
        #StatusList {
            display: none;
        }
    </style>
    
    <link href="css/jquery-ui.css" rel="stylesheet" />
      <script src="js/jquery.js"></script>
    <script src="js/jquery-ui.custom.js"></script>
    <script src="js/modernizr.js"></script>
    <script src="js/cookies.js"></script>
   
     <script type="text/javascript">
         $(document).ready(function () {
             $("#fromDate").datepicker();
             $("#toDate").datepicker();
             $("#utdate").datepicker();
             $("#fromDate").val('');
            $("#utdate").datepicker();
        });

         //GSM Message Send Confiramtion 
         function confirmation() {
             if (confirm('Are You Sure You Want To Send This Message => '+$("#message").val())) {

                 return true;
             } else {
                 return false;
             }
         }

        </script>
        <%--Ajax Call to Get the Profit--%>
    
     <script type="text/javascript">
         function ProfitCount() {

             var dataJSON = {};
             dataJSON.UserType = $("#userTypeList").val(); dataJSON.Date = $("#utdate").val(); dataJSON.UserName = $("#UserName").val();
             AjaxCall("POST", "/api/UserProfit", dataJSON, Onsuccess);//call api
             return false;
         }
         function UserSuccessTran()
         {
             var dataJSON = {};
             dataJSON.Date = $("#utdate").val(); dataJSON.UserName = $("#UserName").val();
             AjaxCall("POST", "/api/UserSuccessTran", dataJSON, OnSuccessTran);//call api
             return false;
         }
        
         function UserTakenBal() {
             var dataJSON = {};
             dataJSON.UserType = $("#userTypeList").val(); dataJSON.Date = $("#utdate").val(); dataJSON.UserName = $("#UserName").val();
             AjaxCall("POST", "/api/UserTakenBal", dataJSON, OnUserTakenBal);//call api
             return false;

         }
         function UserOpenCloseBal()
         {
             var dataJSON = {};
             dataJSON.UserType = $("#userTypeList").val(); dataJSON.Date = $("#utdate").val(); dataJSON.UserName = $("#UserName").val();
             AjaxCall("POST", "/api/OpeningClosingBal", dataJSON, OnUserOpenCloseBal);//call api
             return false;

         }


         //Ajax call for api
         function AjaxCall(type, url, dataJSON, callback) {
             $.ajax({
                 type: type,//"POST",
                 url: url,//"/dashboard/balanceUse", //
                 async: true,
                 data: JSON.stringify(dataJSON),
                 contentType: 'application/json; charset=utf-8',
                 dataType: 'json',
                 success: function (response, httpObj) {
                     if (httpObj == 'success') {

                         var html = "";
                         // var jsonString = eval('(' + response + ')');
                         if (callback && typeof (callback) === "function") {
                             callback(response);
                         }
                     }
                     else
                         alert("Error !! Check input data.");
                     //$("#loding_Model").hide();//hide loading image
                 },
                 error: function (httpObj, textStatus) {
                     //  $("#loding_Model").hide();
                     alert("Not Valid Entry !!");
                     console.log("error");
                     console.log("ResponseText" + httpObj.responseText);
                     if (httpObj.status == 401) {
                         window.location.replace("/Login.aspx");//dashboad page
                     }

                     // alert("Some Error Occured !. Please try again later.");
                 }
             });
         }

         
         function OnUserOpenCloseBal(resObj)
         {
             try{
             var html = "";
             html = "<div class='table-responsive'><table class='table table-striped' style='border: 1px solid black; width: 40%;'>"
             html += "<thead> <tr class='TableColor'><th>#</th><th>OpeningBalance</th><th>ClosingBalance</th></thead>"
             html += "<tr> <td style='background-color: #000;color:#fff; '></td>";
             if (resObj != null & resObj != "") {
                 html += "<td>" + resObj['OpeningBal'] + "</td>"
                 html += "<td>" + resObj['ClosingBal'] + "</td>"
             }
             html +="</tr></table></div>";
         } catch (ex) { }

         $("#model_msg_body").html(html);
         $('#model_msg').modal('show');

         }

         function OnUserTakenBal(resObj) {
             try {
                 var html = "";
                 html = "<div class='table-responsive'><table class='table table-striped' style='border: 1px solid black; width: 40%;'>"
                 html += "<thead> <tr class='TableColor'><th>#</th><th>TakenBalance</th></thead>"
                 html += "<tr>  <td style='background-color: #000;color:#fff; '></td>";
                 if (resObj != null & resObj != "") {
                     html += "<td>" + resObj['userTakenBal'] + "</td>"
                 }
                 html +="</tr></table></div>";
             } catch (ex) { }

             $("#model_msg_body").html(html);
             $('#model_msg').modal('show');

         }






         function OnSuccessTran(resObj) {
             try {
                 var html = "";
                 var count = 1;
                 var statusText="";
                 html = "<div class='table-responsive'><table class='table table-striped'><thead>"
                 html +="<th>#</th><th>UserId</th><th>ApiTransactionId</th><th>OperaterName/ServiceType</th><th>Amount</th><th></th><th>ApiId</th><th>CreditAccountNo</th><th>Session</th><th>Date</th>"
                 html +="</tr></thead>"
                 if (resObj.dL_TransactionReturns != null & resObj.dL_TransactionReturns != "") {
                     for (var i in resObj.dL_TransactionReturns) {
                         html += "<tr><td>" + count + "</td><td>" + resObj.dL_TransactionReturns[i].UserName + "</td><td>" + resObj.dL_TransactionReturns[i].ApiTransactionId + "</td><td>" + resObj.dL_TransactionReturns[i].OperaterName + "/" + resObj.dL_TransactionReturns[i].ServiceType + "</td><td>" + resObj.dL_TransactionReturns[i].Amount + "</td><td>" +
                                                        "</td><td>" + resObj.dL_TransactionReturns[i].APiId + "</td><td>" + resObj.dL_TransactionReturns[i].CreditAccountNo + "</td><td>"
                         + resObj.dL_TransactionReturns[i].CyberSessionId + "</td><td>" + resObj.dL_TransactionReturns[i].Date + "</td></tr>"
                         count++;
                     }


                 }
                 else { html += "<tr><td> NO DATA </td></tr>";}
                 html += "</table></div>";

             } catch (ex) { }
             $("#table_data").html(html);

         }
        function Onsuccess(resObj) {
            try {
                var html = "";
                if (resObj != null & resObj != "") {

                         if ($("#userTypeList").val() == 0)
                         {
                             html = "<div class='table-responsive'><table class='table table-striped' style='border: 1px solid black; width: 40%;'>"
                             html += "<thead> <tr class='TableColor'><th>AdminProfit</th><th>CyberPlate</th></thead>"
                             html += "<tr>  <td style='background-color: #000;color:#fff; '> Profit =></td><td>" + resObj['CyberPlateAdminProfit'] + "</td></tr></table></div>"
                             
                         }
                         else if ($("#userTypeList").val() == 1)
                         {
                             html = "<div class='table-responsive'><table class='table table-striped' style='border: 1px solid black; width: 40%;'>"
                             html += "<thead> <tr class='TableColor'><th>EnterPrise</th><th>CyberPlateProfit</th></thead>"
                             html += "<tr>  <td style='background-color: #000;color:#fff;'> Profit </td><td>" + resObj['CyberPlateProfit'] + "</td></tr></table></div>"
                             }
                         else if ($("#userTypeList").val() == 2) {
                             html = "<div class='table-responsive'><table class='table table-striped' style='border: 1px solid black; width: 40%; '>"
                             html += "<thead> <tr class='TableColor'><th>Personal</th><th>CyberPlateProfit</th></thead>"
                             html += "<tr>  <td style='background-color: #000;color:#fff;'>Profit</td><td>" + resObj['CyberPlateProfit'] + "</td></tr></table></div>"

                         }

                         else
                         {
                             html = "<div class='table-responsive'><table class='table table-striped' style='border: 1px solid black; width: 40%;'>"
                             html += "<thead> <tr class='TableColor'><th>#</th><th>CyberPlate</th><th>MSEB</th><th>FundTransfer</th><th>MoneyTransfer</th></thead>"
                             html += "<tr>  <td style='background-color: #000;color:#fff; '>Profit=></td><td>" + resObj['CyberPlateProfit'] + "</td>"
                             html += "<td>" + resObj['MSEB_ElecAdminProfit'] + "</td>"
                             html += "<td>" + resObj['FundAdminProfit'] + "</td>"
                             html += "<td>" + resObj['MoneyTransferAdminProfit'] + "</td></tr></table></div>"
                         }
                         
                }


            } catch (ex) { }
            
            $("#model_msg_body").html(html);
            $('#model_msg').modal('show');

        }
        </script>
</head>
<body>
     <%--Navigation  Bar --%>
     <form id="dashBoardForm"  runat="server">
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
                    <a class="navbar-brand " href="#">Crebit &gt; <span id="link_page">CpProfitSummary</span></a>
                </div>
                <div class="navbar-collapse collapse left_menu">
                    <ul id="ul_navbar" class="nav navbar-nav navbar-right">
                        <li><a id="adminDashboard" href="DashBoardAdmin.aspx?u=<%=QueryString%>">DashBoardAdmin</a></li>
                        <li><a id="a_electricity"  href="Electricity_page.aspx?u=<%=QueryString%>">Electricity</a></li>
                        <li><a id="a_bank" href="Bank Transfer.aspx?u=<%=QueryString%>">Bank Transfer</a></li>
                        <li><a id="a_refund" href="RefundRequest.aspx?u=<%=QueryString%>">RefundRequest </a></li>
                        <li><a id="a_transction" href="Transaction_Page.aspx?u=<%=QueryString%>">Transaction</a></li>
                        <li><a id="a_Dashboard" href="DashBoard.aspx?u=<%=QueryString%>">DashBoard</a></li>
                       <li><a id="a_CpProfitSummary" class="active" href="CPprofitSummary.aspx?u=<%=QueryString%>">CPprofitSummary</a></li>
                        <li><a href="#">Profile</a></li>
                        <li><a href="Login.aspx">Logout</a></li>
                    </ul>
                </div>
            </div>
        </div>
         <br/>
    
         <%--GSM Send Notification--%>
           <div class="dashboard-middle">
            <div class="navbar-collapse collapse subData">

                <ul class="nav navbar-nav navbar-right margin5 " style="border-style: solid; border-width: 1px; border-color: #ededf1; padding: 10px; padding-left: 20px; padding-right: 20px">
                    
                    <li>
                        <input id="message" type="text" runat="server" maxlength="160" class=" form-control" style="width: 100px" placeholder="Message" />
                    </li>
                    <li>
                        <asp:Button Text="GsmSendNotification" OnClientClick="return confirmation();" class="form-control btn-primary" runat="server" ID="GsmSendNotification"
                            OnClick="SendNotificationAsync" />
                    </li>
                </ul>
            </div>
        </div>
       </form>
      
    <br/>
         <%-- User Profit Count Control--%>
       <div class="input-group" style="width: 60%; padding-left: 10%; padding-right: 5%;">     
                 <div class="input-group-addon ">UserType </div>
              
             <select  style="height: 50px; width:100px" id="userTypeList" >
                            <option value="-1">--select--</option>
                            <option value="0">Admin</option>
                            <option value="1">Enterprise</option>
                            <option value="2">Personal</option>
                        </select>
                  
                 <div class="input-group-addon">             
                        <input id="UserName"  class=" form-control" style="width:120px"  placeholder="UserMobile" >
                    </div>
                      <div class="input-group-addon">             
                       <%--<div class="input-group-addon"  >Date</div>--%>
                      <input id="utdate" type="text" class=" form-control" style="width:100px"  placeholder="date" >
                    </div>
                         
                    <div class="input-group-addon">             
                      <button id="btnProfitCount" class="form-control btn-primary" value="UserCount" onclick="ProfitCount()">Summary</button>
                     </div>
                   <div class="input-group-addon">             
                      <button id="btnUserSuccessTran" class="form-control btn-primary" value="UserCount" onclick="UserSuccessTran()">SuccessTran</button>
                     </div>
           <div class="input-group-addon">             
                      <button id="Button1" class="form-control btn-primary" value="UserCount" onclick="UserTakenBal()">UserTakenBal</button>
                     </div>
            <div class="input-group-addon">             
                      <button id="btnOpenCloseBal" class="form-control btn-primary" value="UserCount" onclick="UserOpenCloseBal()">OpenCloseBal</button>
                     </div>

    </div>
    

      <%--Table to Show the UnMatch TransId--%>
        <div id="Transaction-details" >
                <p id="Transaction" class="space">
                </p>
                <div class="navbar navbar-inverse " role="navigation" >
                    <div class="container-fluid">
                        <div class="navbar-header">
                            <p class="sub-header">
                                CPprofitSummary :
                            </p>

                        </div>
                    </div>
                </div>
                      <div id="table_data"></div>       <%--tabel Added Here --%>
            </div>
            
              
            

           <!-- Modal -->
          <div class="modal fade status_model_2" id="myModal_2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog" >
                <div class="modal-content">
                <div class="modal-header" style="color:black"><span style="font-size:24px;color:black">Enterprise:</span> <span style=" padding-left:50px  ; padding-right:50px;  border:solid 1px;"><asp:Label id="labelEnt" style="width:50px;" Text="" runat="server"> </asp:label></span>
                            </div>
                <div class="modal-header" style="color:black"><span style="font-size:24px;color:black">Personal: &nbsp;</span> <span style=" padding-left:50px  ; padding-right:50px;  border:solid 1px;"><asp:Label id="labelPer" style="width:50px;" Text="" runat="server"></asp:label></span>
                         </div>
                <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
                </div></div></div>
           
         
          <!--Message Model-->
        <div class="modal fade" id="model_msg" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="headerLabelmodel_msg"></h4>
                    </div>
                    <div id="model_msg_body" class="modal-body form-group col-sm-10">
                    
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="btnClose" class="btn btn-default" style="float: right; width: 100px;" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Modal -->

            <!-- Bootstrap core JavaScript
	================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->
        
         <script src="js/docs.min.js"></script>
         <script src="bootstrap.min.js"></script>
        <%--  <script src="dashboard.html.0.js"></script>--%>
        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug 
   <!-- <script src="ie10-viewport-bug-workaround.js"></script> -->
         
    
</body>
</html>
