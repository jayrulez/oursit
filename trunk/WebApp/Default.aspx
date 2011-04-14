<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" Runat="Server">Login</asp:Content>
<asp:Content ID="MainContentPlaceHolderContent" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="login-box">
	<div class="login-hd">Customer Login</div>
	<div class="login-box-top">
		<div class="message info">Enter your email address and password to login</div>
        <asp:Label ID="lblFormResponse" runat="server" Text=""></asp:Label>
		<p>
			<asp:TextBox ID="txtEmailAddress" class="full" runat="server"></asp:TextBox>
		</p>
		<p>
			<asp:TextBox ID="txtPassword" TextMode="Password" class="full" runat="server"></asp:TextBox>
		</p>
		<p class="clearfix">
			<span class="fl" style="line-height: 23px;">
				<asp:CheckBox ID="chkboxRememberMe" runat="server" Text="Remember me?" />
			</span>
			<asp:Button ID="btnSubmitLogin" runat="server" class="button button-gray fr" 
                Text="Login" onclick="btnSubmitLogin_Click" />
		</p>
		<ul>
			<li><asp:HyperLink ID="linkCreateAccount" runat="server" NavigateUrl="~/CreateAccount.aspx">Create Account</asp:HyperLink></li>
			<li><strong>HELP:</strong>&nbsp;Forgot your password? Contact us by phone or email.</li>
		</ul>
	</div>
</div>
</asp:Content>

