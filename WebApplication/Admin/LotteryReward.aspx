<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Website.Master" AutoEventWireup="true" CodeBehind="LotteryReward.aspx.cs" Inherits="WebApplication.LotteryReward" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        th, td {
            text-align: center !important;
            padding: 10px !important;
            width: 12%;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="Scripts/ScrollableTablePlugin_1.0_min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#Table1').Scrollable({
                ScrollHeight: 10000
            });
        });
    </script>
    <style>
        .TimerCSS {
            text-align: center;
            margin: 15px 27%;
        }

        .TimerBoxCSS {
            background-color: #bd2130;
            padding: 10px;
            color: white;
            border-radius: 7px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <section class="section">

        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">

                        <h4>Lottery</h4>


                    </div>

                    <div class="col-md-12" style="padding-top: 10px;">
                        <div class="col-md-3">
                            <asp:DropDownList ID="drpCategory" runat="server" CssClass="form-control" OnSelectedIndexChanged="DrpApplyFor_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <!--<div class="col-md-2">
                            <asp:DropDownList ID="DrpApplyFor" runat="server" CssClass="form-control" OnSelectedIndexChanged="DrpApplyFor_SelectedIndexChanged" AutoPostBack="true">

                                <asp:ListItem Text="EWS" Value="EWS"></asp:ListItem>
                                <asp:ListItem Text="LIG" Value="LIG"></asp:ListItem>
                            </asp:DropDownList>
                        </div> -->
                        <!--<asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                    <asp:Literal ID="Literal2" runat="server"></asp:Literal> -->
                        <div class="col-md-2">
                            <asp:Button ID="btnSearch" runat="server" Text="Start Lottery" CssClass="btn-danger btn"
                                OnClick="btnSearch_Click" />

                        </div>
                        <div class="col-md-6" style="float: right">
                            <div class="col-md-12">

                                <div class="col-md-3">
                                    Total Trial: 
                                    <asp:TextBox ID="txtTrialLottery" runat="server" CssClass="form-control"></asp:TextBox>
                                    <h3>
                                        <asp:Literal ID="ltrTrialLotteryCount" runat="server"></asp:Literal></h3>
                                </div>
                                <div class="col-md-3">
                                    Seed No: 
                                    <asp:TextBox ID="txtSeedNo" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Literal ID="ltrSeedNo" runat="server"></asp:Literal>
                                </div>

                                <div class="col-md-4">
                                    <br />
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-info" OnClick="LinkButton1_Click">Go</asp:LinkButton>

                                    <asp:LinkButton ID="lnkReset" runat="server" CssClass="btn btn-info" OnClick="lnkReset_Click">Reset</asp:LinkButton>
                                </div>
                                <div class="col-md-12" style="text-align: right" id="FinalLottery" runat="server">
                                    <b>Wait For
                                        <asp:Literal ID="ltrLotteryText" runat="server"></asp:Literal>
                                        Lottery:</b>
                                    <br />
                                    <br />
                                    <span id="day" class="TimerBoxCSS"></span>

                                    Day
								
                                    <span id="hour" class="TimerBoxCSS"></span>
                                    Hrs
									 
                                    <span id="minute" class="TimerBoxCSS"></span>
                                    Min
								
                                    <span id="second" class="TimerBoxCSS"></span>
                                    Sec
                                </div>
                            </div>
                        </div>
                    </div>

                    <script>

                        var countDownDate = new Date("<%=Literal1.Text%>").getTime();

                        // Update the count down every 1 second
                        var x = setInterval(function () {

                            // Get today's date and time
                            var now = new Date().getTime();

                            // Find the distance between now and the count down date
                            var distance = countDownDate - now;

                            // Time calculations for days, hours, minutes and seconds
                            var days = Math.floor(distance / (1000 * 60 * 60 * 24));
                            var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                            var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
                            var seconds = Math.floor((distance % (1000 * 60)) / 1000);

                            // Output the result in an element with id="demo"
                            document.getElementById("day").innerHTML = days;
                            document.getElementById("hour").innerHTML = hours;
                            document.getElementById("minute").innerHTML = minutes;
                            document.getElementById("second").innerHTML = seconds;

                            // If the count down is over, write some text 
                            if (distance < 0) {
                                clearInterval(x);
                                document.getElementById("demo").innerHTML = "EXPIRED";
                            }
                        }, 1000);
                    </script>
                    <div class="card-header">
                        <div class="col-md-12" style="background-color: #e7e7e7; padding: 10px;">
                            <div class="col-md-6">
                                Category:
                                <asp:Literal ID="ltrCategory" runat="server"></asp:Literal>
                            </div>
                            <!--<div class="col-md-4">
                                Apply For:
                                <asp:Literal ID="ltrApplyFor" runat="server"></asp:Literal>
                            </div> -->
                            <div class="col-md-6">
                                Allotment Count:
                                <asp:Literal ID="ltrAllotmentCount" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                    <div class="card-body p-0">

                        <div class="table-responsive">
                            <div class="col-md-12" style="padding: 10px;">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <fieldset>
                                            <div class="col-md-12">
                                                <h4>Total Rewarded:
                        <asp:Literal ID="ltrRecordCount" runat="server"></asp:Literal></h4>

                                            </div>
                                            <asp:Repeater ID="rpt_item" runat="server">
                                                <ItemTemplate>

                                                    <div class="col-md-12" style="border: 1px solid #000; padding: 10px; color: black; background: #f5f5f5;">
                                                        <div class="col-md-12 pb-2">
                                                            <div class="col-md-1">
                                                                <b>Sr No :</b>
                                                                <%# Container.ItemIndex + 1 %>
                                                            </div>
                                                            <div class="col-md-11">
                                                                <div class="col-md-3">
                                                                    <b>Form No :</b>
                                                                    <%#Eval("RegNo") %>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <b>Plot Category :</b>
                                                                    <%#Eval("PlotCategory")%>
                                                                </div>

                                                                <div class="col-md-5">
                                                                    <b>Customer Name :</b>
                                                                    <%#Eval("CustomerName") %>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <b>Plot No :</b>
                                                                    <%#Eval("PlotNo") %>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <b>Caste :</b>
                                                                    <%#Eval("ApplicantCategory") %>
                                                                </div>

                                                                <div class="col-md-5">
                                                                    <b>Father/ Husband Name :</b>
                                                                    <%#Eval("RelationName") %>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>

                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </fieldset>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick" Enabled="false"></asp:Timer>

                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>

    </section>

</asp:Content>
