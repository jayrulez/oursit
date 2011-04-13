<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CreateAccount.aspx.cs" Inherits="CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="bodyClass" Runat="Server"> class="login"</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="login-box">
	<div class="login-hd">Create Account</div>
	<div class="login-box-top">
		<div class="message info">Complete the form below to create your account</div>
		<p>
            <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
			<asp:TextBox ID="txtFirstName" class="full" runat="server"></asp:TextBox>
		</p>
		<p>
            <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
			<asp:TextBox ID="txtLastName" class="full" runat="server"></asp:TextBox>
		</p>
		<p>
            <asp:Label ID="lblEmailAddress" runat="server" Text="Email Address"></asp:Label>
			<asp:TextBox ID="txtEmailAddress" class="full" runat="server"></asp:TextBox>
		</p>
		<p>
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
			<asp:TextBox ID="txtPassword" TextMode="Password" class="full" runat="server"></asp:TextBox>
		</p>
		<p>
            <asp:Label ID="lblContactNumber" runat="server" Text="Contact Number"></asp:Label>
			<asp:TextBox ID="txtContactNumber" class="full" runat="server"></asp:TextBox>
		</p>
		<p class="clearfix">
			<asp:Button ID="btnLogin" runat="server" class="button button-gray fr" Text="Create Account" />
		</p>
		<ul>
			<li>Existing customer?&nbsp;<asp:HyperLink ID="linkCreateAccount" runat="server" NavigateUrl="~/Default.aspx">Login</asp:HyperLink></li>
		</ul>
	</div>
</div>
</asp:Content>

