<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Website.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="WebApplication.AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function onlyNumberKey(evt) {

            // Only ASCII character in that range allowed
            var ASCIICode = (evt.which) ? evt.which : evt.keyCode
            if (ASCIICode > 31 && (ASCIICode < 48 || ASCIICode > 57))
                return false;
            return true;
        }
    </script>
    <style>
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

        .bg-secondary {
            background-color: none !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <section class="section">
        <div class="section-body">
            <div class="row">
                <div class="col-12 col-md-12 col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>Single Contact</h4>
                            <asp:ValidationSummary ID="vs1" runat="server" ValidationGroup="VG" ShowSummary="false" CssClass="alertSummary" ForeColor="Red"
                                HeaderText="" />
                            <!-- <asp:Literal ID="ltrID" runat="server"></asp:Literal>-->
                        </div>

                        <div class="card-body">

                            <div class="row g-4">
                                <asp:Literal ID="litOrderID" Visible="false" runat="server"></asp:Literal>
                                 <asp:Literal ID="ltrUserID" Visible="false" runat="server"></asp:Literal>

                                <div class="col-12 col-md-2">
                                    <label class="form-label">Apply For <span class="text-danger">*</span></label>

                                    <asp:DropDownList ID="DrpApplyFor" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Apply For--" Value="" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="EWS (500/-)" Value="EWS"></asp:ListItem>
                                        <asp:ListItem Text="LIG (1000/-)" Value="LIG"></asp:ListItem>
                                    </asp:DropDownList>


                                    <asp:RequiredFieldValidator
                                        ID="rfvApplyFor"
                                        runat="server"
                                        ControlToValidate="DrpApplyFor"
                                        InitialValue=""
                                        ErrorMessage="Please select an option for Apply For"
                                        CssClass="text-danger"
                                        Display="Dynamic"
                                        ValidationGroup="VG" />

                                </div>

                                <div class="col-12 col-md-6 col-lg-3">

                                    <label class="form-label">Application Holder Name <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" required="true"
                                        ControlToValidate="txtName"
                                        ErrorMessage="Name is required"
                                        ValidationGroup="VG"
                                        CssClass="text-danger" Display="Dynamic" />

                                </div>
                                <div class="col-12 col-md-6 col-lg-3">
                                    <label class="form-label">Gender <span class="text-danger">*</span></label>
                                    <br>
                                    <div class="div pt-2">
                                        <asp:RadioButtonList ID="inpGender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Text="Male" Value="Male" />
                                            <asp:ListItem Text="Female" Value="Female" />
                                        </asp:RadioButtonList>

                                        <asp:RequiredFieldValidator ID="rfvGender" runat="server"
                                            ControlToValidate="inpGender"
                                            InitialValue=""
                                            ErrorMessage="Please select your gender"
                                            ValidationGroup="VG"
                                            CssClass="text-danger" Display="Dynamic" />
                                    </div>
                                </div>
                                <div class="col-12 col-md-6 col-lg-3">
                                    <label class="form-label">Date Of Birth <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtDob" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvDob" runat="server"
                                        ControlToValidate="txtDob"
                                        ErrorMessage="Date of Birth is required"
                                        ValidationGroup="VG"
                                        CssClass="text-danger" Display="Dynamic" />

                                </div>
                                <div class="col-12 col-md-6 col-lg-3">
                                    <label class="form-label">Email Address <span class="text-danger">*</span></label>

                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                                        ControlToValidate="txtEmail"
                                        ErrorMessage="Email is required"
                                        ValidationGroup="VG"
                                        CssClass="text-danger" Display="Dynamic" />

                                </div>
                                <div class="col-12 col-md-6 col-lg-3">
                                    <label class="form-label">Select One <span class="text-danger">*</span></label>
                                    <br>
                                    <div class="div pt-2">
                                        <asp:RadioButtonList ID="inpRelation" runat="server" RepeatDirection="Horizontal" CssClass="form-check form-check-inline">
                                            <asp:ListItem Text="Father" Value="Father" />
                                            <asp:ListItem Text="Husband" Value="Husband" />
                                        </asp:RadioButtonList>

                                        <!-- RequiredFieldValidator for RadioButtonList -->
                                        <asp:RequiredFieldValidator ID="rfvRelation" runat="server"
                                            ControlToValidate="inpRelation"
                                            InitialValue=""
                                            ErrorMessage="Please select Father or Husband"
                                            ValidationGroup="VG"
                                            CssClass="text-danger" Display="Dynamic" />
                                    </div>
                                </div>
                                <div class="col-12 col-md-6 col-lg-3">
                                    <label class="form-label">Father/Husband Name <span class="text-danger">*</span></label>

                                    <asp:TextBox ID="txtRelationName" runat="server" CssClass="form-control"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvRelationName" runat="server"
                                        ControlToValidate="txtRelationName"
                                        ErrorMessage="Name is required"
                                        ValidationGroup="VG"
                                        CssClass="text-danger" Display="Dynamic" />

                                </div>
                                <div class="col-12 col-md-6 col-lg-3">
                                    <label class="form-label">Mobile Number <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" TextMode="Number" MaxLength="10"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvMobile" runat="server"
                                        ControlToValidate="txtContact"
                                        ErrorMessage="Mobile Number is required"
                                        ValidationGroup="VG"
                                        CssClass="text-danger" Display="Dynamic" />

                                    <asp:RegularExpressionValidator ID="revMobile" runat="server" ControlToValidate="txtContact" ValidationGroup="VG" ErrorMessage="valid Mobile Number" ValidationExpression="^\d{10}$" CssClass="text-danger" Display="Dynamic" />


                                </div>
                                <div class="col-12 col-md-6 col-lg-6">
                                    <label class="form-label">Select One <span class="text-danger">*</span></label>
                                    <br>
                                    <div class="pt-2">
                                        <asp:RadioButtonList ID="idTypeRadioList" runat="server" RepeatDirection="Horizontal" CssClass="form-check form-check-inline">
                                            <asp:ListItem Text="Pan" Value="Pan" />
                                            <asp:ListItem Text="Driving License" Value="Driving License" />
                                            <asp:ListItem Text="Voter ID" Value="Voter ID" />
                                            <asp:ListItem Text="Rashan Card" Value="Rashan Card" />
                                        </asp:RadioButtonList>

                                        <asp:RequiredFieldValidator ID="rfvIdType" runat="server"
                                            ControlToValidate="idTypeRadioList"
                                            ErrorMessage="Please select an ID type"
                                            ValidationGroup="VG"
                                            CssClass="text-danger" Display="Dynamic"
                                            InitialValue="" />
                                    </div>
                                </div>
                                <div class="col-12 col-md-6 col-lg-3">
                                    <label class="form-label">ID No <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtidValues" runat="server" CssClass="form-control"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvIdNo" runat="server"
                                        ControlToValidate="txtidValues"
                                        ErrorMessage="ID number is required"
                                        ValidationGroup="VG"
                                        CssClass="text-danger" Display="Dynamic" />

                                </div>
                                <div class="col-12 col-md-6 col-lg-3">
                                    <label class="form-label">Aadhar Number <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtAadharNumber" runat="server" CssClass="form-control" TextMode="Number" MaxLength="12"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvAadhar" runat="server"
                                        ControlToValidate="txtAadharNumber"
                                        ErrorMessage="Aadhar Number is required"
                                        CssClass="text-danger" Display="Dynamic" />

                                    <asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator1"
                                        runat="server"
                                        ControlToValidate="txtAadharNumber"
                                        ErrorMessage="valid Aadhar Number"
                                        ValidationGroup="VG"
                                        ValidationExpression="^\d{12}$"
                                        CssClass="text-danger"
                                        Display="Dynamic" />


                                </div>

                                <div class="col-12 col-md-6 col-lg-3">
                                    <label class="form-label">Pin Code <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtPinCode" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvZip" runat="server"
                                        ControlToValidate="txtPinCode"
                                        ErrorMessage="Zip Code is required"
                                        ValidationGroup="VG"
                                        CssClass="text-danger" Display="Dynamic" />

                                </div>
                                <div class="col-12 col-md-6 col-lg-3">
                                    <label class="form-label">City <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvCity" runat="server"
                                        ControlToValidate="txtCity"
                                        ErrorMessage="City is required"
                                        ValidationGroup="VG"
                                        CssClass="text-danger" Display="Dynamic" />

                                </div>
                                <div class="col-12 col-md-6 col-lg-3">
                                    <label class="form-label">State <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtState" runat="server" CssClass="form-control" Text="Rajasthan" ReadOnly="true"></asp:TextBox>

                                </div>
                                <div class="col-12 col-md-6 col-lg-3">
                                    <label class="form-label">Country <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control" Text="India" ReadOnly="true"></asp:TextBox>

                                </div>
                                <div class="col-12">
                                    <label class="form-label">Permanent Address <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtAddress" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server"
                                        ControlToValidate="txtAddress"
                                        ErrorMessage="Address is required"
                                        ValidationGroup="VG"
                                        CssClass="text-danger" Display="Dynamic" />
                                </div>


                                <div class="col-12 mt-3">
                                    <p class="text-center text-white py-2" style="background-color: #69757d !important">DD Details</p>
                                </div>


                                <div class="col-md-3">
                                    Bank Name
                           <asp:DropDownList ID="drpBankName" runat="server" CssClass="form-control">
                               <asp:ListItem Text="SELECT Bank" Value="" Selected="True" />
                               <asp:ListItem Text="Andhra Bank" Value="Andhra Bank" />
                               <asp:ListItem Text="Allahabad Bank" Value="Allahabad Bank" />
                               <asp:ListItem Text="BANK OF BARODA" Value="BANK OF BARODA" />
                               <asp:ListItem Text="Bank of India" Value="Bank of India" />
                               <asp:ListItem Text="BANK OF MAHARASHTRA" Value="BANK OF MAHARASHTRA" />
                               <asp:ListItem Text="Bandhan Bank Ltd." Value="Bandhan Bank Ltd." />
                               <asp:ListItem Text="Bank of Rajsthan" Value="Bank of Rajsthan" />
                               <asp:ListItem Text="Central Bank of India" Value="Central Bank of India" />
                               <asp:ListItem Text="CORPORATION BANK" Value="CORPORATION BANK" />
                               <asp:ListItem Text="Dena Bank" Value="Dena Bank" />
                               <asp:ListItem Text="HDFC BANK" Value="HDFC BANK" />
                               <asp:ListItem Text="ICICI BANK LTD" Value="ICICI BANK LTD" />
                               <asp:ListItem Text="IDBI BANK" Value="IDBI BANK" />
                               <asp:ListItem Text="Industrial Co-op Bank Ltd" Value="Industrial Co-op Bank Ltd" />
                               <asp:ListItem Text="India Post Payments Bank Ltd" Value="India Post Payments Bank Ltd" />
                               <asp:ListItem Text="INDIAN BANK" Value="INDIAN BANK" />
                               <asp:ListItem Text="INDIAN OVERSEAS BANK" Value="INDIAN OVERSEAS BANK" />
                               <asp:ListItem Text="Idfc Bank Ltd" Value="Idfc Bank Ltd" />
                               <asp:ListItem Text="IndusInd Bank" Value="IndusInd Bank" />
                               <asp:ListItem Text="Kotak Mahindra Bank Ltd" Value="Kotak Mahindra Bank Ltd" />
                               <asp:ListItem Text="ORIENTAL BANK OF COMMERCE" Value="ORIENTAL BANK OF COMMERCE" />
                               <asp:ListItem Text="PUNJAB NATIONAL BANK" Value="PUNJAB NATIONAL BANK" />
                               <asp:ListItem Text="Standard Chartered Bank" Value="Standard Chartered Bank" />
                               <asp:ListItem Text="STATE BANK OF BIKANER AND JAIPUR" Value="STATE BANK OF BIKANER AND JAIPUR" />
                               <asp:ListItem Text="STATE BANK OF INDIA" Value="STATE BANK OF INDIA" />
                               <asp:ListItem Text="STATE BANK OF PATIALA" Value="STATE BANK OF PATIALA" />
                               <asp:ListItem Text="UCO BANK" Value="UCO BANK" />
                               <asp:ListItem Text="UNION BANK OF INDIA" Value="UNION BANK OF INDIA" />
                               <asp:ListItem Text="UNITED BANK OF INDIA" Value="UNITED BANK OF INDIA" />
                               <asp:ListItem Text="VIJAYA BANK" Value="VIJAYA BANK" />
                               <asp:ListItem Text="Axis Bank" Value="Axis Bank" />
                               <asp:ListItem Text="SYNDICATE BANK" Value="SYNDICATE BANK" />
                               <asp:ListItem Text="CANARA BANK" Value="CANARA BANK" />
                               <asp:ListItem Text="baroda rajasthan kshetriya gramin bank" Value="baroda rajasthan kshetriya gramin bank" />
                               <asp:ListItem Text="AU Small Finance Bank" Value="AU Small Finance Bank" />
                               <asp:ListItem Text="Karnataka Bank Ltd." Value="Karnataka Bank Ltd." />
                               <asp:ListItem Text="FINGROWTH CO-OPERATIVE BANK" Value="FINGROWTH CO-OPERATIVE BANK" />
                               <asp:ListItem Text="Rajasthan Marudhara Gramin Bank" Value="Rajasthan Marudhara Gramin Bank" />
                               <asp:ListItem Text="Jaipur Nagaur Anchalik Gramin Bank" Value="Jaipur Nagaur Anchalik Gramin Bank" />
                               <asp:ListItem Text="The Jaipur Central Co Operative Bank" Value="The Jaipur Central Co Operative Bank" />
                               <asp:ListItem Text="federal bank" Value="federal bank" />
                               <asp:ListItem Text="Ujjivan Small Finance Bank" Value="Ujjivan Small Finance Bank" />
                           </asp:DropDownList>


                                </div>

                                <!--<div class="col-md-3">
                                    Bank Account Number
                           <asp:TextBox ID="txtBankAccountNum" runat="server" CssClass="form-control" placeholder="Bank Account Number"> </asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    IFSC Code
                           <asp:TextBox ID="txtIFSCCode" runat="server" CssClass="form-control" placeholder="IFSC Code"> </asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    Bank Address
                                    <asp:TextBox ID="txtBankAddress" runat="server" CssClass="form-control" placeholder="Bank Address"> </asp:TextBox>
                                </div> -->
                                <div class="col-md-3">
                                    DD Amount
                           <asp:TextBox ID="txtDDAmount" runat="server" CssClass="form-control" placeholder="DD Amount"> </asp:TextBox>
                                </div>

                                <div class="col-md-3">
                                    DD Number
                           <asp:TextBox ID="txtDDNumber" runat="server" CssClass="form-control" placeholder="DD Number"> </asp:TextBox>
                                </div>





                                <div class="col-12 mt-3">
                                    <p class="text-center text-white py-2" style="background-color: #69757d !important">Fill Income Details</p>
                                </div>

                                <div class="col-12 col-md-6">
                                    <label class="form-label">Category <span class="text-danger">*</span></label>

                                    <asp:DropDownList ID="DrpCategory" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                        
                                    </asp:DropDownList>

                                    <asp:RequiredFieldValidator ID="rfvCategory" runat="server"
                                        ControlToValidate="DrpCategory"
                                        InitialValue="" ErrorMessage="Please select a category"
                                        ValidationGroup="VG"
                                        CssClass="text-danger" Display="Dynamic" />

                                </div>
                                <div class="col-12 col-md-6">
                                    <label class="form-label">Annual Income <span class="text-danger">*</span></label>
                                    <asp:DropDownList ID="DrpAnnualIncome" runat="server" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="false" onchange="getcta(this.value)">
                                        <asp:ListItem Text="--SELECT Annual Income--" Value="" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Upto 3,00,000/Year" Value="Upto 3,00,000/Year"></asp:ListItem>
                                        <asp:ListItem Text="3,00,001 to 6,00,000/Year" Value="3,00,001 to 6,00,000/Year"></asp:ListItem>
                                    </asp:DropDownList>
                                    <span class="text-success" id="plot_range2" style="margin-top: 10px; padding-top: 10px; float: left; width: 100%; font-weight: bold; text-transform: capitalize;"></span>
                                    <asp:RequiredFieldValidator ID="rfvAnnualIncome" runat="server"
                                        ControlToValidate="DrpAnnualIncome"
                                        InitialValue="" ErrorMessage="Please select annual income"
                                        ValidationGroup="VG"
                                        CssClass="text-danger" Display="Dynamic" />

                                </div>

                                <div class="col-12 text-center" id="hideCheckBox" runat="server">

                                    <div class="col-md-6">

                                        <asp:CheckBox ID="chkRegFees" runat="server" />
                                        Tick if Registration Fees Received.
                                    </div>

                                </div>

                            </div>

                        </div>

                        <div class="card-footer text-center">
                            <asp:Button ID="Submit" CssClass="btn btn-primary mr-1" runat="server" Text="Save" ValidationGroup="VG" OnClick="Submit_Click" />

                        </div>
                    </div>

                </div>
                <%--<div class="col-12 col-md-6 col-lg-6">
                    <div class="card">
                        <div class="card-header">
                            <h4>Upload Bulk Contact</h4>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="VGBulk" CssClass="alertSummary" ForeColor="Red"
                                HeaderText="" />
                            <a href="/assets/SKbuilders.xls" class="btn btn-danger">Download Sample</a>
                          
                        </div>

                        <div class="card-body">
                            <div class="form-group">
                                  <label>Select Excel Sheet</label>
                                <asp:FileUpload ID="fupload" runat="server" accept=".xlsx, .xls" ToolTip="Upload Excel Sheet" CssClass="form-control" />

                            </div>
                            
                        </div>

                        <div class="card-footer text-right">
                            <asp:Button ID="btnBulk" CssClass="btn btn-primary mr-1" runat="server" Text="Save Bulk" ValidationGroup="VGBulk" OnClick="btnBulk_Click" />


                        </div>
                    </div>

                </div>--%>
            </div>
        </div>
    </section>
</asp:Content>
