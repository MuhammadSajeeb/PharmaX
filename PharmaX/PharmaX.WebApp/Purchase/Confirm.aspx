<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="PharmaX.WebApp.Purchase.Cnfirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server" style="height: 100%">
        <h4>Purchase Confirm</h4>
        <div class="form-horizontal">
            <hr />
            <div class="row">
                <div class="col-md-offset-2 col-md-12" style="width: 100%">
                    <div class="card" style="border-top-color: red; border-top-style: solid; border-width: 2px">
                        <div class="card-body card-block">
                            <div class="form-group">
                                <div class="col-md-4">
                                    <asp:Label runat="server" ID="lblSuppliers" AssociatedControlID="SupplliersDropDownList" CssClass="control-label">Suppliers</asp:Label>
                                    <asp:DropDownList ID="SupplliersDropDownList" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                </div>

                                <div class="col-md-4">
                                    <asp:Label runat="server" ID="lblPurchaseCode" AssociatedControlID="txtPurchaseCode" Font-Size="Medium" CssClass="control-label">Purchase Code</asp:Label>
                                    <asp:TextBox runat="server" ID="txtPurchaseCode" Style="text-align: center" ReadOnly="true" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                </div>

                                <div class="col-md-4 mb-3">
                                    <asp:Label runat="server" ID="lblDate" AssociatedControlID="txtDate" Font-Size="Medium" CssClass="control-label">Purchase Date</asp:Label>
                                    <asp:TextBox runat="server" ID="txtDate" TextMode="Date" Style="text-align: center"  CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-4">
                                    <asp:Label runat="server" ID="lblCategories" AssociatedControlID="CategoriesDropDownList" CssClass="control-label">Categories</asp:Label>
                                    <asp:DropDownList ID="CategoriesDropDownList" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                </div>

                                <div class="col-md-4">
                                    <asp:Label runat="server" ID="lblItems" AssociatedControlID="ItemsDropDownList" CssClass="control-label">Items</asp:Label>
                                    <asp:DropDownList ID="ItemsDropDownList" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                </div>

                                <div class="col-md-4 mb-3">
                                    <asp:Label runat="server" ID="lblBatch" AssociatedControlID="txtBatch" Font-Size="Medium" CssClass="control-label">Batch</asp:Label>
                                    <asp:TextBox runat="server" ID="txtBatch" Style="text-align: center" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-4">
                                    <asp:Label runat="server" ID="lblQty" AssociatedControlID="txtQty" Font-Size="Medium" CssClass="control-label">Quantity</asp:Label>
                                    <asp:TextBox runat="server" ID="txtQty" Style="text-align: center" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                </div>

                                <div class="col-md-4">
                                    <asp:Label runat="server" ID="lblCostPrice" AssociatedControlID="txtCostPrice" Font-Size="Medium" CssClass="control-label">Cost Price</asp:Label>
                                    <asp:TextBox runat="server" ID="txtCostPrice" Style="text-align: center" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                </div>

                                <div class="col-md-4 mb-3">
                                    <asp:Label runat="server" ID="lblSellingPrice" AssociatedControlID="txtSellingPrice" Font-Size="Medium" CssClass="control-label">Selling Price</asp:Label>
                                    <asp:TextBox runat="server" ID="txtSellingPrice" Style="text-align: center" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-4">
                                    <asp:Label runat="server" ID="lblManufacture" AssociatedControlID="txtManufacture" Font-Size="Medium" CssClass="control-label">Manufacture Date</asp:Label>
                                    <asp:TextBox runat="server" ID="txtManufacture" TextMode="Date" Style="text-align: center" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                </div>

                                <div class="col-md-4">
                                    <asp:Label runat="server" ID="lblExpire" AssociatedControlID="txtExpire" Font-Size="Medium" CssClass="control-label">Expire Date</asp:Label>
                                    <asp:TextBox runat="server" ID="txtExpire" TextMode="Date" Style="text-align: center" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                    
                                </div>
                                
                                <div class="col-md-4 mb-3">
                                <br />    
                                    <asp:Button runat="server" ID="AddButton" Text="Add" CssClass="btn btn-info" Width="120px" Height="50px" />
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </form>
</asp:Content>
