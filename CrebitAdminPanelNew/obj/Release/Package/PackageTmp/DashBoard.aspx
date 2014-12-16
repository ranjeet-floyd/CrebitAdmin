<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="CrebitAdminPanelNew.DashBoard" %>

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
    <script type="text/javascript">
        $(document).ready(function () {
            $("#fromDate").datepicker();
            $("#toDate").datepicker();
            $("#fromDate").val('');
            $("#toDate").val('');
        });
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
                    <a class="navbar-brand " href="#">Crebit &gt; <span id="link_page">Bank Transfer</span></a>
                </div>
                <div class="navbar-collapse collapse left_menu">
                    <ul id="ul_navbar" class="nav navbar-nav navbar-right">
                        <li><a id="a_electricity" href="Electricity_page.aspx?u=<%=QueryString%>">Electricity</a></li>
                        <li><a id="a_bank"  href="Bank Transfer.aspx?u=<%=QueryString%>">Bank Transfer</a></li>
                        <li><a id="a_refund" href="RefundRequest.aspx?u=<%=QueryString%>">RefundRequest </a></li>
                        <li><a id="a1" href="Transaction_Page.aspx?u=<%=QueryString%>">Transaction</a></li>
                        <li><a id="a_Dashboard"class="active" href="DashBoard.aspx?u=<%=QueryString%>">DashBoard</a></li>
                        <li><a href="#">Profile</a></li>
                        <li><a href="Login.aspx">Logout</a></li>
                    </ul>

                </div>
            </div>
        </div>
    <br/><br/><br/><br/>
         
         <%--Selction Controls --%>
             <div class="input-group" style="width:90%;padding-left: 10%;padding-right: 5%;">
                  <div class="input-group-addon" >From Date</div>
                               <input id="fromDate" type="text"  placeholder="Select from date" runat="server" required/>
                 <div class="input-group-addon" style>To Date </div>
                                <input type="text"  id="toDate" placeholder="Select to date" runat="server" required/>            
                                <div class="input-group-addon " >OperatorType </div>
               <select   id="operatorType" runat="Server">
                    <option value="-1">---Select---	</option>        
                    <option value="10">Airtel Landline	</option>
                            <option value="11">Airtel	</option>
                            <option value="12">Cellone	</option>
                            <option value="13">Idea	</option>
                            <option value="14">Loop Mobile	</option>
                            <option value="15">Reliance	</option>
                            <option value="16">Tata Docomo	</option>
                            <option value="17">Tata TeleServices	</option>
                            <option value="18">Vodafone	</option>
                            <option value="20">Aircel	</option>
                            <option value="21">Airtel	</option>
                            <option value="22">BSNL	</option>
                            <option value="23">BSNL(Validity/Special)</option>
                            <option value="24">Idea	</option>
                            <option value="25">Loop	</option>
                            <option value="26">MTNL(TopUp)	</option>
                            <option value="27">MTNL(Validity)</option>
                            <option value="28">MTS	</option>
                            <option value="29">Reliance(CDMA)</option>
                            <option value="200">Reliance(GSM)</option>
                            <option value="2011">T24(Flexi)	</option>
                            <option value="202">T24(Special)</option>
                            <option value="203">Tata Docomo(Flexi)	</option>
                            <option value="204">Tata Docomo(Special)</option>
                            <option value="205">Tata Indicom	</option>
                            <option value="206">Uninor</option>
                            <option value="207">Videocon</option>
                            <option value="208">Virgin(CDMA)</option>
                            <option value="209">Virgin(GSM/Flexi)</option>
                            <option value="210">Virgin(GSM/Special)</option>
                            <option value="211">Vodafone</option>
                            <option value="30">Airtel Digital TV</option>
                            <option value="31">Big TV	</option>
                            <option value="32">Dish TV	</option>
                            <option value="33">Sun Direct	</option>
                            <option value="34">Tata Sky(B2C)</option>
                            <option value="35">Videocon d2h</option>
                            <option value="40">MSEB	</option>
                            <option value="41">Reliance(Mumbai)</option>
                            <option value="42">TorrentPower(Gujrat)</option>
							<option value="50">Mahanagar Gas Limited</option>
                            <option value="60">ICICI Pru. Life	</option>
                            <option value="61">Tata AIG Life	</option>
                            <option value="70">Tikona Postpaid	</option>
                            <option value="80">Aircel	</option>
                            <option value="81">Airtel	</option>
                            <option value="82">BSNL	</option>
                            <option value="83">Idea	</option>
                            <option value="84">MTS	</option>
                            <option value="85">Reliance	</option>
                            <option value="86">Tata Docomo	</option>
                            <option value="87">Tata Indicom	</option>
                            <option value="1100">Crebit Fund Transfer	</option>
                            <option value="1200">Crebit Monthly Charge	</option>
                            <option value="1300">Money Transfer	</option>
                            
                        </select>
                       <div class="input-group-addon " style="width:5px"><asp:FileUpload ID="templateExcel" runat="server" /> </div>
             
             <div class="input-group-addon"><asp:Button Text="Matcher" class="form-control btn-primary" runat="server" ID="bqtnFilter" OnClick="btnMatcher_Click"  /></div>
            
             
             </div>
         <div><asp:Label Text="" class="form-control"  ID="ExcelTypemsg" style="background-color:#fff;border:0px; color:red; width:100%; padding-left: 68%;" runat="server"/></div>
         <br/><br/>
       <%--Table to Show the UnMatch TransId--%>
            <div id="DashBoard-details">
                <p id="dashBoard" class="space"></p>
                <div class="navbar navbar-inverse " role="navigation">
                    <div class="container-fluid">
                        <div class="navbar-header">
                             <!--DashBoard  Title-->
                            <p class="sub-header">DashBoard : </p> 
                        </div>
                    </div>
                </div>
               <br/>
                <div class="table-responsive">
                <table class="table table-striped" style="border: 1px solid black; width: 50%; margin-left: 25%; margin-right: 25%">
                    <thead>
                        <tr class="TableColor">
                            <th># </th>
                            <th>LocalTransactionId</th>
                            <th>TemplateTransactionId</th>
                            </tr>
                    </thead>

                        <tbody id="table_data"  runat="server"></tbody>
                    </table>
                </div>
            </div>

     </form>
</body>
            <!-- Bootstrap core JavaScript
	================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->
        <script src="bootstrap.min.js"></script>
        <script src="docs.min.js"></script>
        <%--  <script src="dashboard.html.0.js"></script>--%>
        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug 
   <!-- <script src="ie10-viewport-bug-workaround.js"></script> -->

</html>
