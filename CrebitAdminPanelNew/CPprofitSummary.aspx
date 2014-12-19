<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CPprofitSummary.aspx.cs" Inherits="CrebitAdminPanelNew.CPprofitSummary" %>

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
    <link href="../css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.custom.js" type="text/javascript"></script>
    <script src="Scripts/cookies.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#fromDate").datepicker();
            $("#toDate").datepicker();
            $("#utdate").datepicker();
            $("#fromDate").val('');
            $("#toDate").val('');
        });

        //Ajax Call to Get the Number Of User

        function GetUserCount() {

            var dataJSON = {};
            dataJSON.UserType = $("#userTypeList").val(); dataJSON.Date = $("#utdate").val(); dataJSON.UserName = $("#@UserName").val();
            AjaxCall("POST", 'api/UserCount', dataJSON, Onsuccess);
            return false;
           
        }
        function Onsuccess(resObj) {
            try {
                if (resObj != null & resObj != "") {
                    if ($('#userTypeList').val() == 1) { $('#labelEnt').val() = '' + response['totalCount']; }
                    else $('#labelEnt').val() = '' + response['totalCount'];
                }
            } catch (ex) { }
        }


        </script>
</head>
<body>
     <%--Navigation  Bar --%>
     <form id="dashBoardForm" runat="server">
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
     
      
         <%-- User Profit Count Control--%>
            <div class="dashboard-middle">
            <div class="navbar-collapse collapse subData">
               
                <ul class="nav navbar-nav navbar-right margin5 " style="border-style: solid;border-width: 1px; border-color:#ededf1;padding:10px; padding-left:20px;padding-right:20px ">
                  <li>
                        <select class=" form-control" id="userTypeList"  runat="server" >
                            <option value="o">---Select---</option>
                            <option value="1">Enterprise</option>
                            <option value="2">Personal</option>
                        </select>
                    </li>
                  
                    <li>
                        <input id="UserName"  class=" form-control" style="width:120px"  placeholder="UserMobile" runat="server">
                    </li>
                      <li>
                       <%--<div class="input-group-addon"  >Date</div>--%>
                      <input id="utdate" type="text" class=" form-control" style="width:100px"  placeholder="date" runat="server">
                    </li>
                         
                    <li>
                        <input id="btnUserCount" type="button" class="form-control btn-primary"  data-toggle='modal' data-target='.status_model_2' value="UserCount" onclick = "GetUserCount()" runat="server" />
                        <%--<asp:Button Text="UserCount" class="form-control btn-primary" runat="server" ID="userCount" />--%>
                    </li>

                          </ul>
</div>
</div>

         
      
      
         <%--Label Control TO Show Exception--%>
         <div><asp:Label Text="" class="form-control"  ID="ExcelTypemsg" style="background-color:#fff;border:0px; color:red; width:100%; padding-left: 68%;" runat="server"/></div>
          <br/><br/>
       <%--Table to Show the UnMatch TransId--%>
            <div id="DashBoard-details">
                <p id="dashBoard" class="space"></p>
                <div class="navbar navbar-inverse " role="navigation">
                    <div class="container-fluid">
                        <div class="navbar-header">
                             <!--DashBoard  Title-->
                            <p class="sub-header">CPprofitSummary : </p> 
                        </div>
                    </div>
                </div>
               <br/>
              
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
                    </div></div></div></div>

            <!-- Bootstrap core JavaScript
	================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->
        <script src="bootstrap.min.js"></script>
        <script src="docs.min.js"></script>
        <%--  <script src="dashboard.html.0.js"></script>--%>
        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug 
   <!-- <script src="ie10-viewport-bug-workaround.js"></script> -->
         
    </form>
</body>
</html>
