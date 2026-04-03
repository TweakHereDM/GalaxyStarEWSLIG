<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiptList.aspx.cs" Inherits="WebApplication.ReceiptList" %>

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
        th {
            background-color: #f5f5f5;
            text-align: center;
        }

        td, th {
            border: 1px solid;
            text-align:center;
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
<body>
    <form id="form1" runat="server">

        <div class="container-fluid" style="margin-bottom: 100px">
            <nav class="navbar navbar-light bg-light fixed-top ">
                <div class="container">
                    
                    <img src="Images/Eden-Garden-logo.png" style="width:180px; height:auto;">

                </div>
            </nav>
        </div>
        <div class="register-form-container">
            <div class="container">

                <div class="tab-content" id="pills-tabContent">
                    <div class="tab-pane fade show active" id="pills-personal" role="tabpanel" aria-labelledby="pills-personal-details">

                        <div class="row g-4">
                            <div class="col-12 p-0 m-0 mt-1">
                                <p class="text-center bg-secondary text-white py-2">Search Receipt</p>
                            </div>
                            <div class="col-12 col-md-2">
                                <label class="form-label">Mobile No:<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtSearchBy" runat="server" CssClass="form-control"></asp:TextBox>


                            </div>

                           <!-- <div class="col-12 col-md-2">
                                <label class="form-label">Form No:<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtFormNo" runat="server" CssClass="form-control"></asp:TextBox>


                            </div> -->
                            <div class="col-md-1">
                                <br />
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-success" OnClick="btnSearch_Click" />
                            </div>

                            <div class="col-12">
                                <p class="text-center bg-secondary text-white py-2">Receipt List</p>
                            </div>

                            <div class="col-md-12">
                                <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="false" Font-Size="11pt"
                                    DataKeyNames="ID" CssClass="grid" PageSize="100" Width="100%" CellPadding="10">
                                    <Columns>
                                        <asp:BoundField DataField="ApplyFor" HeaderText="Apply For" />
                                        <asp:BoundField DataField="FormID" HeaderText="Form No" />
                                        <asp:BoundField DataField="Category" HeaderText="Category" />

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            HeaderText="Customer Details">
                                            <ItemTemplate>

                                                <b>Customer Name:</b><%#Eval("CustomerName") %>
                                                <br />
                                                <b>Contact:</b>
                                                <%#Eval("Contact") %>
                                                <br />
                                                <b><%#Eval("Relation") %> Name:</b> <%#Eval("RelationName") %>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="180px" HeaderText="Amount Paid">
                                            <ItemTemplate>

                                                <%#Eval("Total_Price") %>
                                            
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="180px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            HeaderText="Payment Date">
                                            <ItemTemplate>

                                                <%# Eval("PaymentDate", "{0:dd/MM/yyyy}") %>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="180px" HeaderText="Receipt">
                                            <ItemTemplate>
                                                <a href='ReceiptDownload.aspx?ref=<%#Eval("FormID") %>'>Receipt</a>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="180px"></ItemStyle>
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
