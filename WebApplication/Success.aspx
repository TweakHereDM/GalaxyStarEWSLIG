<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="WebApplication.Success" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Confirmation</title>

    <!-- Stylesheets -->
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/font-awesome_all.min.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

    <style>
        body {
            background-color: #dddddd;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        .form-control, .btn {
            border-radius: 0.375rem;
        }

        .section-title {
            background-color: #6c757d;
            color: white;
            padding: 10px 0;
            text-align: center;
            margin-bottom: 20px;
            font-weight: 500;
        }

        .transaction-info strong {
            display: block;
            font-weight: 600;
        }

        .transaction-info {
            background-color: #ffffff;
            padding: 15px;
            border-radius: 6px;
            box-shadow: 0 0 8px rgba(0, 0, 0, 0.05);
        }

        .btn + .btn {
            margin-left: 10px;
        }

        .img-fluid{
height:300px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navbar -->
        <div class="container-fluid" style="margin-bottom: 100px; background-color: #dddddd !important;">
            <nav class="navbar navbar-light bg-light fixed-top">
                <div class="container">
                    <a href="index.aspx" class="navbar-brand" id="front-logo">Galaxy Realmart Pvt Ltd</a>
                </div>
            </nav>
        </div>

        <!-- Main Container -->
        <div class="container pt-0 mt-5 mb-0" style="background-color: white;">

            <!-- Section Title -->
            <div class="col-12 p-0 m-0">
                <p class="section-title">Payment Confirmation</p>
            </div>

            <!-- Status Information -->
            <div class="row text-center mb-5 transaction-info">
                <div class="col-md-4 col-6 mb-3 text-center">
                    <strong>Transaction ID</strong>
                    <asp:Literal ID="ltrtxn_id" runat="server"></asp:Literal>
                </div>
                <div class="col-md-4 col-6 mb-3 text-center">
                    <strong>Order ID</strong>
                    <asp:Literal ID="ltrOrderID" runat="server"></asp:Literal>
                </div>
                
                <div class="col-md-4 col-6 mb-3 text-center">
                    <strong>Payment Status</strong>
                    <asp:Literal ID="ltrpayment_stat" runat="server"></asp:Literal>
                </div>
            </div>

            <div class="col-12 d-flex justify-content-center">
                <img alt="" src="Images/Thank you.png" class="img-fluid" />
            </div>


            <div class="text-center mt-4 mb-1">
                <asp:LinkButton ID="lnkbtn" runat="server" CssClass="btn btn-danger me-2" Text="View Receipt" OnClick="lnkbtn_Click"></asp:LinkButton>
                <a target="_blank" href="praman patra.pdf" class="btn btn-success">Print Praman Patra</a>

            </div>
            <div class="col-md-12 text-center" style="padding-bottom:20px;">
                * Print Praman Patra, Get it with you when you deposit the Demand Draft (DD)
            </div>
        </div>
    </form>
</body>
</html>
