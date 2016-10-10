<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="User.UI._Default" EnableEventValidation="false" %>

<%@ Register TagPrefix="canea" Namespace="Canea.Common.UI.WebForms.Controls.Grid" Assembly="Common.UI.WebForms, Version=2016.4.1.0, Culture=neutral, PublicKeyToken=6abc62cd8037b24b" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2016.2.607.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="canea" Namespace="Canea.Common.UI.WebForms.Controls" Assembly="Common.UI.WebForms, Version=2016.4.1.0, Culture=neutral, PublicKeyToken=6abc62cd8037b24b" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>users</title>
    <link rel="stylesheet" type="text/css" href="./Content/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="./Content/userEdit.css" />
</head>
<body>
    <div class="content">
        <form runat="server" id="userSelect">

            <div class="container row-padding">
                <div class="row ">
                    <asp:Button runat="server" ID="newUser" OnClick="newUser_OnServerClick" Text="New user" CssClass="btn btn-default"></asp:Button>
                </div>
            </div>
            <div class="container">
                <div class="row">
                    <telerik:RadScriptManager runat="server" ID="sm"></telerik:RadScriptManager>
                    <telerik:RadSkinManager ID="SkinManager" runat="server" ShowChooser="False" Skin="Bootstrap"></telerik:RadSkinManager>
                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="userGrid">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="userGrid" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                                    <telerik:AjaxUpdatedControl ControlID="userEdit" LoadingPanelID="RadAjaxLoadingPanel2"></telerik:AjaxUpdatedControl>
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                            <telerik:AjaxSetting AjaxControlID="saveUser">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="userGrid" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                                    <telerik:AjaxUpdatedControl ControlID="userEdit" LoadingPanelID="RadAjaxLoadingPanel2"></telerik:AjaxUpdatedControl>
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                            <telerik:AjaxSetting AjaxControlID="cancelEdit">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="userGrid" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                                    <telerik:AjaxUpdatedControl ControlID="userEdit" LoadingPanelID="RadAjaxLoadingPanel2"></telerik:AjaxUpdatedControl>
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                            <telerik:AjaxSetting AjaxControlID="newUser">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="userGrid" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                                    <telerik:AjaxUpdatedControl ControlID="userEdit" LoadingPanelID="RadAjaxLoadingPanel2"></telerik:AjaxUpdatedControl>
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>
                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
                    <canea:SelectedItemSynchronizer runat="server" TargetControlID="userGrid" TargetDataSource="<%#Model.Users %>" />
                    <canea:DatabindingIsolation runat="server">
                        <Boundary>
                            <canea:CaneaRadGrid runat="server" ID="userGrid" OnNeedDataSource="userGrid_OnNeedDataSource" IdColumnUniqueName="Id" OnDeleteCommand="userGrid_OnDeleteCommand" AllowAutomaticDeletes="True">
                                <MasterTableView AutoGenerateColumns="False" ItemType="User.UI.Logic.UserBO" AllowPaging="True" PageSize="2">
                                    <Columns>
                                        <telerik:GridBoundColumn UniqueName="Id" DataField="Id" HeaderText="" Display="False"></telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn UniqueName="Username" HeaderText="Username">
                                            <ItemStyle></ItemStyle>
                                            <ItemTemplate><%#  Item.Username %></ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn UniqueName="FirstName" DataField="FirstName" HeaderText="First name"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="LastName" DataField="LastName" HeaderText="Last name"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="IsActive" DataField="IsActive" HeaderText="Active"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="Phone" DataField="ContactInformation.Phone" HeaderText="Phone"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="Email" DataField="ContactInformation.Email" HeaderText="Email"></telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn Text="Delete" CommandName="Delete" ButtonType="ImageButton" />
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings EnablePostBackOnRowClick="True">
                                    <Selecting AllowRowSelect="True"></Selecting>
                                </ClientSettings>
                            </canea:CaneaRadGrid>
                        </Boundary>
                    </canea:DatabindingIsolation>
                </div>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server"></telerik:RadAjaxLoadingPanel>
                <asp:Panel ID="userEdit" runat="server" Visible="<%# Model.Users.HasSelectedItem() %>">
                    <div class="row row-padding ">
                        <div class="well container">
                            <div class="row">
                                <div class="col-lg-2">
                                    <div class="form-group ">
                                        <asp:Label runat="server" AssociatedControlID="userName">Username</asp:Label>
                                        <asp:TextBox runat="server" Rows="1" ID="userName" Text="<%# Model.Users.SelectedItem?.Username ?? string.Empty %>"></asp:TextBox>

                                    </div>
                                    <div class="form-group ">
                                        <asp:Label runat="server" AssociatedControlID="firstName">FirstName</asp:Label>
                                        <asp:TextBox runat="server" Rows="1" ID="firstName" Text="<%# Model.Users.SelectedItem?.FirstName ?? string.Empty %>"></asp:TextBox>

                                    </div>
                                    <div class="form-group ">
                                        <asp:Label runat="server" AssociatedControlID="lastName">LastName</asp:Label>
                                        <asp:TextBox runat="server" Rows="1" ID="lastName" Text="<%# Model.Users.SelectedItem?.LastName ?? string.Empty %>"></asp:TextBox>

                                    </div>
                                    <div class="form-group ">
                                        <asp:Label runat="server" AssociatedControlID="isActive">IsActive</asp:Label>
                                        <asp:CheckBox runat="server" ID="isActive" Checked="<%# Model.Users.SelectedItem?.IsActive ?? false %>"></asp:CheckBox>

                                    </div>
                                    <div class="form-group ">
                                        <asp:Label runat="server" AssociatedControlID="phone">Phone</asp:Label>
                                        <asp:TextBox runat="server" Rows="1" ID="phone" Text="<%# Model.Users.SelectedItem?.ContactInformation.Phone ?? string.Empty %>"></asp:TextBox>

                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="email">Email</asp:Label>
                                        <asp:TextBox runat="server" Rows="1" ID="email" Text="<%# Model.Users.SelectedItem?.ContactInformation.Email ?? string.Empty %>"></asp:TextBox>

                                    </div>

                                </div>
                            </div>
                            <div class="row row-padding">
                                <div class="col-lg-12">
                                    <asp:Button runat="server" ID="saveUser" OnClick="saveUser_OnServerClick" Text="Save" CssClass="btn btn-default col-lg-2"></asp:Button>
                                    <asp:Button runat="server" ID="cancelEdit" OnClick="cancel_OnServerClick" Text="Cancel" CssClass="btn btn-danger col-lg-2 col-lg-offset-1"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>

                </asp:Panel>
            </div>
        </form>
    </div>
</body>
</html>
