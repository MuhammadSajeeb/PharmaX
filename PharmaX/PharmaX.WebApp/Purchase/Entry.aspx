<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Entry.aspx.cs" Inherits="PharmaX.WebApp.Purchase.Entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Purchase Confirm</h4>
    <div class="form-horizontal">
        <hr />
        <div class="card" style="border-top-color: red; border-top-style: solid; border-width: 2px">
            <div class="card-body card-block">
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <div class="col-md-10">
                                <asp:Label runat="server" ID="lblSuppliers" AssociatedControlID="SuppliersDropDownList" CssClass="control-label">Suppliers</asp:Label>
                                <asp:DropDownList ID="SuppliersDropDownList" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <div class="col-md-10">
                                <asp:Label runat="server" ID="lblPurchaseCode" AssociatedControlID="txtPurchaseCode" Font-Size="Medium" CssClass="control-label">Purchase Code</asp:Label>
                                <asp:TextBox runat="server" ID="txtPurchaseCode" Style="text-align: center" ReadOnly="true" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPurchaseCode"
                                    CssClass="text-danger" ErrorMessage="This field is required." />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <div class="col-md-10">
                                <asp:Label runat="server" ID="lblDate" AssociatedControlID="txtDate" Font-Size="Medium" CssClass="control-label">Purchase Date</asp:Label>
                                <asp:TextBox runat="server" ID="txtDate" TextMode="Date" Style="text-align: center" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <div class="col-md-10">
                                <asp:Label runat="server" ID="lblCategories" AssociatedControlID="CategoriesDropDownList" CssClass="control-label">Categories</asp:Label>
                                <asp:DropDownList ID="CategoriesDropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="CategoriesDropDownList_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-10">
                                <asp:Label runat="server" ID="lblItems" AssociatedControlID="ItemsDropDownList" CssClass="control-label">Items</asp:Label>
                                <asp:DropDownList ID="ItemsDropDownList" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-10">
                                <asp:Label runat="server" ID="lblBatch" AssociatedControlID="txtBatch" Font-Size="Medium" CssClass="control-label">Batch</asp:Label>
                                <asp:TextBox runat="server" ID="txtBatch" Style="text-align: center" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-10">
                                <asp:Label runat="server" ID="lblQty" AssociatedControlID="txtQty" Font-Size="Medium" CssClass="control-label">Quantity</asp:Label>
                                <asp:TextBox runat="server" ID="txtQty" Style="text-align: center" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-10">
                                <asp:Label runat="server" ID="lblCostPrice" AssociatedControlID="txtCostPrice" Font-Size="Medium" CssClass="control-label">Cost Price</asp:Label>
                                <asp:TextBox runat="server" ID="txtCostPrice" Style="text-align: center" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-10">
                                <asp:Label runat="server" ID="lblSellingPrice" AssociatedControlID="txtSellingPrice" Font-Size="Medium" CssClass="control-label">Selling Price</asp:Label>
                                <asp:TextBox runat="server" ID="txtSellingPrice" Style="text-align: center" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-10">
                                <asp:Label runat="server" ID="lblExpire" AssociatedControlID="txtExpire" Font-Size="Medium" CssClass="control-label">Expire</asp:Label>
                                <asp:TextBox runat="server" ID="txtExpire" TextMode="Date" Style="text-align: center" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-10">
                                <br />
                                <asp:Button runat="server" ID="AddButton" Text="Add" CssClass="btn btn-info" Width="100px" OnClick="AddButton_Click" />

                            </div>
                        </div>
                    </div>
                    <div class="col-md-8">
                        <br />
                        <div class="form-group">
                            <div class="card" border-top-style: solid; border-width: 2px">
                                <div class="card-header" style="background-color:azure; text-align: center">
                                    <h6>Purchase Order</h6>
                                </div>
                                <div class="card-body card-block">
                                    <%--<div class="col-md-12">--%>
                                        <asp:GridView ID="PurchaseGridView" runat="server" EmptyDataText="No Order Available Here" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="false" CellSpacing="10" OnRowDeleting="PurchaseGridView_RowDeleting" OnRowCancelingEdit="PurchaseGridView_RowCancelingEdit" OnRowEditing="PurchaseGridView_RowEditing" OnRowUpdating="PurchaseGridView_RowUpdating" OnRowDataBound="PurchaseGridView_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Item">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItem" runat="server" Text='<%#Eval("Item") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEItem" runat="server" Text='<%#Eval("Item") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Batch">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBatch" runat="server" Text='<%#Eval("Batch") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEBatch" runat="server" Text='<%#Eval("Batch") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEQty" runat="server" Text='<%#Eval("Qty") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cost Price">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCostPrice" runat="server" Text='<%#Eval("CostPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtECostPrice" runat="server" Text='<%#Eval("CostPrice") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Selling Price">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSellingPrice" runat="server" Text='<%#Eval("SellingPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtESellingPrice" runat="server" Text='<%#Eval("SellingPrice") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Expire">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExpire" runat="server" Text='<%#Eval("Expire") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEExpire" runat="server" Text='<%#Eval("Expire") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle Font-Bold="true" Font-Size="Small" ForeColor="#3399FF" />
                                        </asp:GridView>
                                   <%-- </div>--%>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12">
                                <button style="padding: 5px 30px 5px 30px" type="button" class="btn btn-primary fa-pull-right" id="btnShowLogin">
                                    Next <span class="fa fa-caret-up"></span>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--\\popup model start\\--%>
        <div class="modal fade" id="LoginModal" tabindex="-1" role="dialog" aria-labelledby="ModalTitle"
            aria-hidden="true">
            <div class="modal-dialog modal-md">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="ModalTitle">Payment Status</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            &times;</button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblAmount" CssClass="col-md-2 control-label" Font-Bold="true" Text="Total Amount(Tk)" Font-Size="Medium"></asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblDiscount" CssClass="col-md-2 control-label" Font-Bold="true" Text="Discount(Tk)" Font-Size="Medium"></asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtDiscount" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="false" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblGrandTotal" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="Grand Total(Tk)"></asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtGrandTotal" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblIsPaid" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="Medium" Text="IsPaid"></asp:Label>
                            <div class="form-check form-check-inline">
                                <asp:RadioButton ID="PaidRadioButton" Text="Paid" runat="server" CssClass="form-control" GroupName="Ispaid" />
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:RadioButton ID="DueRadioButton" Text="Due" runat="server" CssClass="form-control" GroupName="Ispaid" />
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="PurchaseSubmitButton" Text="Submit" runat="server" Class="btn btn-info" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            $("#btnShowLogin").click(function () {
                $('#LoginModal').modal('show');
            });
        });
    </script>

</asp:Content>
