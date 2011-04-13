<%@ Page Title="" Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Trips.aspx.cs" Inherits="Customer_Trips" %>

<asp:Content ID="Content5" ContentPlaceHolderID="PageSubHeaderTitle" Runat="Server">
<h2>Trips</h2>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="grid_8 first">
    <div class="columns">
        <div class="grid_8 first">
            <div class="form panel clearfix">
                <div><h2>Complete the form below to make an Trip Request</h2></div>
                <div class="form-response">
                    <asp:Label ID="lblFormResponse" runat="server" Text=""></asp:Label></div>
                <hr />
                <fieldset>
                    <div class="clearfix">
                        <label>Number of passengers</label><asp:TextBox ID="txtPassengerNum" runat="server"></asp:TextBox>
                    </div>
                    <div class="clearfix">
                        <label>Description</label><asp:TextBox ID="txtDescription" TextMode="MultiLine" Columns="90" Rows="5" runat="server"></asp:TextBox>
                    </div>
                </fieldset>
                <hr />
                <asp:Button  class="button button-green" ID="btnSubmitMakeTripRequest" 
                    runat="server" Text="Make Trip Request" 
                    onclick="btnSubmitMakeTripRequest_Click" />
            </div>
        </div>
    </div>
    <div class="columns leading">
        <div class="grid_8 first">
            <div class="panel">
                <div><h2>Pending trip requests</h2></div>
                <div class="trip-requests">
                <% if (WebUser.GetInstance().TripRequests.Count > 0)
                   { %>
                <% foreach (Model.TripRequest tripRequest in WebUser.GetInstance().TripRequests)
                   { %>
                        <div class="trip-request">
                            <div>Number of passengers: <%= tripRequest.PassengerNum%></div>
                            <div>Description: <%= tripRequest.Description%></div>
                            <% if(tripRequest.Status == 2) { %>
                                <div class="">
                                    Trip request rejected
                                    <% if (tripRequest.Message != null && tripRequest.Message.Length > 0)
                                       { %>
                                    <br />
                                    Reason: <%=tripRequest.Message%>
                                    <% } %>
                                </div>
                            <% } %>
                        </div>
                <% } %>
                <% }
                   else
                   { %>
                   <div class="message">No pending trip requests</div>
                <%} %>
                </div>
            </div>
        </div>
    </div>
    <div class="columns leading">
        <div class="grid_8 first">
            <div class="panel">
                <div><h2>All Trips</h2></div>
                <div class="trips">
                <% if (WebUser.GetInstance().Trips.Count > 0)
                   { %>
                <% foreach (Model.Trip trip in WebUser.GetInstance().Trips)
                   { %>
                        <div class="trip">
                            <div>Cost: <%= trip.Cost%></div>
                            <div>Number of passengers: <%= trip.PassengerNum%></div>
                            <div>Description: <%= trip.Driver.FirstName + " " + trip.Driver.LastName %></div>
                            <div>Dispatch Time: <%= trip.DispatchTime.ToString() %></div>  
                            <div>Return Time: <%= trip.ReturnTime.ToString() %></div>                          
                            <div>Dispatch From Location: <%= trip.DispatchLocation %></div>
                            <% if(trip.TripDestinations.Count > 0) { %>
                            <div class="trip-destinations">
                                <div>Trip Destinations</div>
                            <% foreach(Model.TripDestination tripDestination in trip.TripDestinations) { %>
                                <div class="trip-destination">
                                    <div>Destination Name: <%= tripDestination.DestinationName %></div>
                                    <div>Destination Address: <%= tripDestination.DestinationAddress %></div>
                                </div>
                            <% } %>
                            </div>
                            <% } %>
                        </div>
                <% } %>
                <% }
                   else
                   { %>
                   <div class="message">No trips.</div>
                <%} %>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>

