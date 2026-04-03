<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="DDReceipt.aspx.cs" Inherits="WebApplication.DDReceipt" %>

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

        th, td {
            text-align: center !important;
            padding: 10px !important;
            width: 12%;
            align-items: center !important;
        }
    </style>

</head>
<body style="background-color: #fff">
    <form id="form1" runat="server" style="background-color: white !important;">

        <asp:Panel ID="Panel1" runat="server">

            <div class="col-md-12" style="border-bottom: 1px solid;">
                <p style="float: right; text-decoration: underline">For Customer Use</p>
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
                    Received with thanks from 
                                    <b>
                                        <asp:Literal ID="ltrName" runat="server"></asp:Literal></b>
                    , a sum of 
                                    <b>₹
                                        <asp:Literal ID="ltrAmount" runat="server"></asp:Literal></b>
                    towards the application process 
                    
                    for the scheme of
                    <b>
                        <asp:Literal ID="ltrScheme" runat="server"></asp:Literal></b>
                    and applied under category
                    <b>
                        <asp:Literal ID="ltrCategory" runat="server"></asp:Literal></b>.
                    
                </div>
                <div class="col-12 text-center pt-3" style="display: flex; justify-content: center; align-items: center; padding-top: 10px !important">
                    <table border="1" style="border-collapse: collapse; text-align: center; width: 80% !important">
                        <tr>
                            <th>Bank Name</th>
                            <th>DD Amount</th>
                            <th>DD Number</th>
                            
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="ltrBankName" runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltrDDAmount" runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltrDDnumber" runat="server"></asp:Literal></td>
                        </tr>
                    </table>
                </div>


                <div class="col-md-12">
                    <br />
                    
                    <br />
                    Thanks
                </div>
                <div class="col-md-12">
                    Galaxy Realmart Pvt Ltd
                </div>
                <div class="col-md-12" style="text-align: center">
                    This is  computer generated receipt signature not required
                </div>
                <div class="col-md-12" style="text-align: center">
                    The validy of receipt is subject to realisation
                </div>

            </div>

            <div class="col-md-12">
                <p style="float: right; text-decoration: underline">For Office Use</p>
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
            <asp:Literal ID="ltrRegNo1" runat="server"></asp:Literal></span>
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="float: right; width: 20%; clear: both;"></span>
                </div>
                <div class="col-md-12">
                    <span style="width: 50%; float: left; clear: both;">Receipt No:
                        <asp:Literal ID="ltrReceiptNo1" runat="server"></asp:Literal></span>
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="float: right; width: 20%; clear: both;">
            Date:
                        <asp:Literal ID="ltrDate1" runat="server"></asp:Literal></span>
                </div>
                <div class="col-md-12">
                    <br />
                    Received with thanks from 
                        <b>
                            <asp:Literal ID="ltrName1" runat="server"></asp:Literal></b>
                    , a sum of 
                        <b>₹
                            <asp:Literal ID="ltrAmount1" runat="server"></asp:Literal></b>
                    towards the application process 
        
        for the scheme of
        <b>
            <asp:Literal ID="ltrScheme1" runat="server"></asp:Literal></b>
                    and applied under category
        <b>
            <asp:Literal ID="ltrCategory1" runat="server"></asp:Literal></b>.
        
                </div>
                <div class="col-12 text-center pt-3" style="display: flex; justify-content: center; align-items: center; padding-top: 10px !important">
                    <table border="1" style="border-collapse: collapse; text-align: center; width: 80% !important">
                        <tr>
                            <th>Bank Name</th>
                            <th>DD Amount</th>
                            <th>DD Number</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="ltrBankName1" runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltrDDAmount1" runat="server"></asp:Literal></td>
                            <td>
                                <asp:Literal ID="ltrDDnumber1" runat="server"></asp:Literal></td>
                        </tr>
                    </table>
                </div>


                <div class="col-md-12">
                    <br />
                    <br />
                    Thanks
                </div>
                <div class="col-md-12">
                    Galaxy Realmart Pvt Ltd
                </div>

            </div>


        </asp:Panel>

    </form>
</body>
</html>

