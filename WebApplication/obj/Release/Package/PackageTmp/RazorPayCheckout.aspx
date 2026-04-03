<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RazorPayCheckout.aspx.cs" Inherits="WebApplication.RazorPayCheckout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="UTF-8">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1" />
    <link rel="canonical" href="http://www.ikkatjaipur.com/" />
    <meta name="description" content="" />
    <link rel="icon" type="image/png" sizes="16x16" href="/assets/images/16x16.png">
    <title></title>
    <link rel="stylesheet" href="/assets/css/plugins.css">
    <!-- Bootstap CSS -->
    <link rel="stylesheet" href="/assets/css/bootstrap.min.css">
    <!-- Main Style CSS -->
    <link rel="stylesheet" href="/assets/css/style.css">
    <link rel="stylesheet" href="/assets/css/responsive.css">
    <meta charset="UTF-8">
    <link rel="canonical" href="https://www.ikkatjaipur.com/" />
    <meta name="description" content="" />
    <link rel="icon" type="image/png" sizes="16x16" href="/assets/images/16x16.png">
    <style>
        .fa {
            font-size: 24px;
        }

        @media (min-width:990px) {
            .logoImg {
                width: 48% !important;
            }
        }

        /* Breadcrumb Style */
        .bredcrumbWrap {
            background-color: #f9f9f9;
            padding: 15px 0;
            font-size: 14px;
        }

        .breadcrumbs a {
            color: #007bff;
            text-decoration: none;
            font-weight: 500;
        }

        .breadcrumbs span {
            color: #6c757d;
        }

        /* Section Container */
        .product-template__container {
            background: #ffffff;
            border: 1px solid #ddd;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.05);
        }

        /* Heading */
        .product-single h3 {
            font-size: 24px;
            color: #333;
            font-weight: 600;
        }

        /* Labels and values */
        .row label {
            color: #555;
            font-size: 16px;
        }

        .row .col-sm-8 {
            font-size: 16px;
            font-weight: 500;
            color: #222;
        }

        /* Button Styling */
        .btn-primary {
            background-color: #007bff;
            border: none;
            font-size: 16px;
            font-weight: 600;
            padding: 10px 25px;
            border-radius: 6px;
            transition: all 0.3s ease-in-out;
        }

            .btn-primary:hover {
                background-color: #0056b3;
            }


        .main-content {
            position: fixed !important;
            width: 50%;
        }
        /* Responsive Enhancements */
        @media (max-width: 768px) {
            .product-template__container {
                padding: 20px;
            }

            .product-single h3 {
                font-size: 20px;
            }

            .row label,
            .row .col-sm-8 {
                font-size: 15px;
            }
        }

        html {
            overflow: scroll !important;
        }
    </style>
</head>
<body class="template-product belle">
    <div class="pageWrapper">
        <div id="page-content">
            <div id="MainContent" role="main">
                <!-- Breadcrumb -->
                <div class="bredcrumbWrap py-3 bg-light border-bottom" style="background-color: #6c757d !important; color: white !important;">
                    <div class="container breadcrumbs">
                        <a href="Index.aspx" title="Back to the home page">Home</a>
                        <span aria-hidden="true" class="mx-2">›</span>
                        <span>
                            <asp:Label ID="Label1" ForeColor="White" runat="server" Text="Razor Pay Checkout"></asp:Label></span>
                    </div>
                </div>

                <div id="ProductSection-product-template" class="product-template__container container py-5">
                    <div class="product-single">
                        <div class="row">
                            <div class="col-lg-6 col-md-8 col-sm-12" style="text-align: center">
                                <h3 class="mb-4">Scan and "Pay" your "Payable Amount".</h3>
                                <h4 class="mb-4">Once Payment is done, please share your screenshot to <a target="_blank" href="https://wa.me/917849825107">"+917849825107"</a>. You can click on Number to open the whatsapp. </h4>
                                <h4 class="mb-4">Once you share your screenshot, now kindly prepare a Demand Draft (DD) in favour of "Galaxy Realmart Private Limited" and deposit it at our office. </h4>
                                <h4>Bank Details for reference: ICICI Bank, A/C No: 055005501503, IFSC Code: ICIC0000550.</h4>

                                <div class="mb-3 row align-items-center">
                                    <label class="col-sm-4 col-form-label fw-semibold" style="font-size: 18px;">Order ID:</label>
                                    <div class="col-sm-8" style="font-size: 18px;">
                                        <b>
                                            <asp:Literal ID="ltrOrderNo" runat="server" /></b>
                                    </div>
                                </div>
                                <br />
                                <div class="mb-3 row align-items-center">
                                    <label class="col-sm-4 col-form-label fw-semibold" style="font-size: 18px;">Payable Amount:</label>
                                    <div class="col-sm-8" style="font-size: 18px;">
                                        <b>
                                            <asp:Literal ID="ltrPayableAmount" runat="server" /></b>
                                    </div>
                                </div>
                                <br />
                                <div class="col-lg-6 col-md-6 col-sm-12 col-12">
                                    <% if (BusinessLogicLayer.WebsiteSession.Payable == 500)
                                    { %>
                                    <img src="/images/1000.jpeg" style="display: block; margin-left: auto; margin-right: auto; max-width: 100%; width:20%" />
                                    <% }   %>

                                    <% if (BusinessLogicLayer.WebsiteSession.Payable == 1000)
                                    { %>
                                    <img src="/images/1000.jpeg" style="display: block; margin-left: auto; margin-right: auto; max-width: 100%; width:20%" />
                                    <% }   %>
                                    <%-- <form action="/Success.aspx?refRazor=<%=BusinessLogicLayer.WebsiteSession.OrderNumber%>" method="post" class="PayNow">

                                        <script
                                            src="https://checkout.razorpay.com/v1/checkout.js"
                                            data-key="<%=BusinessLogicLayer.RazorPayApi.key %>"
                                            data-amount="<%=BusinessLogicLayer.WebsiteSession.PayableAmount%>"
                                            data-name="Eden Garden-1"
                                            data-description="Purchase Description"
                                            data-order_id="<%=BusinessLogicLayer.WebsiteSession.OrderID%>"
                                            data-image="https://razorpay.com/favicon.png"
                                            data-prefill.name="<%=BusinessLogicLayer.WebsiteSession.UserName%>"
                                            data-prefill.email="<%=BusinessLogicLayer.WebsiteSession.EmailID%>"
                                            data-prefill.contact="<%=BusinessLogicLayer.WebsiteSession.UserMobile%>"
                                            data-theme.color="#F37254"></script>

                                    </form>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
