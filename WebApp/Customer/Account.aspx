<%@ Page Title="" Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Customer_Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" Runat="Server">Account Settings</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageSubHeaderTitle" Runat="Server">
    <h2>Account Settings</h2>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" Runat="Server"><div class="grid_8 first">
    <div class="columns">
        <div class="grid_8 first">
            <div class="form panel clearfix">
                <div><h2>Complete the form below to update your account</h2></div>
                <div class="form-response">
                    <asp:Label ID="lblFormResponse" runat="server" Text=""></asp:Label></div>
                <hr />
                <fieldset>
                    <div class="clearfix">
                        <label>First Name</label><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    </div>
                    <div class="clearfix">
                        <label>Last Name</label><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    </div>
                    <div class="clearfix">
                        <label>Email Address</label><asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox>
                    </div>
                    <div class="clearfix">
                        <label>Password(Leave blank to remain unchanged)</label><asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <div class="clearfix">
                        <label>Contact Number</label><asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox>
                    </div>
                </fieldset>
                <hr />
                <asp:Button  class="button button-green" ID="btnSubmitUpdateAccount" 
                    runat="server" Text="Update Account" 
                    onclick="btnSubmitUpdateAccount_Click" />
            </div>
        </div>
    </div>
</div>
</asp:Content>

