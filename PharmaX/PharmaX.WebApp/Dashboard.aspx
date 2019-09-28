<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="PharmaX.WebApp.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <div class="row">
            <div class="col-lg-6">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="card" style="border-top-style: solid; border-width: 2px">
                            <div class="tile-stats white-bg" style="margin-left: 20px; margin-top: 20px">
                                <div class="status">
                                    <h3 class="m-t-0 text-info"><i class="fa fa-list"></i>
                                        <asp:Label ID="lblTotalShelfs" runat="server" Text="80"></asp:Label>
                                    </h3>
                                    <p>
                                        Total Shelfs
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="card" style="border-top-style: solid; border-width: 2px">
                            <div class="tile-stats white-bg" style="margin-left: 20px; margin-top: 20px">
                                <div class="status">
                                    <h3 class="m-t-0 text-danger"><i class="fa fa-medkit"></i>
                                        <asp:Label ID="lblTotalMedicine" runat="server" Text="1000"></asp:Label>
                                    </h3>
                                    <p>
                                        Total Medicines
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="card" style="border-top-style: solid; border-width: 2px">
                            <div class="tile-stats white-bg" style="margin-left: 20px; margin-top: 20px">
                                <div class="status">
                                    <h3 class="m-t-0 text-success"><i class="fa fa-shopping-cart"></i>
                                        <asp:Label ID="lblTotalPurchase" runat="server" Text="20000"></asp:Label>
                                    </h3>
                                    <p>
                                        No of Purchase
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="card" style="border-top-style: solid; border-width: 2px">
                            <div class="tile-stats white-bg" style="margin-left: 20px; margin-top: 20px">
                                <div class="status">
                                    <h3 class="m-t-0 text-info"><i class="fas fa-fw fa-paper-plane"></i>
                                        <asp:Label ID="lblTotalPurchaseAmount" runat="server" Text="36022020"></asp:Label>
                                    </h3>
                                    <p>
                                        Total Purchase Amount
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="card" style="border-top-style: solid; border-width: 2px">
                            <div class="tile-stats white-bg" style="margin-left: 20px; margin-top: 20px">
                                <div class="status">
                                    <h3 class="m-t-0 text-danger"><i class="fas fa-fw fa-chart-area"></i>
                                        <asp:Label ID="lblTotalStocks" runat="server" Text="25718"></asp:Label>
                                    </h3>
                                    <p>
                                        Total Stocks Quantity
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="card" style="border-top-style: solid; border-width: 2px">
                            <div class="tile-stats white-bg" style="margin-left: 20px; margin-top: 20px">
                                <div class="status">
                                    <h3 class="m-t-0 text-info"><i class="fa fa-users"></i>
                                        <asp:Label ID="lblTotalSuppliers" runat="server" Text="10"></asp:Label>
                                    </h3>
                                    <p>
                                        Total Suppliers
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="card" style="border-top-style: solid; border-width: 2px">
                            <div class="tile-stats white-bg" style="margin-left: 20px; margin-top: 20px">
                                <div class="status">
                                    <h3 class="m-t-0 text-success"><i class="fa fa-shopping-cart"></i>
                                        <asp:Label ID="lblTotalSales" runat="server" Text="164"></asp:Label>
                                    </h3>
                                    <p>
                                        No of Sales
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="card" style="border-top-style: solid; border-width: 2px">
                            <div class="tile-stats white-bg" style="margin-left: 20px; margin-top: 20px">
                                <div class="status">
                                    <h3 class="m-t-0 text-info"><i class="fas fa-fw fa-paper-plane"></i>
                                        <asp:Label ID="lblTotalSaleAmount" runat="server" Text="48903317"></asp:Label>
                                    </h3>
                                    <p>
                                        Total Sales Amount
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="form-group">
            <div class="card" style="border-top-color: red; border-top-style: solid; border-width: 2px">
                <div class="card-body card-block">
                    <div class="form-group">
                        <asp:GridView ID="StockLowerGridView" runat="server" EmptyDataText="No Stocks Available Now" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="true" CellSpacing="1">
                            <Columns>
                                <asp:BoundField DataField="Item" HeaderText="Item" />
                                <asp:BoundField DataField="Batch" HeaderText="Batch" />
                                <asp:BoundField DataField="StockQty" HeaderText="Stock Qty" />
                                <asp:BoundField DataField="CostPrice" HeaderText="Cost Price" />
                                <asp:BoundField DataField="SellingPrice" HeaderText="Selling Price" />
                                <asp:CommandField HeaderText="Action" SelectText="Purchase" ShowSelectButton="True">
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
            $('[id*=StockLowerGridView]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>

</asp:Content>
