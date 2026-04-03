<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apply.aspx.cs" Inherits="WebApplication.Apply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title style="text-transform: uppercase;">Urban Village </title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/font-awesome_all.min.css" />
    <link rel="stylesheet" href="css/style.css" />

    <link rel="stylesheet" href="../cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <style>
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


    <script type="text/javascript">
        function printDiv() {
            var printContents = document.getElementById("printableArea").innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
            location.reload();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <%-- <% if (BusinessLogicLayer.WebsiteSession.UserID>0)
                    { %>--%>
        <div class="container-fluid" style="margin-bottom: 100px">
            <nav class="navbar navbar-light bg-light fixed-top ">
                <div class="container">
                    <img src="Images/Eden-Garden-logo.png" style="width: 180px; height: auto;">
                </div>
            </nav>
        </div>
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


                    <div class="modal fade" data-bs-backdrop="static" data-bs-keyboard="false" id="termAndConditionModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog modal-dialog-centered">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel">Term and Condition</h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-12 py-2" style="border: 1px solid #555;">
                                            <iframe class="doc" src="Documents/EWS_Book_Galaxy_Enclave.pdf" width="100%" style="height: 400px;">docs</iframe>
                                        </div>
                                        <div class="col-12 mt-2">
                                            <input type="checkbox">
                                            I declare that I have read,
                                       understood and accepted the information on the processing of my personal
                                       data.
                                  
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-sm btn-secondary" data-bs-dismiss="modal">Cancel</button>
                                    <asp:Button ID="btnSav" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSav_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <%-- <% }   %>
         <% if (BusinessLogicLayer.WebsiteSession.UserID==0)
             { %>
        <h5 style="padding:10px; text-align:center">We are facing some technical issue, it will be solved by tomorrow by 11 AM, Please visit again after 11 AM</h5>
        <% }   %>--%>
        <script src="css/bootstrap.bundle.min.js"></script>
        <script src="css/jquery.min.js"></script>
        <script>
            $(document).ready(function () {
                $('#checkboxForm').click(function () {
                    if ($('#checkboxForm').is(':checked')) {
                        $('#registerBtn').show()
                    } else {
                        $('#registerBtn').hide()
                    }
                });

                $("#termAndConditionModal [type=checkbox]").click(lock);
                function lock() {
                    var flag = $("#termAndConditionModal [type=checkbox]").prop('checked');
                    if (!flag) {
                        $("#termAndConditionModal .btn-primary").attr("disabled", "disabled");
                    } else {
                        $("#termAndConditionModal .btn-primary").removeAttr("disabled");
                    }
                }
            });
        </script>
        <script src="css/script.js"></script>




        <script>
            $(document).ready(function () {
                $('#mobile_number_input').on('input', function () {
                    var mobile_number = $(this).val();

                    // AJAX request to check the mobile number
                    $.ajax({
                        url: 'check_mobile.php',
                        type: 'POST',
                        dataType: 'json', // Ensure response is treated as JSON
                        data: { mobile_number: mobile_number },
                        success: function (response) {

                            //alert(response.response);

                            if (response.response == 'exists') {
                                $('#mobile_number_error').text('This mobile number is already registered. Please use a different number.');

                                $("#mobile_number_input").val(' ');



                            } else {
                                $('#mobile_number_error').text('');
                            }
                        }
                    });
                });
            });



            $(document).ready(function () {
                $('#aadhar_number').on('input', function () {
                    var aadhar_number = $(this).val();

                    // AJAX request to check the mobile number
                    $.ajax({
                        url: 'check_mobile.php',
                        type: 'POST',
                        dataType: 'json', // Ensure response is treated as JSON
                        data: { aadhar_number: aadhar_number },
                        success: function (response) {

                            //alert(response.response);

                            if (response.response == 'exists') {
                                $('#aadhar_number_error').text('This Aadhar Number  is already registered. Please use a different Aadhar number.');

                                $("#aadhar_number").val(' ');



                            } else {
                                $('#aadhar_number_error').text('');
                            }
                        }
                    });
                });
            });









            function getcta(id) {
                $("#plot_range2").html('');
                if (id == 'EWS') {
                    $("#plot_range2").html('you are filling form in EWS');

                }
                if (id == 'LIG') {
                    $("#plot_range2").html('you are filling form on LIG ');
                }

            }
        </script>








        <script>
            $(document).ready(function () {
                /*$("#mobile_number_input").on("input", function () {
                    let mobile = $(this).val();
                    if (mobile.length === 10) {
                        // Send OTP via AJAX
                        $.ajax({
                            url: "send_otp.php",
                            type: "POST",
                            data: { mobile_number: mobile },
                            success: function (response) {
                                let res = JSON.parse(response);
                                if (res.success) {
                                    alert("OTP sent to your mobile number.");
                                    $("#otpModal").modal("show");
                                } else {
                                    $("#mobile_number_error").text(res.message);
                                }
                            }
                        });
                    }
                });*/

                $("#verify_otp").on("click", function () {
                    let mobile = $("#mobile_number_input").val();
                    let otp = $("#otp").val();

                    if (otp === "") {
                        $("#otp_error").text("Please enter the OTP.");
                        return;
                    }


                    $.ajax({
                        url: "verify_otp.php",
                        type: "POST",
                        data: { mobile_number: mobile, otp: otp },
                        success: function (response) {
                            let res = JSON.parse(response);
                            if (res.success) {
                                alert("OTP Verified Successfully!");
                                $("#mobile_number_input").prop("readonly", true);
                                $("#otpModal").modal("hide");



                            } else {
                                $("#otp_error").text(res.message);
                            }
                        }
                    });
                });
            });
        </script>



        <script>
            $(document).ready(function () {
                // Initialize modal with options to prevent closing on background click
                $('#otpModal').modal({
                    backdrop: 'static',  // Prevent closing when clicking outside
                    keyboard: false      // Prevent closing with the ESC key
                });
            });


            $(document).ready(function () {
                $(".close").click(function () {
                    $("#otpModal").modal("hide");
                    //alert("sadsadsa");

                    $("#mobile_number_input").val('');



                });
            });
        </script>



    </form>
</body>
</html>
