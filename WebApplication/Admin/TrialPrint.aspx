<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrialPrint.aspx.cs" Inherits="WebApplicationAdmin.TrialPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title style="text-transform: uppercase;">Trial List </title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/font-awesome_all.min.css" />
    <link rel="stylesheet" href="css/style.css" />

    <link rel="stylesheet" href="../cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <style>
        th {
            background-color: #f5f5f5;
            text-align: center;
        }

        td, th {
            border: 1px solid;
            text-align: center;
        }

        .hide {
            display: none
        }

        .form-check-inline {
            margin-right: 0px !important;
        }

        #inpGender input[type="radio"],
        #inpRelation input[type="radio"],
        #idTypeRadioList input[type="radio"] {
            margin-right: 5px;
        }

        #inpGender label,
        #inpRelation label,
        #idTypeRadioList label {
            margin-right: 20px;
        }
    </style>

    <style media="print">
        .no-print {
            display: none;
        }

        body {
            margin: 0;
            padding: 10px;
        }

        /* aur specific styles for print here */
    </style>
    <script type="text/javascript">
        function printDiv() {
            var printContents = document.getElementById("printableArea").innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
            location.reload(); // optional: page ko reload kar de after print
        }
    </script>

</head>
<body class="light light-sidebar theme-white">
    <form id="form1" runat="server">

        <div class="container-fluid">
            <nav class="navbar navbar-light bg-light fixed-top ">
                <div class="container text-center">
                    <h1 style="text-align: center"><a href="LotteryReward.aspx">Trial Lottery -
                        <asp:Literal ID="ltrLotteryNo" runat="server"></asp:Literal></a></h1>
                    <h2 style="text-align: center">Seed No -
                        <asp:Literal ID="ltrSeedNo" runat="server"></asp:Literal></h2>

                </div>
            </nav>
        </div>
        <div class="register-form-container">
            <div class="container">

                <div class="tab-content" id="pills-tabContent">
                    <div class="tab-pane fade show active" id="pills-personal" role="tabpanel" aria-labelledby="pills-personal-details">

                        <div class="row g-4">
                            <div class="col-md-4" style="float: right">
                                Select Category:
    <asp:DropDownList ID="drpCategory" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="drpLotteryNo_SelectedIndexChanged">
    </asp:DropDownList>

                            </div>
                            <div class="col-md-4" style="float: right">
                                Select Trial No:
                                <asp:DropDownList ID="drpLotteryNo" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="drpLotteryNo_SelectedIndexChanged">
                                </asp:DropDownList>

                            </div>

                            <div class="col-md-12">
                                <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="false" Font-Size="11pt"
                                    DataKeyNames="ID" CssClass="grid" PageSize="100" Width="100%" CellPadding="10">
                                    <Columns>
                                        <asp:BoundField DataField="RegNo" HeaderText="Form No" />
                                        <asp:BoundField DataField="PlotNo" HeaderText="Plot No" />

                                        <asp:BoundField DataField="PlotCategory" HeaderText="Plot Category" />
                                        <asp:BoundField DataField="ApplicantCategory" HeaderText="Applicant Category" />

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            HeaderText="Customer Details">
                                            <ItemTemplate>

                                                <%#Eval("CustomerName") %>
                                                <br />
                                                Father Name/ Husband Name: <%#Eval("Father") %>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        </asp:TemplateField>

                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Records Found...
                                    </EmptyDataTemplate>
                                    <AlternatingRowStyle BackColor="#f9f9f9" />
                                    <HeaderStyle ForeColor="Black" />
                                    <PagerStyle CssClass="GridPager" />
                                </asp:GridView>
                            </div>

                        </div>

                    </div>


                </div>
            </div>
        </div>


        <script src="css/bootstrap.bundle.min.js"></script>
        <script src="css/jquery.min.js"></script>

        <script src="css/script.js"></script>

    </form>
</body>
</html>
