<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Website.Master" AutoEventWireup="true" CodeBehind="FormList.aspx.cs" Inherits="WebApplication.Admin.FormList" %>

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
                        <div class="col-md-3">
                            Category
                            <asp:DropDownList ID="drpCategory" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            Apply For
                            <asp:DropDownList ID="DrpApplyFor" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Select" Value=""></asp:ListItem>

                                <asp:ListItem Text="EWS" Value="EWS"></asp:ListItem>
                                <asp:ListItem Text="LIG" Value="LIG"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            Search
                       <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search"></asp:TextBox>

                        </div>

                        <div class="col-md-3">
                            Form ID
   <asp:TextBox ID="txtFormID" runat="server" CssClass="form-control" placeholder="Form ID"></asp:TextBox>

                        </div>
                        <div class="col-md-2">
                            Form Status
    <asp:DropDownList ID="drpFormStatus" runat="server" CssClass="form-control">
        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>

        <asp:ListItem Text="Approve" Value="1"></asp:ListItem>
        <asp:ListItem Text="Reject" Value="2"></asp:ListItem>
        <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
    </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <br />
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-success btn"
                                OnClick="btnSearch_Click" />

                        </div>
                    </div>

                    <div class="card-header">

                        <h4>Form List ( Total Record:
                <asp:Literal ID="ltrRecordCount" runat="server"></asp:Literal>)</h4>

                    </div>
                    <div class="bs-example4 col-md-12" data-example-id="simple-responsive-table">
                        <!-- /.table-responsive -->
                        <div class="table-responsive">
                            <asp:Label ID="ltrRecords" runat="server"></asp:Label>
                            <table class="table table-bordered">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Font-Size="11pt"
                                    DataKeyNames="ID" AllowPaging="true" CssClass="grid" OnPageIndexChanging="GridView1_PageIndexChanging"
                                    PageSize="100" Width="100%" CellPadding="10" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="RegNo" HeaderText="Form ID" ReadOnly="true" />
                                        <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" />
                                        <asp:BoundField DataField="RelationName" HeaderText="Father Name" />
                                        <asp:BoundField DataField="PlotCategory" HeaderText="Plot Category" ReadOnly="true" />
                                        <asp:BoundField DataField="ApplicantCategory" HeaderText="Applicant Category" ReadOnly="true" />
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="180px" HeaderText="Status">
                                            <ItemTemplate>
                                                <b style="color: red;">
                                                    <asp:Literal ID="ltrFormStatus" Visible="false" Text='<%# Eval("FormStatus") %>' runat="server" />
                                                    <asp:Label ID="lblStatusText" runat="server" />
                                                    <br />
                                                </b>
                                                <asp:CheckBox ID="chkStatus" Text="Approve" runat="server" Visible='<%# (Convert.ToInt32(Eval("FormStatus")) == 0 || Convert.ToInt32(Eval("FormStatus")) == 2) %>' />
                                                <asp:Literal ID="ltrRegID" Visible="false" Text='<%# Eval("RegID") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="180px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="180px" HeaderText="Reject ">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRejectRemark" runat="server"></asp:TextBox>
                                                <br />
                                                <asp:Literal ID="ltrRejectRemark" runat="server" Text='<%# Eval("RejectRemark") %>'></asp:Literal>
                                            </ItemTemplate>
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

                        <div class="col-md-12 align-center">
                            <br />
                            <asp:LinkButton ID="btnUpdate" CssClass="btn btn-primary" runat="server" OnClick="btnUpdate_Click"> Update </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
