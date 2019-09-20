<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="PharmaX.WebApp.Item.Setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server" style="height: 100%">
        <br />
        <h4>Item Setup</h4>
        <div class="form-horizontal">
            <hr />
            <div class="row">
                <div class="col-md-offset-2 col-md-8" style="width: 100%">
                    <div class="card" style="border-top-color: red; border-top-style: solid; border-width: 2px">
                        <div class="card-body card-block">
                            <div class="form-group">
                                <div class="col-md-10 mb-2">
                                    <asp:Label runat="server" ID="lblCategories" AssociatedControlID="CategoriesDropDownList" CssClass="control-label">Categories</asp:Label>
                                    <asp:DropDownList ID="CategoriesDropDownList" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-10 mb-2">
                                    <asp:Label runat="server" ID="lblShelfs" AssociatedControlID="ShelfsDropDownList" CssClass="control-label">Shelfs</asp:Label>
                                    <asp:DropDownList ID="ShelfsDropDownList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ShelfsDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:Label runat="server" ID="lblStoreQty" CssClass="col-md-2 control-label" Font-Size="Small" ForeColor="Red">* Store Qty</asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-10 mb-2">
                                    <asp:Label runat="server" ID="lblCode" AssociatedControlID="txtCode" Font-Size="Medium" CssClass="control-label">Item Code</asp:Label>
                                    <asp:TextBox runat="server" ID="txtCode" Style="text-align: center" ReadOnly="true" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-10 mb-2">
                                    <asp:Label runat="server" ID="lblName" AssociatedControlID="txtName" Font-Size="Medium" CssClass="control-label">Item Name</asp:Label>
                                    <asp:TextBox runat="server" ID="txtName" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-10 mb-2">
                                    <asp:Label runat="server" ID="lblGenericName" AssociatedControlID="txtGenericName" Font-Size="Medium" CssClass="control-label">Generic Name</asp:Label>
                                    <asp:TextBox runat="server" ID="txtGenericName" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-10 mb-3">
                                    <asp:Label runat="server" ID="lblReorderLevel" AssociatedControlID="txtReorderLevel" Font-Size="Medium" CssClass="control-label">Reorder Level</asp:Label>
                                    <asp:TextBox runat="server" ID="txtReorderLevel" TextMode="Number" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <asp:Button runat="server" ID="AddButton" Text="Add" CssClass="btn btn-info" Width="120px" OnClick="AddButton_Click" />
                                    <asp:Label runat="server" ID="lblmsg" CssClass="col-md-2 control-label" Font-Size="Small" ForeColor="Red">* Message</asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-1 col-md-10">
                                    <a class="nav-link" href="ViewAll.aspx">Back to List</a>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
