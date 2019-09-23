<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewAll.aspx.cs" Inherits="PharmaX.WebApp.Supplier.ViewAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>View All Suppliers</h4>
    <div class="form-group">
        <div class="col-md-10">
            <a class="nav-link" href="Setup.aspx">Create New</a>
        </div>
    </div>
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            <div class="col-md-offset-1 col-md-10" style="width: 100%">
                <div class="card" style="border-top-color: red; border-top-style: solid; border-width: 2px">
                    <div class="card-body card-block">
                        <div class="form-group">
                            <div class="col-md-12">
                                <asp:GridView ID="SuppliersGridView" runat="server" DataKeyNames="Contact" EmptyDataText="No Items Available Now" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="true" CellSpacing="1">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ImageUrl="~/Supplier/img/delete.png" OnClientClick="return confirm('Are You Sure Delete This Category')" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                        <asp:BoundField DataField="Contact" HeaderText="Contact" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" />
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
        </div>
    </div>

    <link href="../Content/GridviewStyleSheet.css" rel="stylesheet" />
</asp:Content>
