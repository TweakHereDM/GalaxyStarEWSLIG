<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Website.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="WebApplication.ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        th, td {
            text-align: center !important;
            padding: 10px !important;
            width: 12%;
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
                            Search Text
                                                        <asp:TextBox ID="txtSearchBy" runat="server" CssClass="form-control" placeholder="Search By Any Text"></asp:TextBox>

                        </div>

                        <div class="col-md-2">
                            Allot
                            <asp:DropDownList ID="drpAssigned" runat="server" CssClass="form-control">
                                <asp:ListItem Value="2">All</asp:ListItem>
                                <asp:ListItem Value="1">Alloted</asp:ListItem>
                                <asp:ListItem Value="0">Not Alloted</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <br />
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-success btn"
                                OnClick="btnSearch_Click" />

                        </div>
                    </div>

                    <div class="card-header">

                        <h4>Contact List ( Total Record:
                        <asp:Literal ID="ltrRecordCount" runat="server"></asp:Literal>)</h4>

                    </div>
                    <div class="card-body p-0">
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                        <!-- Select All :
                        <asp:CheckBox ID="chkSelectAll" runat="server" OnCheckedChanged="chkSelectAll_CheckedChanged" AutoPostBack="true" />
                        -->
                        <div class="table-responsive">
                            <div class="col-md-12" style="padding: 10px;">
                                <asp:Repeater ID="rpt_item" runat="server">
                                    <ItemTemplate>

                                        <div class="col-md-12" style="border: 1px solid #000; padding: 10px">
                                            <div class="col-md-3">

                                                <%#Eval("SrNo") %>
                                            </div>
                                            <div class="col-md-3">
                                                <%#Eval("CustomerName")%>
                                            </div>


                                            <div class="col-md-3">
                                                <%#Eval("Father") %>
                                            </div>
                                            <div class="col-md-3">

                                                <%#Eval("RegNo") %>
                                            </div>


                                        </div>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>

    </section>

</asp:Content>
