<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="FormPrint.aspx.cs" Inherits="WebApplication.FormPrint" %>

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

            <div class="col-md-12">

                <div class="col-md-12" style="text-align: center">
                    <h1 style="text-align: center">
                        <%--<img src="https://www.rajasthanjainsabha.in/SiteImage/RJSLogo1.png" alt="logo" style="text-align: center; width: 80px;">--%>
                        <br />
                        Galaxy Realmart Pvt Ltd</h1>
                </div>
                <div class="col-md-12">

                    Form No:
                        <asp:Literal ID="ltrRegNo" runat="server"></asp:Literal>
                </div>
                <div class="col-12 text-center pt-3" style="display: flex; justify-content: center; align-items: center; padding-top: 10px !important">
                    <div class="register-form-container">
                        <div class="container">

                            <div class="tab-content" id="pills-tabContent">
                                <div class="tab-pane fade show active" id="pills-personal" role="tabpanel" aria-labelledby="pills-personal-details">

                                    <div class="row g-4">
                                        <div class="col-12 p-0 m-0 mt-1">
                                            <p class="text-center bg-secondary text-white py-2">Fill Personal Details</p>
                                        </div>
                                        <asp:Literal ID="litOrderID" Visible="false" runat="server"></asp:Literal>

                                        <div class="col-12 col-md-2">
                                            <label class="form-label">Apply For <span class="text-danger">*</span></label>

                                            <asp:DropDownList ID="DrpApplyFor" runat="server" CssClass="form-control" AppendDataBoundItems="true" Required="true">
                                                <asp:ListItem Text="--Apply For--" Value="" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="EWS (500/-)" Value="EWS"></asp:ListItem>
                                                <asp:ListItem Text="LIG (1000/-)" Value="LIG"></asp:ListItem>
                                            </asp:DropDownList>

                                            <asp:RequiredFieldValidator ID="rfvApplyFor" runat="server"
                                                ControlToValidate="DrpApplyFor"
                                                InitialValue="" ErrorMessage="Please select an option for Apply For"
                                                CssClass="text-danger" Display="Dynamic" />

                                        </div>

                                        <div class="col-12 col-md-6 col-lg-3">

                                            <label class="form-label">Application Holder Name <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" required="true"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="rfvName" runat="server"
                                                ControlToValidate="txtName"
                                                ErrorMessage="Name is required"
                                                CssClass="text-danger" Display="Dynamic" />

                                        </div>
                                        <div class="col-12 col-md-6 col-lg-3">
                                            <label class="form-label">Gender <span class="text-danger">*</span></label>
                                            <br>
                                            <div class="div pt-2">
                                                <asp:RadioButtonList ID="inpGender" runat="server" RepeatDirection="Horizontal" required="true" RepeatLayout="Flow">
                                                    <asp:ListItem Text="Male" Value="Male" />
                                                    <asp:ListItem Text="Female" Value="Female" />
                                                </asp:RadioButtonList>

                                                <asp:RequiredFieldValidator ID="rfvGender" runat="server"
                                                    ControlToValidate="inpGender"
                                                    InitialValue=""
                                                    ErrorMessage="Please select your gender"
                                                    CssClass="text-danger" Display="Dynamic" />
                                            </div>
                                        </div>
                                        <div class="col-12 col-md-6 col-lg-3">
                                            <label class="form-label">Date Of Birth <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtDob" runat="server" CssClass="form-control" TextMode="Date" required="true"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="rfvDob" runat="server"
                                                ControlToValidate="txtDob"
                                                ErrorMessage="Date of Birth is required"
                                                CssClass="text-danger" Display="Dynamic" />

                                        </div>
                                        <div class="col-12 col-md-6 col-lg-3">
                                            <label class="form-label">Email Address <span class="text-danger">*</span></label>

                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" required="true"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                                                ControlToValidate="txtEmail"
                                                ErrorMessage="Email is required"
                                                CssClass="text-danger" Display="Dynamic" />

                                        </div>
                                        <div class="col-12 col-md-6 col-lg-3">
                                            <label class="form-label">Select One <span class="text-danger">*</span></label>
                                            <br />
                                            <div class="div pt-2">
                                                <asp:RadioButtonList ID="inpRelation" runat="server" RepeatDirection="Horizontal" required="true" CssClass="form-check form-check-inline">
                                                    <asp:ListItem Text="Father" Value="Father" />
                                                    <asp:ListItem Text="Husband" Value="Husband" />
                                                </asp:RadioButtonList>

                                                <!-- RequiredFieldValidator for RadioButtonList -->
                                                <asp:RequiredFieldValidator ID="rfvRelation" runat="server"
                                                    ControlToValidate="inpRelation"
                                                    InitialValue=""
                                                    ErrorMessage="Please select Father or Husband"
                                                    CssClass="text-danger" Display="Dynamic" />
                                            </div>
                                        </div>
                                        <div class="col-12 col-md-6 col-lg-3">
                                            <label class="form-label">Father/Husband Name <span class="text-danger">*</span></label>

                                            <asp:TextBox ID="txtRelationName" runat="server" CssClass="form-control" required="true"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="rfvRelationName" runat="server"
                                                ControlToValidate="txtRelationName"
                                                ErrorMessage="Name is required"
                                                CssClass="text-danger" Display="Dynamic" />

                                        </div>
                                        <div class="col-12 col-md-6 col-lg-3">
                                            <label class="form-label">Mobile Number <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" MaxLength="10" TextMode="Number"> </asp:TextBox>

                                            <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtContact" ErrorMessage="Mobile Number is required" CssClass="text-danger" Display="Dynamic" />
                                            <asp:RegularExpressionValidator ID="revMobile" runat="server" ControlToValidate="txtContact" ErrorMessage="valid Mobile Number" ValidationExpression="^\d{10}$" CssClass="text-danger" Display="Dynamic" />

                                        </div>
                                        <div class="col-12 col-md-6 col-lg-6">
                                            <label class="form-label">Select One <span class="text-danger">*</span></label>
                                            <br />
                                            <div class="pt-2">
                                                <asp:RadioButtonList ID="idTypeRadioList" runat="server" RepeatDirection="Horizontal" required="true" CssClass="form-check form-check-inline">
                                                    <asp:ListItem Text="Pan" Value="Pan" />
                                                    <asp:ListItem Text="Driving License" Value="Driving License" />
                                                    <asp:ListItem Text="Voter ID" Value="Voter ID" />
                                                    <asp:ListItem Text="Rashan Card" Value="Rashan Card" />
                                                </asp:RadioButtonList>

                                                <asp:RequiredFieldValidator ID="rfvIdType" runat="server"
                                                    ControlToValidate="idTypeRadioList"
                                                    ErrorMessage="Please select an ID type"
                                                    CssClass="text-danger" Display="Dynamic"
                                                    InitialValue="" />
                                            </div>
                                        </div>
                                        <div class="col-12 col-md-6 col-lg-3">
                                            <label class="form-label">ID No <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtidValues" runat="server" CssClass="form-control" required="true"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="rfvIdNo" runat="server"
                                                ControlToValidate="txtidValues"
                                                ErrorMessage="ID number is required"
                                                CssClass="text-danger" Display="Dynamic" />

                                        </div>
                                        <div class="col-12 col-md-6 col-lg-3">
                                            <label class="form-label">Aadhar Number <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtAadharNumber" runat="server" CssClass="form-control" TextMode="Number" MaxLength="12"></asp:TextBox>

                                            <asp:RequiredFieldValidator
                                                ID="rfvAadhar"
                                                runat="server"
                                                ControlToValidate="txtAadharNumber"
                                                ErrorMessage="Aadhar Number is required"
                                                CssClass="text-danger"
                                                Display="Dynamic" />

                                            <asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator1"
                                                runat="server"
                                                ControlToValidate="txtAadharNumber"
                                                ErrorMessage="valid Aadhar Number"
                                                ValidationExpression="^\d{12}$"
                                                CssClass="text-danger"
                                                Display="Dynamic" />

                                        </div>

                                        <div class="col-12 col-md-6 col-lg-3">
                                            <label class="form-label">Pin Code <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtPinCode" runat="server" CssClass="form-control" TextMode="Number" required="true"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="rfvZip" runat="server"
                                                ControlToValidate="txtPinCode"
                                                ErrorMessage="Zip Code is required"
                                                CssClass="text-danger" Display="Dynamic" />

                                        </div>
                                        <div class="col-12 col-md-6 col-lg-3">
                                            <label class="form-label">City <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" required="true"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="rfvCity" runat="server"
                                                ControlToValidate="txtCity"
                                                ErrorMessage="City is required"
                                                CssClass="text-danger" Display="Dynamic" />

                                        </div>
                                        <div class="col-12 col-md-6 col-lg-3">
                                            <label class="form-label">State <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtState" runat="server" CssClass="form-control" Text="Rajasthan" ReadOnly="true" required="true"></asp:TextBox>

                                        </div>
                                        <div class="col-12 col-md-6 col-lg-3">
                                            <label class="form-label">Country <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control" Text="India" ReadOnly="true" required="true"></asp:TextBox>

                                        </div>
                                        <div class="col-12">
                                            <label class="form-label">Permanent Address <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtAddress" class="form-control" required="true" TextMode="MultiLine" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvAddress" runat="server"
                                                ControlToValidate="txtAddress"
                                                ErrorMessage="Address is required"
                                                CssClass="text-danger" Display="Dynamic" />
                                        </div>
                                        <div class="col-12">
                                            <p class="text-center bg-secondary text-white py-2">Fill Income Details</p>
                                        </div>

                                        <div class="col-12 col-md-6">
                                            <label class="form-label">Category <span class="text-danger">*</span></label>

                                            <asp:DropDownList ID="DrpCategory" runat="server" CssClass="form-control" required="true" AppendDataBoundItems="true">
                                                <asp:ListItem Text="--SELECT Cast--" Value="" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Un-Reserved" Value="Un-Reserved" />
                                                <asp:ListItem Text="Soldier (Handicap)" Value="Soldier (Handicap)" />
                                                <asp:ListItem Text="Soldier(Widow &amp; Dependent)" Value="Soldier(Widow &amp; Dependent)" />
                                                <asp:ListItem Text="Handicapped(Un-Reserved)" Value="Handicapped(Un-Reserved)" />
                                                <asp:ListItem Text="Un-Reserved-Women(Single and Landless)" Value="Un-Reserved-Women(Single and Landless)" />
                                                <asp:ListItem Text="Scheduled Caste(Other)" Value="Scheduled Caste(Other)" />
                                                <asp:ListItem Text="Scheduled Tribe(Other)" Value="Scheduled Tribe(Other)" />
                                                <asp:ListItem Text="State Government Employee" Value="State Government Employee" />

                                            </asp:DropDownList>

                                            <asp:RequiredFieldValidator ID="rfvCategory" runat="server"
                                                ControlToValidate="DrpCategory"
                                                InitialValue="" ErrorMessage="Please select a category"
                                                CssClass="text-danger" Display="Dynamic" />

                                        </div>
                                        <div class="col-12 col-md-6">
                                            <label class="form-label">Annual Income <span class="text-danger">*</span></label>
                                            <asp:DropDownList ID="DrpAnnualIncome" runat="server" CssClass="form-control" AppendDataBoundItems="true" required="true" AutoPostBack="false" onchange="getcta(this.value)">
                                                <asp:ListItem Text="--SELECT Annual Income--" Value="" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Upto 3,00,000/Year" Value="Upto 3,00,000/Year"></asp:ListItem>
                                                <asp:ListItem Text="3,00,001 to 6,00,000/Year" Value="3,00,001 to 6,00,000/Year"></asp:ListItem>
                                            </asp:DropDownList>
                                            <span class="text-success" id="plot_range2" style="margin-top: 10px; padding-top: 10px; float: left; width: 100%; font-weight: bold; text-transform: capitalize;"></span>
                                            <asp:RequiredFieldValidator ID="rfvAnnualIncome" runat="server"
                                                ControlToValidate="DrpAnnualIncome"
                                                InitialValue="" ErrorMessage="Please select annual income"
                                                CssClass="text-danger" Display="Dynamic" />

                                        </div>

                                        <div class="col-12 text-center" id="hideCheckBox" runat="server">
                                            <input type="checkbox" id="submitCheckBox" data-bs-toggle="modal" runat="server" data-bs-target="#termAndConditionModal">
                                            :- Please accept our terms and conditions to proceed with submitting the form data.

                                        </div>
                                    </div>

                                </div>



                            </div>
                        </div>
                    </div>
                </div>


            </div>

        </asp:Panel>

    </form>
</body>
</html>

