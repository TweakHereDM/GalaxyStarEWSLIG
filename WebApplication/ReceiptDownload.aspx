<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiptDownload.aspx.cs" Inherits="WebApplication.ReceiptDownload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Receipt</title>

    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <link href="/css/bootstrap-3.1.1.min.css" rel='stylesheet' type='text/css' />
    <link rel="icon" type="image/png" sizes="16x16" href="/images/favicon.png">
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="/js/jquery.min.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <!-- Custom Theme files -->
    <link href="/css/style.css" rel='stylesheet' type='text/css' />
    <link href='//fonts.googleapis.com/css?family=Oswald:300,400,700' rel='stylesheet' type='text/css'>
    <link href='//fonts.googleapis.com/css?family=Ubuntu:300,400,500,700' rel='stylesheet' type='text/css'>
    <!----font-Awesome----->
    <link href="/css/font-awesome.css" rel="stylesheet">
    <!----font-Awesome----->

    <style>
        .vertical-center {
            min-height: 100%; /* Fallback for browsers do NOT support vh unit */
            min-height: 100vh; /* These two lines are counted as one :-)       */
            display: flex;
            align-items: center;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" style="background-color: white !important;">

        <asp:Panel ID="Panel1" runat="server">

            <div class="col-md-12">
                <div class="col-md-12" style="text-align: center">
                    <h1 style="text-align: center">
                        <%--<img src="https://www.rajasthanjainsabha.in/SiteImage/RJSLogo1.png" alt="logo" style="text-align: center; width: 80px;">--%>
                        <br />
                        Galaxy Realmart Pvt Ltd</h1>
                    <h4>Office: S.P. 05, 03 Floor, Rico Industrial Area, Mansarovar, Jaipur – 302020</h4>
                    <h4>Contact No: +91-7849825107</h4>
                </div>
                <div class="col-md-12">

                    <span style="width: 50%; float: left; clear: both;">Form No:
                        <asp:Literal ID="ltrRegNo" runat="server"></asp:Literal></span>
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="float: right; width: 20%; clear: both;"></span>
                </div>
                <div class="col-md-12">
                    <span style="width: 50%; float: left; clear: both;">Receipt No:
                                    <asp:Literal ID="ltrReceiptNo" runat="server"></asp:Literal></span>
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="float: right; width: 20%; clear: both;">
                        Date:
                                    <asp:Literal ID="ltrDate" runat="server"></asp:Literal></span>
                </div>
                <div class="col-md-12">
                    <br />
                    <br />
                    Received with thanks from 
                                    <b>
                                        <asp:Literal ID="ltrName" runat="server"></asp:Literal></b>
                    , a sum of 
                                    <b>₹
                                        <asp:Literal ID="ltrAmount" runat="server"></asp:Literal></b>
                    towards the application process for the scheme of
                    <b>
                        <asp:Literal ID="ltrScheme" runat="server"></asp:Literal></b>
                    and applied under category
                    <b>
                        <asp:Literal ID="ltrCategory" runat="server"></asp:Literal></b>.
                    
                </div>
                <div class="col-md-12">
                    Your Mobile No:
                                        <asp:Literal ID="ltrMobileNo" runat="server"></asp:Literal>
                </div>
                <br />
                <div class="col-md-12">
                    Kindly prepare a Demand Draft (DD) in favour of Galaxy Realmart Pvt Ltd and deposit it at our office. Bank Details for reference: ICICI Bank, A/C No: 055005501503, IFSC Code: ICIC0000550.
                </div>

                <div class="col-md-12">
                    <br />
                    <br />
                    <br />
                    Thanks
                </div>
                <div class="col-md-12">
                    Galaxy Realmart Pvt Ltd
                </div>
                <div class="col-md-12" style="text-align: center">
                    <br />
                    <br />
                    This is  computer generated receipt signature not required
                </div>
                <div class="col-md-12" style="text-align: center">
                    The validy of receipt is subject to realisation
                </div>

            </div>
            </div>
            </div>

        </asp:Panel>
        <%--<div class="col-md-12" style="text-align: center;">
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Download" CssClass="btn btn-success" OnClick="Button1_Click" />
        </div>--%>
    </form>
</body>
</html>
