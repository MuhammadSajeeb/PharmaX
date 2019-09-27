<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PharmaX.WebApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wraper" style="float:center">
                    <div class="card-body card-block">
                        <div class="form-group">
                            <div class="col-md-10 mb-2">
                                <asp:Label runat="server" ID="lblCategoryCode" AssociatedControlID="txtCategoryCode" CssClass="control-label" Text="Category Code"></asp:Label>
                                <asp:TextBox runat="server" ID="txtCategoryCode" CssClass="form-control" ReadOnly="true" Style="text-align: center" Font-Bold="true" Font-Size="Medium" />
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-10 mb-3">
                                <asp:Label runat="server" ID="lblCategoryName" AssociatedControlID="txtCategoryName" CssClass="control-label" Text="Category Name"></asp:Label>
                                <asp:TextBox runat="server" ID="txtCategoryName" CssClass="form-control" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" ID="AddButton" Text="Add" CssClass="btn btn-info" Width="120px"/>

                                <p class="text-center">
                                    <asp:Label runat="server" ID="lblmsg" CssClass="col-md-2 control-label" Font-Size="Small" ForeColor="Red">* Message</asp:Label>
                                </p>

                            </div>
                        </div>
                    </div>
        </div>
    </form>
</body>
</html>
