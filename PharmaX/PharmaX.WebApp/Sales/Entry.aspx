<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Entry.aspx.cs" Inherits="PharmaX.WebApp.Sale.Entry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Sales Entry</h4>
    <div class="form-horizontal">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card" style="border-top-color: red; border-top-style: solid; border-width: 2px">
            <div class="card-body card-block">
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <div class="col-md-10">
                                <asp:Label runat="server" ID="lblCustomerContact" AssociatedControlID="txtCustomerContact" Font-Size="Medium" CssClass="control-label">Customer Contact</asp:Label>
                                <asp:TextBox runat="server" ID="txtCustomerContact" Style="text-align: center" CssClass="form-control" Font-Bold="true" Font-Size="Medium" TextMode="Number" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <div class="col-md-10">
                                <asp:Label runat="server" ID="lblSalesId" AssociatedControlID="txtSalesId" Font-Size="Medium" CssClass="control-label">Sales Code</asp:Label>
                                <asp:TextBox runat="server" ID="txtSalesId" Style="text-align: center" ReadOnly="true" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSalesId"
                                    CssClass="text-danger" ErrorMessage="This field is required." />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <div class="col-md-10">
                                <asp:Label runat="server" ID="lblDate" AssociatedControlID="txtDate" Font-Size="Medium" CssClass="control-label">Sales Date</asp:Label>
                                <asp:TextBox runat="server" ID="txtDate" TextMode="Date" Style="text-align: center" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDate"
                                  CssClass="text-danger" ErrorMessage="This field is required." />
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
                                <asp:DropDownList ID="ItemsDropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ItemsDropDownList_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label1" CssClass="col-md-2 control-label" Font-Bold="true" Font-Size="X-Small" Text="Selling Price"></asp:Label>
                            <div class="form-check form-check-inline">
                                <asp:Label runat="server" ID="lblSellingPrice" CssClass="control-label" Font-Bold="true" Font-Size="X-Small">00</asp:Label>
                            </div>
                            <asp:Label runat="server" ID="Label3" CssClass="col-md-1 control-label" Font-Bold="true" Font-Size="X-Small" Text="Stock"></asp:Label>
                            <div class="form-check form-check-inline">
                                <asp:Label runat="server" ID="lblStock" CssClass="control-label" Font-Bold="true" Font-Size="X-Small">00</asp:Label>
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
                                <br />
                                <asp:Button runat="server" ID="AddButton" Text="Add" CssClass="btn btn-info" Width="100px" OnClick="AddButton_Click"/>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-8">
                        <br />
                        <div class="form-group">
                            <div class="card" border-top-style: solid; border-width: 2px">
                                <div class="card-header" style="background-color:azure; text-align: center">
                                    <h6>Sales Order</h6>
                                </div>
                                <div class="card-body card-block">
                                <asp:GridView ID="SalesGridView" runat="server" Font-Size="Small" DataKeyNames="Id" EmptyDataText="No Sales Order" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" AllowPaging="true" CellSpacing="1" OnRowDeleting="SalesGridView_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ImageUrl="~/Sales/img/delete.png" OnClientClick="return confirm('Are You Sure Delete This Order')" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                                        <asp:BoundField DataField="Item" HeaderText="Item" />
                                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                        <asp:BoundField DataField="Total" HeaderText="Total" />
                                    </Columns>
                                </asp:GridView>
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
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblAmount" CssClass="col-md-2 control-label" Font-Bold="true" Text="Total Amount(Tk)" Font-Size="Medium"></asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblDiscount" CssClass="col-md-2 control-label" Font-Bold="true" Text="Discount(Tk)" Font-Size="Medium"></asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="txtDiscount" CssClass="form-control" Font-Bold="true" Font-Size="Medium" Style="text-align: center" ReadOnly="false" AutoPostBack="true" />
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
                            </ContentTemplate>
                        </asp:UpdatePanel>


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
