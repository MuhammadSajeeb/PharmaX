<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="PharmaX.WebApp.Stock.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Stock List</h4>
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
                <div class="card" style="border-top-color: red; border-top-style: solid; border-width: 2px">
                    <div class="card-body card-block">
                        <div class="form-group">
                                <asp:GridView ID="StockListGridView" runat="server" EmptyDataText="No Stocks Available Now" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="true" CellSpacing="1">
                                    <Columns>
                                        <asp:BoundField DataField="Item" HeaderText="Item" />
                                        <asp:BoundField DataField="Batch" HeaderText="Batch" />
                                        <asp:BoundField DataField="StockQty" HeaderText="Stock Qty" />
                                        <asp:BoundField DataField="CostPrice" HeaderText="Cost Price" />
                                        <asp:BoundField DataField="SellingPrice" HeaderText="Selling Price" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        <script type="text/javascript">
        $(function () {
            $('[id*=StockListGridView]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
