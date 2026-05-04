<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Website.Master" AutoEventWireup="true" CodeBehind="AddDD.aspx.cs" Inherits="WebApplication.AddDD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/font-awesome_all.min.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">

                        <h4>Receive DD:</h4>
                    </div>

                    <div class="col-md-12" style="padding-top: 10px;">
                        <div class="col-md-12">
                            <div class="col-md-12 pb-4">
                                <div class="col-md-6">
                                    ApplyFor:
                                    <asp:Label ID="lblApplyFor" Font-Bold="true" Font-Size="16px" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-6 ">
                                    Category:
                                    <asp:Label ID="lblCategory" Font-Bold="true" Font-Size="16px" runat="server"></asp:Label>

                                </div>
                            </div>
                            <div class="col-md-12 pb-4">
                                <div class="col-md-6 ">
                                    CustomerName:
                                <asp:Label ID="lblName" Font-Bold="true" Font-Size="16px" runat="server"></asp:Label>
                                </div>

                                <div class="col-md-6">
                                    Contact:
                                        <asp:Label ID="lblContact" Font-Bold="true" Font-Size="16px" runat="server"></asp:Label>
                                </div>

                            </div>
                            <!-- <div class="col-md-3">
                                Account Holder Name
                                <asp:TextBox ID="txtAccountHolderName" runat="server" CssClass="form-control" placeholder="Account Holder Name"> </asp:TextBox>
                            </div>-->
                            <div class="col-md-3">
                                Bank Name
                                <asp:DropDownList ID="DrpBankName" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="SELECT Bank" Value="" Selected="True" />
                                    <asp:ListItem Text="Andhra Bank" Value="Andhra Bank" />
                                    <asp:ListItem Text="Allahabad Bank" Value="Allahabad Bank" />
                                    <asp:ListItem Text="BANK OF BARODA" Value="BANK OF BARODA" />
                                    <asp:ListItem Text="Bank of India" Value="Bank of India" />
                                    <asp:ListItem Text="BANK OF MAHARASHTRA" Value="BANK OF MAHARASHTRA" />
                                    <asp:ListItem Text="Bandhan Bank Ltd." Value="Bandhan Bank Ltd." />
                                    <asp:ListItem Text="Bank of Rajsthan" Value="Bank of Rajsthan" />
                                    <asp:ListItem Text="CITY UNION BANK LTD" Value="CITY UNION BANK LTD" />
                                    <asp:ListItem Text="Central Bank of India" Value="Central Bank of India" />
                                    <asp:ListItem Text="CORPORATION BANK" Value="CORPORATION BANK" />
									<asp:ListItem Text="CSB BANK" Value="CSB BANK" />
                                    <asp:ListItem Text="Dena Bank" Value="Dena Bank" />
                                    <asp:ListItem Text="Equitas" Value="Equitas" />
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
                                    <asp:ListItem Text="Karur Vysya Bank" Value="Karur Vysya Bank" />
                                    <asp:ListItem Text="Malviya Urban Co-Operative Bank Ltd" Value="Malviya Urban Co-Operative Bank Ltd" />
                                    <asp:ListItem Text="ORIENTAL BANK OF COMMERCE" Value="ORIENTAL BANK OF COMMERCE" />
                                    <asp:ListItem Text="PUNJAB NATIONAL BANK" Value="PUNJAB NATIONAL BANK" />
									<asp:ListItem Text="PUNJAB & SIND BANK" Value="PUNJAB & SIND BANK" />
                                    <asp:ListItem Text="RBL BANK" Value="RBL BANK" />
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
                                    <asp:ListItem Text="The Rajasthan State Co-Operative Bank Ltd" Value="The Rajasthan State Co-Operative Bank Ltd" />
                                    <asp:ListItem Text="federal bank" Value="federal bank" />
                                    <asp:ListItem Text="Ujjivan Small Finance Bank" Value="Ujjivan Small Finance Bank" />
                                    <asp:ListItem Text="Yes Bank" Value="Yes Bank" />
                                </asp:DropDownList>


                            </div>

                            <!-- <div class="col-md-3">
                                Bank Account Number
                                <asp:TextBox ID="txtBankAccountNum" runat="server" CssClass="form-control" placeholder="Bank Account Number"> </asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                IFSC Code
                                <asp:TextBox ID="txtIFSCCode" runat="server" CssClass="form-control" placeholder="IFSC Code"> </asp:TextBox>
                            </div>
                            <div class="col-md-3 pt-3">
                                Bank Address
     <asp:TextBox ID="txtBankAddress" runat="server" CssClass="form-control" placeholder="Bank Address"> </asp:TextBox>
                            </div>-->
                            <div class="col-md-3">
                                DD Amount
                                <asp:TextBox ID="txtDDAmount" runat="server" CssClass="form-control" placeholder="DD Amount"> </asp:TextBox>
                            </div>

                            <div class="col-md-2">
                                DD Number
                                <asp:TextBox ID="txtDDNumber" runat="server" CssClass="form-control" placeholder="DD Number"> </asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                Relation
    <asp:DropDownList ID="drpRelation" runat="server" CssClass="form-control">
        <asp:ListItem Value="Self" />
        <asp:ListItem Value="Father" />
        <asp:ListItem Value="Mother" />
        <asp:ListItem Value="Brother" />
        <asp:ListItem Value="Sister" />
        <asp:ListItem Value="Son" />
        <asp:ListItem Value="Daughter" />
        <asp:ListItem Value="In-Laws" />
    </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                Depositor Name
    <asp:TextBox ID="txtDDDepositor" runat="server" CssClass="form-control" placeholder="Depositor Name"> </asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                Select ID
    <asp:RadioButtonList ID="rdoDepositorID" runat="server" RepeatDirection="Horizontal" CssClass="form-check form-check-inline form-control">
        <asp:ListItem Text="Pan" Value="Pan" />
        <asp:ListItem Text="Driving License" Value="Driving License" />
        <asp:ListItem Text="Voter ID" Value="Voter ID" />
        <asp:ListItem Text="Rashan Card" Value="Rashan Card" />
        <asp:ListItem Text="Adhar Card" Value="Adhar Card" />
    </asp:RadioButtonList>
                            </div>
                            <div class="col-md-2">
                                ID No
    <asp:TextBox ID="txtDDDepositorIDNo" runat="server" CssClass="form-control" placeholder="ID No"> </asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <br />
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success" Text="Update" OnClick="LinkButton1_Click"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-danger" Text="Print" OnClick="LinkButton2_Click"></asp:LinkButton>
                                <asp:Label ID="lblFormID" runat="server" Visible="false"></asp:Label>

                            </div>

                        </div>
                        <br />
                    </div>
                    <br />
                </div>
                <!--<div class="card">
                    <div class="card-header">

                        <h4>Return DD:</h4>
                    </div>

                    <div class="col-md-12" style="padding-top: 10px;">
                        <div class="col-md-12">

                            <div class="col-md-3">
                                DD Collector Name
                           <asp:TextBox ID="txtReturnName" runat="server" CssClass="form-control" placeholder="Collector Name"> </asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                Select ID
                                <asp:RadioButtonList ID="idTypeRadioList" runat="server" RepeatDirection="Horizontal" CssClass="form-check form-check-inline form-control">
                                    <asp:ListItem Text="Pan" Value="Pan" />
                                    <asp:ListItem Text="Driving License" Value="Driving License" />
                                    <asp:ListItem Text="Voter ID" Value="Voter ID" />
                                    <asp:ListItem Text="Rashan Card" Value="Rashan Card" />
                                    <asp:ListItem Text="Adhar Card" Value="Adhar Card" />
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-md-3">
                                ID No
                                <asp:TextBox ID="txtIDNo" runat="server" CssClass="form-control" placeholder="ID No"> </asp:TextBox>
                            </div>



                            <div class="col-md-3">
                                <br />
                                <asp:LinkButton ID="lnkDDReturn" runat="server" CssClass="btn btn-success" Text="Save" OnClick="lnkDDReturn_Click"></asp:LinkButton>
                                <asp:LinkButton ID="lnkDDReturnPrint" runat="server" CssClass="btn btn-danger" Text="Print" OnClick="lnkDDReturnPrint_Click"></asp:LinkButton>


                            </div>

                        </div>
                        <br />
                    </div>
                    <br />
                </div> -->
            </div>
        </div>
    </section>
</asp:Content>
