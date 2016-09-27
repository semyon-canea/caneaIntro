<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="User.UI._Default" EnableEventValidation="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>users</title>
    <link rel="stylesheet" type="text/css" href="./Content/bootstrap.min.css" />
</head>
<body>
    <div class="container">
        <form runat="server" id="userSelect">
            <div class="row">
                <div class="col-lg-1">Username</div>
                <div class="col-lg-1">FirstName</div>
                <div class="col-lg-1">LastName</div>
                <div class="col-lg-1">IsActive</div>
                <div class="col-lg-1">Phone</div>
                <div class="col-lg-1">Email</div>
            </div>

            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="row">
                        <div class="col-lg-1"><%# Eval("UserName") %></div>
                        <div class="col-lg-1"><%# Eval("FirstName") %></div>
                        <div class="col-lg-1"><%# Eval("LastName") %></div>
                        <div class="col-lg-1">
                            <input type="checkbox" <%# (bool)Eval("IsActive") ? "checked":"" %> disabled="disabled" />
                        </div>
                        <div class="col-lg-1"><%# Eval("ContactInformation.Phone") %></div>
                        <div class="col-lg-2"><%# Eval("ContactInformation.Email") %></div>

                        <div class="col-lg-1">
                            <asp:Button runat="server" OnClick="editUser_OnServerClick" Text="Edit" CommandArgument='<%#Eval("Id")%>'></asp:Button>
                            <asp:Button runat="server" OnClick="deleteUser_OnServerClick" Text="Delete" CommandArgument='<%#Eval("Id")%>'></asp:Button>
                        </div>

                    </div>
                </ItemTemplate>


            </asp:Repeater>
            <div class="row">
                <asp:Button runat="server" OnClick="newUser_OnServerClick" Text="New user"></asp:Button>

            </div>
            <%if (SelectedUser != null)
                { %>
            <div class="js-UserContainer">
                <div class="row">
                    <div class="col-lg-2">
                        <div class="row">
                            <label for="userName">Username</label>
                        </div>
                        <div class="row">
                            <label for="firstName">FirstName</label>
                        </div>
                        <div class="row">
                            <label for="lastName">LastName</label>
                        </div>
                        <div class="row">
                            <label for="isActive">IsActive</label>
                        </div>
                        <div class="row">
                            <label for="Phone">Phone</label>
                        </div>
                        <div class="row">
                            <label for="Email">Email</label>
                        </div>
                    </div>
                    <div class="col-lg-2">
                        <div class="row">
                            <asp:HiddenField runat="server" ID="UserId"></asp:HiddenField>
                        </div>
                        <div class="row">
                            <asp:TextBox runat="server" Rows="1" ID="userName"></asp:TextBox>
                        </div>
                        <div class="row">
                            <asp:TextBox runat="server" Rows="1" ID="firstName"></asp:TextBox>
                        </div>
                        <div class="row">
                            <asp:TextBox runat="server" Rows="1" ID="lastName"></asp:TextBox>

                        </div>
                        <div class="row">
                            <asp:CheckBox runat="server" ID="isActive"></asp:CheckBox>

                        </div>
                        <div class="row">
                            <asp:TextBox runat="server" Rows="1" ID="phone"></asp:TextBox>
                        </div>
                        <div class="row">
                            <asp:TextBox runat="server" Rows="1" ID="email"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-2">
                        <asp:Button runat="server" OnClick="saveUser_OnServerClick" Text="Save"></asp:Button>
                    </div>
                    <div class="col-lg-2">
                        <asp:Button runat="server" OnClick="cancel_OnServerClick" Text="Cancel"></asp:Button>
                    </div>
                </div>
            </div>
            <% } %>
        </form>

    </div>
</body>
</html>
