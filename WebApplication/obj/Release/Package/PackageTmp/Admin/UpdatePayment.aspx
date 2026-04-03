<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Website.Master" AutoEventWireup="true" CodeBehind="UpdatePayment.aspx.cs" Inherits="WebApplication.Admin.UpdatePayment" %>

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

                        <h4>Update Payment:</h4>
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
                            Total Price
                            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" placeholder="Total Price"> </asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            Received Amount
                            <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" placeholder="Amount Received"> </asp:TextBox>
                        </div>

                        <div class="col-md-3">
                            <br /><asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success" Text="Update" OnClick="LinkButton1_Click"></asp:LinkButton>
                        </div>
                    </div>
                    <br />
                </div>
            </div>
        </div>
        </div>
    </section>
</asp:Content>
