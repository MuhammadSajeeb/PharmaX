﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewAll.aspx.cs" Inherits="PharmaX.WebApp.Item.ViewAll" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h4>View All Items</h4>
    <div class="form-group">
        <div class="col-md-10">
            <a class="nav-link" href="Setup.aspx">Create New</a>
        </div>
    </div>
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
                <div class="card" style="border-top-color: red; border-top-style: solid; border-width: 2px">
                    <div class="card-body card-block">
                        <div class="form-group">
                                <asp:GridView ID="ItemsGridView" runat="server" DataKeyNames="Code" EmptyDataText="No Items Available Now" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="true" CellSpacing="1">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ImageUrl="~/Item/img/delete.png" OnClientClick="return confirm('Are You Sure Delete This Category')" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Code" HeaderText="Code" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="GenericName" HeaderText="Generic Name" />
                                        <asp:BoundField DataField="ReorderLevel" HeaderText="Reorder Level" />
                                        <asp:BoundField DataField="Date" HeaderText="Date" />
                                        <asp:CommandField HeaderText="Action" SelectText="Edit" ShowSelectButton="True">
                                            <ItemStyle ForeColor="#CC0000" />
                                        </asp:CommandField>
                                    </Columns>
                                    <PagerStyle Font-Bold="true" Font-Size="Small" ForeColor="#3399FF" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    <link href="../Content/GridviewStyleSheet.css" rel="stylesheet" />

        <script type="text/javascript">
        $(function () {
            $('[id*=ItemsGridView]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
