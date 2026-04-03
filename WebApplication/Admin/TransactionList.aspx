<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Website.Master" AutoEventWireup="true" CodeBehind="TransactionList.aspx.cs" Inherits="WebApplication.Admin.TransactionList" %>

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
                        <div class="col-md-12 pb-3">
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
                         <asp:DropDownList ID="DrpCategory" runat="server" CssClass="form-control">
                            
                         </asp:DropDownList>

                            </div>


                            <div class="col-md-3">
                                Search Text
                         <asp:TextBox ID="txtSearchBy" runat="server" CssClass="form-control" placeholder="Search By Any Text"></asp:TextBox>
                            </div>

                            <div class="col-md-2">
                                Form No
                                <asp:TextBox ID="txtFormID" runat="server" CssClass="form-control" placeholder="Form No"></asp:TextBox>

                            </div>

                            <div class="col-md-2">
                                Payment Status
                      <asp:DropDownList ID="drpPaymentStatus" runat="server" CssClass="form-control">
                          <asp:ListItem Text="Select" Value="2" Selected="True" />
                          <asp:ListItem Value="0" Text="UnPaid" />
                          <asp:ListItem Value="1" Text="Paid" />
                      </asp:DropDownList>

                            </div>


                        </div>
                        <div class="col-md-12">
                            <div class="col-md-3">
                                Order ID
                    <asp:TextBox ID="txtOrderID" runat="server" CssClass="form-control" placeholder="Order ID"></asp:TextBox>
                            </div>

                            <div class="col-md-2">
                                <br />
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-success btn"
                                    OnClick="btnSearch_Click" />

                            </div>
                        </div>
                    </div>

                    <div class="card-header">

                        <h4>Transaction List ( Total Record:
                  <asp:Literal ID="ltrRecordCount" runat="server"></asp:Literal>)</h4>

                    </div>
                    <div class="card-body p-0">

                        <div class="table-responsive">
                            <div class="col-md-12" style="padding: 10px;">


                                <div class="bs-example4 col-md-12" data-example-id="simple-responsive-table">
                                    <!-- /.table-responsive -->
                                    <div class="table-responsive">
                                        <asp:Label ID="ltrRecords" runat="server"></asp:Label>
                                        <table class="table table-bordered">
                                            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="false" Font-Size="11pt"
                                                DataKeyNames="ID" AllowPaging="true" CssClass="grid" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                PageSize="100" Width="100%" CellPadding="10" OnRowDataBound="GridView1_RowDataBound"
                                                OnRowCommand="GridView1_RowCommand">
                                                <Columns>
                                                    <asp:BoundField DataField="ApplyFor" HeaderText="Apply For" />

                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                        ItemStyle-Width="180px" HeaderText="Customer Details">
                                                        <ItemTemplate>

                                                            <b>Customer Name:</b><%#Eval("CustomerName") %>
                                                            <br />
                                                            <b>Contact:</b>
                                                            <%#Eval("Contact") %>
                                                            <br />
                                                            <b><%#Eval("Relation") %>:</b> <%#Eval("RelationName") %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="180px"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                        ItemStyle-Width="180px" HeaderText="ID Proof ">
                                                        <ItemTemplate>

                                                            <b>Form ID :</b><%#Eval("FormID") %>
                                                            <br />
                                                            <b>Order ID :</b>
                                                            <%#Eval("Order_ID") %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="180px"></ItemStyle>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                        ItemStyle-Width="180px" HeaderText="Payment Details ">
                                                        <ItemTemplate>

                                                            <b>Total Price: </b><%#Eval("Total_Price") %>

                                                            <br />
                                                            <b><a href='UpdatePayment.aspx?OrderId=<%#Eval("Order_ID") %>'>Received Amount:</b><%#Eval("AmountReceived") %></a>
                                                            <br />
                                                            <b>Payment Date:</b> <%# Eval("PaymentDate", "{0:dd/MM/yyyy}") %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="180px"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <%-- <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                        ItemStyle-Width="180px" HeaderText="Refund Details">
                                                        <ItemTemplate>
                                                            <b>Refund Detail:</b><%#Eval("RefundDetail") %>
                                                            <br />
                                                            <b>Refund Amount:</b>
                                                            <%#Eval("RefundAmount") %>
                                                            <br />
                                                            <b>Refund Date:</b>
                                                            <%#Eval("RefundDate") %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="180px"></ItemStyle>
                                                    </asp:TemplateField>--%>

                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                        ItemStyle-Width="180px" HeaderText="Payment">
                                                        <ItemTemplate>
                                                            <b style="color: red;"><%# Convert.ToBoolean(Eval("Payment_Status")) ? "Paid" : "Unpaid" %></b>

                                                            <asp:LinkButton ID="btnPayment" CssClass="btn btn-primary" runat="server"
                                                                CommandName="AddPayment"
                                                                CommandArgument='<%# Eval("Order_ID") %>'>
                                                                            Add Payment
                                                            </asp:LinkButton>
                                                            <asp:LinkButton ID="btnPrint" CssClass="btn btn-info" runat="server"
                                                                CommandName="Print"
                                                                CommandArgument='<%# Eval("FormID") %>'
                                                                Visible='<%# Convert.ToBoolean(Eval("Payment_Status")) %>'>
                                                                Print
                                                            </asp:LinkButton>



                                                            <asp:Literal ID="ltrAmountRec" Visible="false" runat="server" Text='<%# Eval("AmountReceived") %>'></asp:Literal>
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
