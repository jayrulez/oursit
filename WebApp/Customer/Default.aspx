<%@ Page Title="" Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Customer_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" Runat="Server">Dashboard</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageSubHeaderTitle" Runat="Server">
<h2>Dashboard</h2>
</asp:Content>
<asp:Content ID="MainContentPlaceHolderContent" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="grid_8 first">
    <div class="columns">
        <div class="grid_8 first">
            <div class="panel clearfix">
                <div><h2>Account Activity and History</h2></div>
                <div class="inquiries">
                    <p>Totol Inquiries: <a id="linkCustomerHistoryInquiries" runat="server" href="~/Customer/Inquiries.aspx"><%= WebUser.GetInstance().Inquiries.Count %></a></p>
                </div>
                <div class="trips">
                    <p>Total Trip Requests: <a id="A1" runat="server" href="~/Customer/Trips.aspx"><%= WebUser.GetInstance().TripRequests.Count %></a></p>
                    <p>Total Trips: <a id="A2" runat="server" href="~/Customer/Trips.aspx"><%= WebUser.GetInstance().Trips.Count %></a></p>
                </div>
                <div class="deliveries">
                    <p>Total Delivery Requests: <a id="A3" runat="server" href="~/Customer/Deliveries.aspx"><%= WebUser.GetInstance().DeliveryRequests.Count %></a></p>
                    <p>Total Deliveries: <a id="A4" runat="server" href="~/Customer/Deliveries.aspx"><%= WebUser.GetInstance().Deliveries.Count %></a></p>
                </div>
                <div class="rentals">
                    <p>Total Rental Requests: <a id="A5" runat="server" href="~/Customer/Rentals.aspx"><%= WebUser.GetInstance().RentalRequests.Count %></a></p>
                    <p>Total Rentals: <a id="A6" runat="server" href="~/Customer/Rentals.aspx"><%= WebUser.GetInstance().Rentals.Count %></a></p>
                </div>
            </div>
        </div>
    </div>

</div>
</asp:Content>

