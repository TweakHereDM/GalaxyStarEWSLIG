<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplicationAdmin.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, shrink-to-fit=no" name="viewport">
    <title>Lottery</title>
    <!-- General CSS Files -->
    <link rel="stylesheet" href="assets/css/app.min.css">
    <link rel="stylesheet" href="assets/bundles/bootstrap-social/bootstrap-social.css">
    <!-- Template CSS -->
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="stylesheet" href="assets/css/components.css">
    <!-- Custom style CSS -->
    <link rel="stylesheet" href="assets/css/custom.css">
    <link rel='shortcut icon' type='image/x-icon' href='assets/img/favicon.ico' />
</head>
<body class="dark light-sidebar theme-white">
    <div class="loader"></div>
    <div id="app">
        <section class="section">
            <div class="container mt-5">
                <div class="row">
                    <div class="col-12 col-sm-8 offset-sm-2 col-md-6 offset-md-3 col-lg-6 offset-lg-3 col-xl-4 offset-xl-4">
                        <div class="card card-primary" style="background: lightcyan;">
                            <div class="card-header">
                                <h4>Lottery Login</h4>
                            </div>
                            <div class="card-body">
                                <form class="needs-validation" runat="server">
                                    <p>
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Index" CssClass="alertSummary"
                                            HeaderText=" " />
                                    </p>
                                    <div class="form-group">
                                        <label for="email">User ID</label>
                                        <asp:TextBox ID="txtUser" runat="server" class="form-control" placeholder="User ID"></asp:TextBox>
                                        <div class="invalid-feedback">
                                            Please fill in your email
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="d-block">
                                            <label for="password" class="control-label">Password</label>
                                            
                                        </div>
                                        <asp:TextBox ID="txtPass" runat="server" class="form-control" TextMode="Password" Placeholder="Password"></asp:TextBox>

                                        <div class="invalid-feedback">
                                            please fill in your password
                                        </div>
                                    </div>
                                    <div class="form-group text-center" >
                                        <asp:Button ID="buttLogin" runat="server" Text="Login Now" OnClick="buttLogin_Click"
                                            ValidationGroup="Index" CssClass="btn btn-success" />

                                    </div>
                                </form>
                                <%-- <div class="text-center mt-4 mb-3">
                                    <div class="text-job text-muted">Login With Social</div>
                                </div>
                                <div class="row sm-gutters">
                                    <div class="col-6">
                                        <a class="btn btn-block btn-social btn-facebook">
                                            <span class="fab fa-facebook"></span>Facebook
                                        </a>
                                    </div>
                                    <div class="col-6">
                                        <a class="btn btn-block btn-social btn-twitter">
                                            <span class="fab fa-twitter"></span>Twitter
                                        </a>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                        <%--  <div class="mt-5 text-muted text-center">
                            Don't have an account? <a href="Register.aspx">Create One</a>
                        </div>--%>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <!-- General JS Scripts -->
    <script src="assets/js/app.min.js"></script>
    <!-- JS Libraies -->
    <!-- Page Specific JS File -->
    <!-- Template JS File -->
    <script src="assets/js/scripts.js"></script>
    <!-- Custom JS File -->
    <script src="assets/js/custom.js"></script>
</body>
</html>
