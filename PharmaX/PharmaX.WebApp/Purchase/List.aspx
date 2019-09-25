<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="PharmaX.WebApp.Purchase.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Purchase List</h4>
    <div class="form-group">
        <div class="col-md-10">
            <a class="nav-link" href="Entry.aspx">Create New</a>
        </div>
    </div>
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
                <div class="card" style="border-top-color: red; border-top-style: solid; border-width: 2px">
                    <div class="card-body card-block">
                        <div class="form-group">
                                <asp:GridView ID="PurchaseListGridView" runat="server" DataKeyNames="PurchaseId" EmptyDataText="No Items Available Now" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="true" CellSpacing="1" OnSelectedIndexChanged="PurchaseListGridView_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ImageUrl="~/Purchase/img/delete.png" OnClientClick="return confirm('Are You Sure Delete This Category')" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Name" HeaderText="Suppliers" />
                                        <asp:BoundField DataField="PurchaseId" HeaderText="Id" />
                                        <asp:BoundField DataField="TotalAmount" HeaderText="Amount" />
                                        <asp:BoundField DataField="Discount" HeaderText="Discount" />
                                        <asp:BoundField DataField="GrandTotal" HeaderText="Total" />
                                        <asp:BoundField DataField="Status" HeaderText="IsPayment" />
                                        <asp:BoundField DataField="Date" HeaderText="Date" />
                                        <asp:CommandField HeaderText="Action" SelectText="Details" ShowSelectButton="True">
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

        <script type="text/javascript">
        $(function () {
            $('[id*=PurchaseListGridView]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
