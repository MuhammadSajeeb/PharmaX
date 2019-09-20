<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="PharmaX.WebApp.Suplier.Setup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server" style="height: 100%">
        <br />
        <h4>Supplier Setup</h4>
        <div class="form-horizontal">
            <hr />
            <div class="row">
                <div class="col-md-offset-2 col-md-6">
                    <div class="card" style="border-top-color: red; border-top-style: solid; border-width: 2px">
                        <div class="card-body card-block">
                            <div class="form-group">
                                <div class="col-md-10 mb-2">
                                    <asp:Label runat="server" ID="lblName" AssociatedControlID="txtName" Font-Size="Medium" CssClass="control-label">Name</asp:Label>
                                    <asp:TextBox runat="server" ID="txtName" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-10 mb-2">
                                    <asp:Label runat="server" ID="lblEmail" AssociatedControlID="txtEmail" Font-Size="Medium" CssClass="control-label">Email</asp:Label>
                                    <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-10 mb-3">
                                    <asp:Label runat="server" ID="lblContact" AssociatedControlID="txtContact" Font-Size="Medium" CssClass="control-label">Contact</asp:Label>
                                    <asp:TextBox runat="server" ID="txtContact" TextMode="Phone" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-10 mb-3">
                                    <asp:Label runat="server" ID="lblAddress" AssociatedControlID="txtAddress" Font-Size="Medium" CssClass="control-label">Address</asp:Label>
                                    <asp:TextBox runat="server" ID="txtAddress" TextMode="MultiLine" CssClass="form-control" Font-Bold="true" Font-Size="Medium" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <asp:Button runat="server" ID="AddButton" Text="Add" CssClass="btn btn-info" Width="120px" OnClick="AddButton_Click"/>
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
