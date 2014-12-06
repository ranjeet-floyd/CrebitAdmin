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
<%--        function setModelHiddenValu(obj) {
            // $("selectionToggle").index(listItem)
            var ArrayId = obj.id.split('_');
            var Id = parseInt(ArrayId[1]);
            $("#hdnBtnId").val(Id);
            var listatus = parseInt(ArrayId[2]);
            $("#hdbBtnLi").val(listatus);
            // Changes Made By Jhamman on 26th Nov 2014 
            //Getting User Mobile Number and Customer Mobile Number Using  "ID"
            $("#hdUserName").val($("#user_" + Id + "").text());
            $("#hdCumMob").val($("#CusMOb_" + Id + "").text());
            $("#hdAccountNo").val($("#AccountNo_" + Id + "").text());
            $("#hdCusName").val($("#CusName_" + Id + "").text());


        }
    </script>

    <script type="text/javascript">
        function hideshow() {
            $("#error_text").hide();
            if ($("#SeletionList").val() == 4) {
                $("#StatusList").hide();
                $("#inputControl").hide();
                $("#inputtxtDate").show();
                return true;

            }
            else if ($("#SeletionList").val() == 7) {
                $("#StatusList").show();
                $("#inputControl").hide();
                $("#inputtxtDate").hide();
                return true;
            }

            else {
                $("#StatusList").hide();
                $("#inputControl").show();
                $("#inputtxtDate").hide();
                return true;

            }


        }
    </script>
--%>

</head>
<body>
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
    <br/><br/>
                  
                <div class="input-group" style="width: 10%;border:solid;margin-left: 5%; margin-right: 5%">
                  <div class="input-group-addon" >From Date</div>
                               <input id="fromDate" type="text"  placeholder="Select from date" runat="server">
                 <div class="input-group-addon">To Date </div>
                                <input type="text"  id="toDate" placeholder="Select to date" runat="server">            
                                <div class="input-group-addon ">OperatorType </div>
               <select   id="operatorType" runat="Server">
                            <option value="1">Airtel Landline	</option>
                            <option value="2">Airtel	</option>
                            <option value="3">Cellone	</option>
                            <option value="4">Idea	</option>
                            <option value="5">Loop Mobile	</option>
                            <option value="6">Reliance	</option>
                            <option value="7">Tata Docomo	</option>
                            <option value="8">Tata TeleServices	</option>
                            <option value="9">Vodafone	</option>
                            <option value="10">Aircel	</option>
                            <option value="11">Airtel	</option>
                            <option value="12">BSNL	</option>
                            <option value="13">BSNL(Validity/Special)</option>
                            <option value="14">Idea	</option>
                            <option value="15">Loop	</option>
                            <option value="16">MTNL(TopUp)	</option>
                            <option value="17">MTNL(Validity)</option>
                            <option value="18">MTS	</option>
                            <option value="19">Reliance(CDMA)</option>
                            <option value="20">Reliance(GSM)</option>
                            <option value="21">T24(Flexi)	</option>
                            <option value="22">T24(Special)</option>
                            <option value="23">Tata Docomo(Flexi)	</option>
                            <option value="24">Tata Docomo(Special)</option>
                            <option value="25">Tata Indicom	</option>
                            <option value="26">Uninor</option>
                            <option value="27">Videocon</option>
                            <option value="28">Virgin(CDMA)</option>
                            <option value="29">Virgin(GSM/Flexi)</option>
                            <option value="30">Virgin(GSM/Special)</option>
                            <option value="31">Vodafone</option>
                            <option value="32">Airtel Digital TV</option>
                            <option value="33">Big TV	</option>
                            <option value="34">Dish TV	</option>
                            <option value="35">Sun Direct	</option>
                            <option value="36">Tata Sky(B2C)</option>
                            <option value="37">Videocon d2h</option>
                            <option value="38">MSEB	</option>
                            <option value="41">Reliance(Mumbai)</option>
                            <option value="42">Mahanagar Gas Limited	</option>
                            <option value="43">ICICI Pru. Life	</option>
                            <option value="44">Tata AIG Life	</option>
                            <option value="45">Tikona Postpaid	</option>
                            <option value="46">Aircel	</option>
                            <option value="47">Airtel	</option>
                            <option value="48">BSNL	</option>
                            <option value="49">Idea	</option>
                            <option value="50">MTS	</option>
                            <option value="51">Reliance	</option>
                            <option value="52">Tata Docomo	</option>
                            <option value="53">Tata Indicom	</option>
                            <option value="55">Crebit Fund Transfer	</option>
                            <option value="56">Crebit Monthly Charge	</option>
                            <option value="57">Money Transfer	</option>
                            <option value="58">Crebit Refund Req.</option>
                        </select>
                       <div class="input-group-addon "><asp:FileUpload ID="templateExcel" runat="server" /> </div>
                       <div class="input-group-addon "><asp:Button Text="Matcher" class="form-control btn-primary" runat="server" ID="bqtnFilter" OnClick="btnMatcher_Click"  /></div>

               
                

            </div>
            
            <br/>

