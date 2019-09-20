<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="PharmaX.WebApp.Shelf.Setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server" style="height: 100%">
        <br />
        <h4>Shelfs Setup</h4>
        <br />


        <div class="form-horizontal">
            <hr />
            <br />
            <div class="row">
                <div class="col-md-offset-2 col-md-5" style="width: 500px">
                    <div class="card" style="border-top-color:red; border-top-style: solid; border-width: 2px">
                       <div class="card-header" style="background-color:white;text-align:center"><h4>New Shelfs</h4> </div>
                        <div class="card-body card-block">
                            <div class="form-group">
                                <div class="col-md-10 mb-2">
                                    <asp:Label runat="server" ID="lblName" AssociatedControlID="txtName" Font-Size="Medium" CssClass="control-label">Name</asp:Label>
                                    <asp:TextBox runat="server" ID="txtName" CssClass="form-control" Style="text-align: center" Font-Bold="true" Font-Size="Medium" />
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-10 mb-3">
                                    <asp:Label runat="server" ID="lblStoreOfQty" AssociatedControlID="txtStoreOfQty" Font-Size="Medium" CssClass="control-label">Store Of Qty</asp:Label>
                                    <asp:TextBox runat="server" ID="txtStoreOfQty" TextMode="Number" CssClass="form-control" Style="text-align: center" Font-Bold="true" Font-Size="Medium" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <asp:Button runat="server" ID="AddButton" Text="Add" CssClass="btn btn-info" Width="120px" OnClick="AddButton_Click" />

                                    <p class="text-center">
                                        <asp:Label runat="server" ID="lblmsg" CssClass="col-md-2 control-label" Font-Size="Small" ForeColor="Red">* Message</asp:Label>
                                    </p>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-offset-1 col-md-7" style="width: 100%">
                    <div class="card" style="border-top-color: red; border-top-style: solid; border-width: 2px">
                        <div class="card-header" style="background-color:white;text-align:center"><h4>Shelf List</h4> </div>
                        <div class="card-body card-block">
                            <div style="width: 100%; height: 240px; overflow: scroll">
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:GridView ID="ShelfGridView" runat="server" DataKeyNames="Name" EmptyDataText="No Shelfs Available Now" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" CellSpacing="1" OnRowDeleting="ShelfGridView_RowDeleting">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ImageUrl="~/Category/images/delete.png" OnClientClick="return confirm('Are You Sure Delete This Shelfs')" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                                <asp:BoundField DataField="StoreQty" HeaderText="Store Of Qty" />
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
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
