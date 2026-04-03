<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Website.Master" AutoEventWireup="true" CodeBehind="RegisterList.aspx.cs" Inherits="WebApplication.Admin.RegisterList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        th, td {
            text-align: center !important;
            padding: 10px !important;
            width: 12%;
        }

        th {
            background-color: #f5f5f5;
        }

        .minwidth120 {
            min-width: 250px;
            word-break: break-word;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">

        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">

                        <h4>Search:</h4>
                    </div>

                    <div class="col-md-12" style="padding-top: 10px;">
                        <div class="col-md-2">
                            Apply For
                        <asp:DropDownList ID="drpApplyFor" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Select" Value="" Selected="True" />
                            <asp:ListItem Value="EWS" />
                            <asp:ListItem Value="LIG" />
                        </asp:DropDownList>

                        </div>
                        <div class="col-md-3">
                            Category
                            <asp:DropDownList ID="inpCategory" runat="server" CssClass="form-control">
                               
                            </asp:DropDownList>

                        </div>

                        <div class="col-md-3">
                            Search Text
    <asp:TextBox ID="txtSearchBy" runat="server" CssClass="form-control" placeholder="Search By Any Text"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            Apply For
                            <asp:DropDownList ID="drpStatus" runat="server" CssClass="form-control">
                                <asp:ListItem Value="2">All</asp:ListItem>
                                <asp:ListItem Value="1">Paid</asp:ListItem>
                                <asp:ListItem Value="0">Un-Paid</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="col-md-2">
                            DD Status
     <asp:DropDownList ID="drpDDStatus" runat="server" CssClass="form-control">
         <asp:ListItem Value="2">All</asp:ListItem>
         <asp:ListItem Value="1">DD Received</asp:ListItem>
         <asp:ListItem Value="0">DD Retrun</asp:ListItem>
     </asp:DropDownList>

                        </div>
                        <div class="col-md-2">
                            <br />
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-success btn"
                                OnClick="btnSearch_Click" />

                        </div>
                    </div>

                    <div class="card-header">

                        <h4>Register List ( Total Record:
                    <asp:Literal ID="ltrRecordCount" runat="server"></asp:Literal>)</h4>

                    </div>
                    <div class="card-body p-0">

                        <div class="table-responsive">
                            <div class="col-md-12" style="padding: 1px;">

                                <div class="bs-example4 col-md-12" data-example-id="simple-responsive-table">
                                    <!-- /.table-responsive -->
                                    <div class="table-responsive">
                                        <asp:Label ID="ltrRecords" runat="server"></asp:Label>
                                        <table class="table table-bordered">
                                            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="false" Font-Size="11pt"
                                                DataKeyNames="ID" AllowPaging="true" CssClass="grid" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                PageSize="100" Width="100%" CellPadding="10" OnRowCommand="grdView_RowCommand" OnRowDataBound="grdView_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="ApplyFor" HeaderText="Apply For" />
                                                    <asp:BoundField DataField="Category" HeaderText="Category" ReadOnly="true" />

                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                        ItemStyle-CssClass="minwidth120" HeaderText="Customer Details">
                                                        <ItemTemplate>
                                                            <b>Name:</b>
                                                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Eval("Name") %>' NavigateUrl='<%# "AddUser.aspx?id=" + Eval("ID") %>'>
                                                            </asp:HyperLink>
                                                            <br />
                                                            <b>Contact:</b>
                                                            <%#Eval("Contact") %>
                                                            <br />
                                                            <b>Email:</b>
                                                            <%#Eval("Email_ID") %>
                                                            <br />
                                                            <b><%#Eval("Relation") %>:</b> <%#Eval("RelationName") %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="180px"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                        ItemStyle-Width="180px" HeaderText="ID Proof ">
                                                        <ItemTemplate>

                                                            <b>Aadhaar Number:</b> <%#Eval("AadhaarNumber") %>
                                                            <br />
                                                            <b>
                                                                <%#Eval("IDName") %>
                                                            :</b> <%#Eval("IDValues") %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="180px"></ItemStyle>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                        ItemStyle-CssClass="minwidth120" HeaderText="Address">
                                                        <ItemTemplate>
                                                            <%#Eval("Address") %>, <%#Eval("City") %>, <%#Eval("State") %>, <%#Eval("Country") %> - <%#Eval("Pincode") %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                        ItemStyle-Width="180px" HeaderText="Income Details">
                                                        <ItemTemplate>
                                                            <%#Eval("AnnulIncome") %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="180px"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                        ItemStyle-Width="180px" HeaderText="Payment">
                                                        <ItemTemplate>
                                                            <b style="color: red;"><%# Convert.ToBoolean(Eval("Payment_Status")) ? "Paid" : "Unpaid" %></b>
                                                            <asp:LinkButton ID="lnkTransaction" CssClass="btn btn-primary" runat="server" CommandName="AddTransaction" CommandArgument='<%# Eval("ID") %>'>
                                                            View Transaction
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="btnPayment" CssClass="btn btn-primary" runat="server" CommandName="AddDD" CommandArgument='<%# Eval("ID") %>'>
                                                                DD Details
                                                            </asp:LinkButton>
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
                                        </table>
                                    </div>
                                    <!-- /.table-responsive -->
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
