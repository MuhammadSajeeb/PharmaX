<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="PharmaX.WebApp.Category.Setup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <h4>Category Setup</h4>
        <div class="form-horizontal">
            <hr />
            <br />
            <div class="row">
                <div class="col-md-offset-2 col-md-5" style="width: 500px">
                    <div class="card" style="border-top-color: red; border-top-style: solid; border-width: 2px">
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
                        <div class="card-body card-block">
                            <div style="width: 100%; height: 240px; overflow: scroll">
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:GridView ID="CategoriesGridView" runat="server" DataKeyNames="Code" EmptyDataText="No Categories Available Now" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="10" ForeColor="Black" GridLines="Horizontal" CellSpacing="1" OnRowDeleting="CategoriesGridView_RowDeleting" OnSelectedIndexChanged="CategoriesGridView_SelectedIndexChanged">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ImageUrl="~/Category/img/delete.png" OnClientClick="return confirm('Are You Sure Delete This Category')" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Code" HeaderText="Code" />
                                                <asp:BoundField DataField="Name" HeaderText="Name" />
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
</asp:Content>
