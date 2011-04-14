<%@ Page Title="" Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Inquiries.aspx.cs" Inherits="Customer_Inquiries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" Runat="Server">Inquiries</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageSubHeaderTitle" Runat="Server">
<h2>Inquiries</h2>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="grid_8 first">
    <div class="columns">
        <div class="grid_8 first">
            <div class="form panel clearfix">
                <div><h2>Complete the form below to make an Inquiry</h2></div>
                <div class="form-response">
                    <asp:Label ID="lblFormResponse" runat="server" Text=""></asp:Label></div>
                <hr />
                <fieldset>
                    <div class="clearfix">
                        <label>Subject/Title</label><asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
                    </div>
                    <div class="clearfix">
                        <label>Description</label><asp:TextBox ID="txtBody" TextMode="MultiLine" Columns="90" Rows="5" runat="server"></asp:TextBox>
                    </div>
                </fieldset>
                <hr />
                <asp:Button  class="button button-green" ID="btnSubmitMakeInquiry" 
                    runat="server" Text="Make Inquiry" onclick="btnSubmitMakeInquiry_Click" />
            </div>
        </div>
    </div>
    <div class="columns leading">
        <div class="grid_8 first">
            <div class="panel">
                <div><h2>All Inquiries</h2></div>
                <div class="inquiries">
                <% if (WebUser.GetInstance().Inquiries.Count > 0)
                   { %>
                <% foreach (Model.Inquiry inquiry in WebUser.GetInstance().Inquiries)
                   { %>
                        <div class="inquiry">
                            <div><%= inquiry.Subject %></div>
                            <div><%= inquiry.Body %></div>
                            <% if(inquiry.InquiryFeedbacks.Count > 0) { %>
                            <div class="inquiry-feedbacks">
                            <% foreach(Model.InquiryFeedback feedback in inquiry.InquiryFeedbacks) { %>
                                <div class="inquiry-feedback">
                                    <div><%= feedback.Body %></div>
                                    <div><%= feedback.CreatedAt.ToString() %></div>
                                </div>
                            <% } %>
                            </div>
                            <% } %>
                        </div>
                <% } %>
                <% }else{ %>
                    No Inquiries made yet.
                <% } %>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>

