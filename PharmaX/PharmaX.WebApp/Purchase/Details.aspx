<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="PharmaX.WebApp.Purchase.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Purchase Details</h4>
    <div class="form-group">
        <div class="col-md-10">
            <a class="nav-link" href="Entry.aspx">Create New</a>
        </div>
    </div>
    <div class="form-horizontal">
        <hr />
        <div class="card" style="border-top-color: red; border-top-style: solid; border-width: 2px">
            <div class="card-body card-block">
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group">
                                <div class="col-md-10">
                                    <asp:Label runat="server" ID="lblSPurchaseId" AssociatedControlID="lblPurchaseId" CssClass="control-label">PurchaseId</asp:Label>
                                </div>
                                <div class="col-md-10">
                                    <asp:Label runat="server" ID="lblSDate" AssociatedControlID="lblDate" CssClass="control-label">Date</asp:Label>
                                </div>
                                <div class="col-md-10">
                                    <asp:Label runat="server" ID="lblSDescription" AssociatedControlID="lblDescription" CssClass="control-label">Description</asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <div class="col-md-10">
                                    <asp:Label runat="server" ID="lblPurchaseId" AssociatedControlID="lblPurchaseId" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-md-10">
                                    <asp:Label runat="server" ID="lblDate" AssociatedControlID="lblDate" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-md-10">
                                    <asp:Label runat="server" ID="lblDescription" AssociatedControlID="lblDescription" CssClass="control-label"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <asp:GridView ID="PurchaseDetailsGridView" runat="server" DataKeyNames="PurchaseId" EmptyDataText="No Items Available Now" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="true" CellSpacing="1">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ImageUrl="~/Purchase/img/delete.png" OnClientClick="return confirm('Are You Sure Delete This Category')" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PurchaseId" HeaderText="Purchase" />
                            <asp:BoundField DataField="Item" HeaderText="Item" />
                            <asp:BoundField DataField="Batch" HeaderText="Batch" />
                            <asp:BoundField DataField="Qty" HeaderText="Qty" />
                            <asp:BoundField DataField="CostPrice" HeaderText="Cost(Tk)" />
                            <asp:BoundField DataField="TotalPrice" HeaderText="Total(Tk)" />
                            <asp:BoundField DataField="SellingPrice" HeaderText="Selling(Tk)" />
                            <asp:BoundField DataField="Expire" HeaderText="Expire" />
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
    <script type="text/javascript">
        $(function () {
            $('[id*=PurchaseDetailsGridView]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