</div>

         <div class="table-responsive">
            <div class="row placeholders">
                <div class="col-xs-6 col-sm-3 placeholder">
                
            </div>
                </div>
    </div>
            <!--DashBoard -->
            <div id="DashBoard-details">
                <p id="dashBoard" class="space"></p>

                <div class="navbar navbar-inverse " role="navigation">
                    <div class="container-fluid">
                        <div class="navbar-header">

                            <p class="sub-header">DashBoard : </p> 
                        </div>

                    </div>
                </div>
                <div class="table-responsive">
                    <div class="table-responsive">
                <table class="table table-striped" style="border: 1px solid black; width: 50%; margin-left: 25%; margin-right: 25%">
                    <thead>
                        <tr class="TableColor">
                            <th># </th>
                            <th>LocalTransactionId</th>
                            <th>TemplateTransactionId</th>
                            </tr>
                    </thead>

                        <tbody id="table_data" style="border:solid" runat="server"></tbody>
                  <%-- <asp:DropDownList ID="ddlSlno" runat="server" OnSelectedIndexChanged="ddlSlno_SelectedIndexChanged"AutoPostBack="true" AppendDataBoundItems="True">
                   <asp:ListItem Selected="True"  Value="Select">- Select -</asp:ListItem>
                    </asp:DropDownList>
                  --%>  <asp:GridView ID="grvData" runat="server">
                    </asp:GridView>
                    <asp:Label ID="lblError" runat="server" />

                    </table>
                </div>
            </div>
            <!--End Electricity -->
            <!--Bank -->
            <div id="Div1" hidden="">
                <p id="P1" class="space"></p>
                <div class="navbar navbar-inverse " role="navigation">
                    -

		  <p class="sub-header">Bank Transfer  </p>
                </div>



            </div>
            <!--End Bank -->
        </div>



        <div class="modal fade status_model" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">

                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title" id="myModalLabel">Transaction Id :</h4>
                    </div>
                    <div class="modal-body form-group col-sm-10">
                        <label>Bank Transaction Id : </label>
                        <input type="text" name="name" id="inputTransactionToggleForm" runat="server" />
                        <%--<asp:TextBox ID="inputTransactionToggleForm" Style="width: 100%;" runat="server"></asp:TextBox>--%>
                        <%--<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>--%>
                        <%-- <input id="hdnBtnId" type="hidden" name="name"  runat="server" />--%>
                        <br />
                        <label>Any Comments :</label>
                        <br />
                        <textarea id="inputCommentToggleForm" runat="server" placeholder="Enter any comments"></textarea>
                    </div>



                    <div class="modal-footer">
                        <%--<button type="button" class="btn btn-default" data-dismiss="modal" onclick="btnInsert_ServerClick">Close</button>--%>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button Text="Save changes" class="btn btn-primary" runat="server" ID="saveChangebtn"  />
                        <input id="hdnBtnId" type="hidden" name="name" runat="server" />
                        <input id="hdbBtnLi" type="hidden" runat="server" />

                       <%-- Changes Made By Jhamman on 26th Nov 2014 --%>
                        <%--Adding Hidden Fields To Getting User Mobile number and Cutomer Mobile Number When Status Changed--%>

                         <input id="hdUserName" type="hidden" runat="server" />
                        <input id="hdCumMob" type="hidden" runat="server" />
                        <input id="hdAccountNo" type="hidden" runat="server" />
                        <input id="hdCusName" type="hidden" runat="server" />
                        <%-- <button type="button" class="btn btn-primary">Save changes</button>--%>
                    </div>

                </div>
            </div>
        </div>


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
        <script src="bootstrap.min.js"></script>
        <script src="docs.min.js"></script>
        <%--  <script src="dashboard.html.0.js"></script>--%>

        <!-- IE10 viewport hack for Surface/desktop Windows 8 bug 

   <!-- <script src="ie10-viewport-bug-workaround.js"></script> -->

</html>
