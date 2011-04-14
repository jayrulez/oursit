<%@ Page Title="" Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Deliveries.aspx.cs" Inherits="Customer_Deliveries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" Runat="Server">Deliveries</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageSubHeaderTitle" Runat="Server">
    <h2>Deliveries</h2>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="grid_8 first">
    <div class="columns">
        <div class="grid_8 first">
            <div class="form panel clearfix">
                <div><h2>Complete the form below to make a Delivery Request</h2></div>
                <div class="form-response">
                    <asp:Label ID="lblFormResponse" runat="server" Text=""></asp:Label></div>
                <hr />
                <fieldset>
                    <div class="clearfix">
                        <label>From Location</label><asp:TextBox ID="txtFromLocation" runat="server"></asp:TextBox>
                    </div>
                    <div class="clearfix">
                        <label>Destination</label><asp:TextBox ID="txtDestination" runat="server"></asp:TextBox>
                    </div>
                    <div class="clearfix">
                        <label>Dispatch time</label><asp:TextBox ID="txtDispatchTime" runat="server"></asp:TextBox>
                    </div>
                    <div class="clearfix">
                        <label>Estimated arrival time</label><asp:TextBox ID="txtArrivalTime" runat="server"></asp:TextBox>
                    </div>
                    <div class="clearfix">
                        <label>Item Quantity</label><asp:TextBox ID="txtItemQuantity" runat="server"></asp:TextBox>
                    </div>
                    <div class="clearfix">
                        <label>Description</label><asp:TextBox ID="txtDescription" TextMode="MultiLine" Columns="90" Rows="5" runat="server"></asp:TextBox>
                    </div>
                </fieldset>
                <hr />
                <asp:Button  class="button button-green" ID="btnSubmitMakeDeliveryRequest" 
                    runat="server" Text="Make Delivery Request" 
                    onclick="btnSubmitMakeDeliveryRequest_Click" />
            </div>
        </div>
    </div>
    <div class="columns leading">
        <div class="grid_8 first">
            <div class="panel">
                <div><h2>Pending Delivery requests</h2></div>
                <div class="requests">
                <% if (WebUser.GetInstance().DeliveryRequests.Count > 0)
                   { %>
                <% foreach (Model.DeliveryRequest deliveryRequest in WebUser.GetInstance().DeliveryRequests)
                   { %>
                        <div class="request">
                            <div>Description: <%= deliveryRequest.Description%></div>
                            <div>Item Quantity: <%= deliveryRequest.ItemQuantity%></div>
                            <div>From Location: <%= deliveryRequest.FromLocation%></div>
                            <div>Destination: <%= deliveryRequest.Destination%></div>
                            <div>Dispatch Time: <%= deliveryRequest.DispatchTime.ToString()%></div>
                            <div>Expected Arrival Time: <%= deliveryRequest.ArrivalTime.ToString() %></div>
                            <% if(deliveryRequest.Status == 2) { %>
                                <div class="">
                                    Delivery request rejected
                                    <% if (deliveryRequest.Message != null && deliveryRequest.Message.Length > 0)
                                       { %>
                                    <br />
                                    Reason: <%=deliveryRequest.Message%>
                                    <% } %>
                                </div>
                            <% } %>
                        </div>
                <% } %>
                <% }
                   else
                   { %>
                   <div class="message">No delivery requests</div>
                <%} %>
                </div>
            </div>
        </div>
    </div>
    <div class="columns leading">
        <div class="grid_8 first">
            <div class="panel">
                <div><h2>All Deliveries</h2></div>
                <div class="trips">
                <% if (WebUser.GetInstance().Deliveries.Count > 0)
                   { %>
                <% foreach (Model.Delivery delivery in WebUser.GetInstance().Deliveries)
                   { %>
                        <div class="delivery">
                            <div>Item Quantity: <%= delivery.ItemQuantity%></div>
                            <div>From Location: <%= delivery.FromLocation%></div>
                            <div>Destination: <%= delivery.Destination%></div>
                            <div>Dispatch Time: <%= delivery.DispatchTime.ToString()%></div>
                            <div>Expected Arrival Time: <%= delivery.ArrivalTime.ToString() %></div>
                            <div>Cost: <%= delivery.Cost%></div>
                            <div>Driver: <%= delivery.Driver.FirstName + " " + delivery.Driver.LastName %></div>
                        </div>
                <% } %>
                <% }
                   else
                   { %>
                   <div class="message">No deliveries.</div>
                <%} %>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>