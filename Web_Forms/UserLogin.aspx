<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="login">
        <h1 class="login-header">Club Reports</h1>
        <div id="divLogin" runat="server">
            <b>Username:</b>
            <asp:TextBox ID="txtUsername" CssClass="login-textbox object-default" Width="60%" runat="server"></asp:TextBox>
            <br />
            <b>Password:</b>
            <asp:TextBox ID="txtPassword" CssClass="login-textbox object-default" Width="60%" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click"></asp:Button>
            <br />
            <asp:Label ID="errorLabel" runat="server" ForeColor="#ff3300"></asp:Label>
        </div>
        <div id="divNewPassword" runat="server" visible="false">
            <b>New Password:</b>
            <asp:TextBox ID="txtNewPassword" runat="server" Width="60%" CssClass="login-textbox object-default" TextMode="Password"></asp:TextBox>
            <br />
            <b>Confirm Password:</b>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="txtConfirmPassword" ToolTip="Compare Password is a REQUIRED field"
                ValidationGroup="NewPassword" Font-Size="Larger" Font-Bold="true" ForeColor="Red">
            </asp:RequiredFieldValidator>
            <asp:TextBox ID="txtConfirmPassword" runat="server" Width="60%" CssClass="login-textbox object-default" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtNewPassword"
                ErrorMessage="Password values does not match! Please try again" ToolTip="Password must be the same" ValidationGroup="NewPassword"
                Font-Size="Larger" Font-Bold="true" ForeColor="Red"></asp:CompareValidator>
            <br />
            <br />
            <asp:Button ID="btnUpdatePassword" runat="server" Text="Update Password" CssClass="btn" OnClick="btnUpdatePassword_Click" ValidationGroup="NewPassword"></asp:Button>
        </div>
    </div>
</asp:Content>

