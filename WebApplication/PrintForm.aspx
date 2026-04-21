<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintForm.aspx.cs" Inherits="WebApplication.PrintForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Form</title>

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

        td {
            padding: 20px;
            border: 1px solid;
            
        }
        table {
            border-collapse:collapse;
        }
        body {
            background:#fff;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" style="background-color: white !important;">

        <asp:Panel ID="Panel1" runat="server">

            <div class="col-md-12">
                <div class="col-md-12" style="text-align: center">
                    <h1 style="text-align: center">
                        <br />
                        Galaxy Realmart Pvt Ltd</h1>
                    <h4>Office: S.P. 05, 03 Floor, Rico Industrial Area, Mansarovar, Jaipur – 302020</h4>
                    <h4>Contact No: +91-7849825107</h4>
                    <h4 style="text-decoration: underline; font-weight: 600">Application Form Galaxy Star City</h4>
                </div>
                <div class="col-md-12">

                    <span style="width: 50%; float: left; clear: both;">Form No:
                        <asp:Literal ID="ltrRegNo" runat="server"></asp:Literal></span>
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="float: right; width: 20%; clear: both;"></span>
                </div>
                <!--<div class="col-md-12">
                    <span style="width: 50%; float: left; clear: both;">Receipt No:
                                    <asp:Literal ID="ltrReceiptNo" runat="server"></asp:Literal></span>
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="float: right; width: 20%; clear: both;">
                        Date:
                                    <asp:Literal ID="ltrDate" runat="server"></asp:Literal></span>
                </div>-->
                <div class="col-md-12">
                    <br />
                    <br />
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="3" style="padding:0px;">
                                <table style="width: 100%">
                                    <tr>
                                        <td>Applicant Name : <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                        </td>
                                        <td><asp:Literal ID="ltrRelation" runat="server"></asp:Literal> : <asp:Literal ID="ltrRelationName" runat="server"></asp:Literal> 
                                        </td>

                                    </tr>
                                </table>



                            </td>

                        </tr>
                        <tr>
                            <td>Category : <asp:Literal ID="ltrCategory" runat="server"></asp:Literal>
                            </td>
                            <td>Apply For : <asp:Literal ID="ltrApply" runat="server"></asp:Literal>
                            </td>
                            <td>Annual Income: <asp:Literal ID="ltrIncome" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>Contact No: <asp:Literal ID="ltrContact" runat="server"></asp:Literal>
                            </td>
                            <td>Email ID : <asp:Literal ID="ltrEmail" runat="server"></asp:Literal>
                            </td>
                            <td>Pan No : <asp:Literal ID="ltrPanNo" runat="server"></asp:Literal>
                            </td>

                        </tr>
                        <tr>
                            <td>Aadhar No: <asp:Literal ID="ltrAadharNo" runat="server"></asp:Literal>
                            </td>
                            <td>Gender : <asp:Literal ID="ltrGender" runat="server"></asp:Literal>
                            </td>
                            <td>DOB : <asp:Literal ID="ltrDOB" runat="server"></asp:Literal>
                            </td>

                        </tr>
                        <tr>
                            <td colspan="3">Address : <asp:Literal ID="ltrAddress" runat="server"></asp:Literal>
                            </td>

                        </tr>
                    </table>

                    <div class="col-md-12">
                        <br />
                        <br />
                        <br />
                        <br />
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-6">Applicant Signature</div>
                        <div class="col-md-6" style="text-align: right">Galaxy Realmart Pvt Ltd</div>

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
