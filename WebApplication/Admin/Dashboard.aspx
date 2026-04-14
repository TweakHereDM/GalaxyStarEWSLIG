<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Website.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WebApplication.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <section class="section">

        <h2 style="text-align: center; color: white">Lottery Panel Star City</h2>
        <div class="row">
            <div class="col-12">
                <h3>
                    <asp:Literal ID="ltr" runat="server"></asp:Literal></h3>
                <div class="col-md-12">
                    <div class="col_3">



                        <!-- <div class="col-xl-3 col-lg-12 col-md-6 col-sm-6 col-xs-12">
                            <div class="card">
                                <a href="CustomerList.aspx">
                                    <div class="card-statistic-4">
                                        <div class="align-items-center justify-content-between">
                                            <div class="row ">
                                                <div class="col-lg-12 col-md-6 col-sm-6 col-xs-6 pr-0 pt-3">
                                                    <div class="card-content">
                                                        <h5 class="font-15">Total Application</h5>
                                                        <h2 class="mb-3 font-18">
                                                            <asp:Literal ID="ltrTotalApplication" runat="server"></asp:Literal></h2>

                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col-xl-3 col-lg-12 col-md-6 col-sm-6 col-xs-12">
                            <div class="card">
                                <a href="CustomerList.aspx">
                                    <div class="card-statistic-4">
                                        <div class="align-items-center justify-content-between">
                                            <div class="row ">
                                                <div class="col-lg-12 col-md-6 col-sm-6 col-xs-6 pr-0 pt-3">
                                                    <div class="card-content">
                                                        <h5 class="font-15">Paid Application</h5>
                                                        <h2 class="mb-3 font-18">
                                                            <asp:Literal ID="ltrPaidApplication" runat="server"></asp:Literal></h2>

                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col-xl-3 col-lg-12 col-md-6 col-sm-6 col-xs-12">
                            <div class="card">
                                <a href="ItemMaster.aspx">
                                    <div class="card-statistic-4">
                                        <div class="align-items-center justify-content-between">
                                            <div class="row ">
                                                <div class="col-lg-12 col-md-6 col-sm-6 col-xs-6 pr-0 pt-3">
                                                    <div class="card-content">
                                                        <h5 class="font-15">Total Amount</h5>
                                                        <h2 class="mb-3 font-18">
                                                            <asp:Literal ID="ltrTotalAmount" runat="server"></asp:Literal></h2>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </div>
                         <div class="col-xl-3 col-lg-12 col-md-6 col-sm-6 col-xs-12">
                                <div class="card">
                                    <a href="ItemMaster.aspx">
                                        <div class="card-statistic-4">
                                            <div class="align-items-center justify-content-between">
                                                <div class="row ">
                                                    <div class="col-lg-12 col-md-6 col-sm-6 col-xs-6 pr-0 pt-3">
                                                        <div class="card-content">
                                                            <h5 class="font-15">Active Stock</h5>
                                                            <h2 class="mb-3 font-18">
                                                                <asp:Literal ID="ltrActiveStock" runat="server"></asp:Literal></h2>

                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </a>
                                </div>
                            </div>
                            <div class="col-xl-3 col-lg-12 col-md-6 col-sm-6 col-xs-12">
                                <div class="card">
                                    <a href="ItemTransfer.aspx">
                                        <div class="card-statistic-4">
                                            <div class="align-items-center justify-content-between">
                                                <div class="row ">
                                                    <div class="col-lg-12 col-md-6 col-sm-6 col-xs-6 pr-0 pt-3">
                                                        <div class="card-content">
                                                            <h5 class="font-15">Pending Job Work</h5>
                                                            <h2 class="mb-3 font-18">
                                                                <asp:Literal ID="ltrItemTransferred" runat="server"></asp:Literal></h2>

                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </a>
                                </div>
                            </div>
                            <div class="col-xl-3 col-lg-12 col-md-6 col-sm-6 col-xs-12">
                                <div class="card">
                                    <a href="DueList.aspx">
                                        <div class="card-statistic-4">
                                            <div class="align-items-center justify-content-between">
                                                <div class="row ">
                                                    <div class="col-lg-12 col-md-6 col-sm-6 col-xs-6 pr-0 pt-3">
                                                        <div class="card-content">
                                                            <h5 class="font-15">Total Due (Customer)</h5>
                                                            <h2 class="mb-3 font-18">
                                                                <asp:Literal ID="ltrTotalDue" runat="server"></asp:Literal></h2>

                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </a>
                                </div>
                            </div>
                            <div class="col-xl-3 col-lg-12 col-md-6 col-sm-6 col-xs-12">
                                <div class="card">
                                    <div class="card-statistic-4">
                                        <div class="align-items-center justify-content-between">
                                            <div class="row ">
                                                <div class="col-lg-12 col-md-6 col-sm-6 col-xs-6 pr-0 pt-3">
                                                    <div class="card-content">
                                                        <h5 class="font-15">Products Sold</h5>
                                                        <h2 class="mb-3 font-18">
                                                            <asp:Literal ID="ltrProductsSold" runat="server"></asp:Literal></h2>

                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-3 col-lg-12 col-md-6 col-sm-6 col-xs-12">
                                <div class="card">
                                    <a href="ItemTransfer.aspx?Over=1">
                                        <div class="card-statistic-4">
                                            <div class="align-items-center justify-content-between">
                                                <div class="row ">
                                                    <div class="col-lg-12 col-md-6 col-sm-6 col-xs-6 pr-0 pt-3">
                                                        <div class="card-content">
                                                            <h5 class="font-15">Job Work Pending Overdue</h5>
                                                            <h2 class="mb-3 font-18">
                                                                <asp:Literal ID="ltrJWPendingOverdue" runat="server"></asp:Literal></h2>

                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </a>
                                </div>
                            </div>-->
                    </div>
                </div>

                <!-- switches -->
                <div class="col-md-12">
                    <div class="col-md-6" style="margin-bottom: 30px">
                        <h3 style="color: #fff;">Category Wise Application</h3>

                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Font-Size="11pt"
                            DataKeyNames="CategoryName" AllowPaging="true" CssClass="grid"
                            Width="100%" PageSize="50" CellPadding="10">
                            <Columns>
                                <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                                <asp:BoundField DataField="EWSCount" HeaderText="EWS" />

                                <asp:BoundField DataField="LIGCount" HeaderText="LIG" />
                            </Columns>
                            <EmptyDataTemplate>
                                No Records Found...
                            </EmptyDataTemplate>
                            <AlternatingRowStyle BackColor="#f9f9f9" />
                            <RowStyle BackColor="#DACDCD" />

                            <RowStyle ForeColor="Black" />
                            <HeaderStyle BackColor="Black" />
                            <HeaderStyle ForeColor="White" />
                            <PagerStyle CssClass="GridPager" />
                        </asp:GridView>


                    </div>


                    <div class="col-md-6" style="margin-bottom: 30px">
                        <h3 style="color: #fff;">Category Wise Plot</h3>

                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" Font-Size="11pt"
                            DataKeyNames="CategoryName" AllowPaging="true" CssClass="grid"
                            Width="100%" PageSize="50" CellPadding="10">
                            <Columns>
                                <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                                <asp:BoundField DataField="EWSCount" HeaderText="EWS" />

                                <asp:BoundField DataField="LIGCount" HeaderText="LIG" />
                            </Columns>
                            <EmptyDataTemplate>
                                No Records Found...
                            </EmptyDataTemplate>
                            <AlternatingRowStyle BackColor="#f9f9f9" />
                            <RowStyle BackColor="#DACDCD" />

                            <RowStyle ForeColor="Black" />
                            <HeaderStyle BackColor="Black" />
                            <HeaderStyle ForeColor="White" />
                            <PagerStyle CssClass="GridPager" />
                        </asp:GridView>


                    </div>
                </div>

                <!--body wrapper start-->
            </div>
        </div>
    </section>

</asp:Content>
