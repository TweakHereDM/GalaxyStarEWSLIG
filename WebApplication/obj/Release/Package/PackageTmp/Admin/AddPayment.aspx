<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Website.Master" AutoEventWireup="true" CodeBehind="AddPayment.aspx.cs" Inherits="WebApplication.Admin.AddPayment" %>

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

                        <h4>Add Payment:</h4>
                    </div>

                    <div class="col-md-12" style="padding-top: 10px;">
                        <div class="col-md-12">
                            <div class="col-md-12 pb-3">
                                <div class="col-md-3">
                                    Order ID:
                                 <asp:Literal ID="ltrOrderID" runat="server"></asp:Literal>
                                 <asp:Literal ID="ltrFormID" Visible="false" runat="server"></asp:Literal>
                                    <!--<asp:Literal ID="ltrRegID"  runat="server"></asp:Literal>-->

                                </div>
                                <div class="col-md-2">
                                    ApplyFor:
                                 <asp:Label ID="lblApplyFor" Font-Bold="true" Font-Size="16px" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-5">
                                    Category:
                                    <asp:Label ID="lblCategory" Font-Bold="true" Font-Size="16px" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12 pb-3">
                                <div class="col-md-6">
                                    CustomerName:
                                    <asp:Label ID="lblName" Font-Bold="true" Font-Size="16px" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    Contact:
                                    <asp:Label ID="lblContact" Font-Bold="true" Font-Size="16px" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <!-- <div class="col-md-3">
                                     Relation Name:
                                     <asp:Literal ID="ltrRelationName" runat="server"></asp:Literal>
                                 </div>-->
                        <div class="col-md-3">

                            <select id="DrpBankName" runat="server" class="form-control ">
                                <option value="" selected="selected">SELECT Bank</option>
                                <option value="Cash">Cash</option>
                                <option value="Andhra Bank">Andhra Bank</option>
                                <option value="Allahabad Bank">Allahabad Bank</option>
                                <option value="BANK OF BARODA">BANK OF BARODA</option>
                                <option value="Bank of India">Bank of India</option>
                                <option value="BANK OF MAHARASHTRA">BANK OF MAHARASHTRA</option>
                                <option value="Bandhan Bank Ltd.">Bandhan Bank Ltd.</option>
                                <option value="Bank of Rajsthan">Bank of Rajsthan</option>
                                <option value="Central Bank of India">Central Bank of India</option>
                                <option value="CORPORATION BANK">CORPORATION BANK</option>
                                <option value="Dena Bank">Dena Bank</option>
                                <option value="HDFC BANK">HDFC BANK</option>
                                <option value="ICICI BANK LTD">ICICI BANK LTD</option>
                                <option value="IDBI BANK">IDBI BANK</option>
                                <option value="Industrial Co-op Bank Ltd">Industrial Co-op Bank Ltd</option>
                                <option value="India Post Payments Bank Ltd">India Post Payments Bank Ltd</option>
                                <option value="INDIAN BANK">INDIAN BANK</option>
                                <option value="INDIAN OVERSEAS BANK">INDIAN OVERSEAS BANK</option>
                                <option value="Idfc Bank Ltd">Idfc Bank Ltd</option>
                                <option value="IndusInd Bank">IndusInd Bank</option>
                                <option value="Kotak Mahindra Bank Ltd">Kotak Mahindra Bank Ltd</option>
                                <option value="ORIENTAL BANK OF COMMERCE">ORIENTAL BANK OF COMMERCE</option>
                                <option value="PUNJAB NATIONAL BANK">PUNJAB NATIONAL BANK</option>
                                <option value="Standard Chartered Bank">Standard Chartered Bank</option>
                                <option value="STATE BANK OF BIKANER AND JAIPUR">STATE BANK OF BIKANER AND JAIPUR</option>
                                <option value="STATE BANK OF INDIA">STATE BANK OF INDIA</option>
                                <option value="STATE BANK OF PATIALA">STATE BANK OF PATIALA</option>
                                <option value="UCO BANK">UCO BANK</option>
                                <option value="UNION BANK OF INDIA">UNION BANK OF INDIA</option>
                                <option value="UNITED BANK OF INDIA">UNITED BANK OF INDIA</option>
                                <option value="VIJAYA BANK">VIJAYA BANK</option>
                                <option value=" Axis Bank">Axis Bank</option>
                                <option value="SYNDICATE BANK ">SYNDICATE BANK </option>
                                <option value="CANARA BANK">CANARA BANK</option>
                                <option value="baroda rajasthan kshetriya gramin bank">baroda rajasthan kshetriya gramin bank</option>
                                <option value="AU Small Finance Bank">AU Small Finance Bank</option>
                                <option value="Karnataka Bank Ltd.">Karnataka Bank Ltd.</option>
                                <option value="FINGROWTH CO-OPERATIVE BANK ">FINGROWTH CO-OPERATIVE BANK </option>
                                <option value="Rajasthan Marudhara Gramin Bank">Rajasthan Marudhara Gramin Bank</option>
                                <option value="Jaipur Nagaur Anchalik Gramin Bank">Jaipur Nagaur Anchalik Gramin Bank</option>
                                <option value="The Jaipur Central Co Operative Bank">The Jaipur Central Co Operative Bank</option>
                                <option value=""></option>
                                <option value="federal bank">federal bank</option>
                                <option value="Ujjivan Small Finance Bank ">Ujjivan Small Finance Bank </option>
                            </select>
                            <span class="text-danger" id="bank_name"></span>

                        </div>



                        <div class="col-md-3">
                            <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" placeholder="Amount Received"> </asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txttxnID" runat="server" CssClass="form-control" placeholder="Transaction ID"> </asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success" Text="Add Payment" OnClick="LinkButton1_Click"></asp:LinkButton>
                        </div>
                    </div>
                    <br />
                </div>
            </div>
        </div>
        </div>
    </section>
</asp:Content>
