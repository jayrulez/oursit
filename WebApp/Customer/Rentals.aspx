<%@ Page Title="" Language="C#" MasterPageFile="~/Common.master" AutoEventWireup="true" CodeFile="Rentals.aspx.cs" Inherits="Customer_Rentals" %>

<asp:Content ID="Content5" ContentPlaceHolderID="PageSubHeaderTitle" Runat="Server">
<h2>Rentals</h2>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="grid_8 first">
    <div class="columns">
        <div class="grid_8 first">
            <div class="form panel clearfix">
                <div><h2>Complete the form below to make an Rental Request</h2></div>
                <div class="form-response">
                    <asp:Label ID="lblFormResponse" runat="server" Text=""></asp:Label></div>
                
                <div class="">
                    <h2>Selected Vehicle</h2>
                        <div class="selected-vehicle-details">
                                Vin: <asp:Label ID="lblVin" runat="server" Text=""></asp:Label>
                                <br />
                                Make: <asp:Label ID="lblMake" runat="server" Text=""></asp:Label>
                                <br />
                                Model: <asp:Label ID="lblModel" runat="server" Text=""></asp:Label>
                                <br />
                                Color: <asp:Label ID="lblColor" runat="server" Text=""></asp:Label>
                                <br />
                                Condition: <asp:Label ID="lblCondition" runat="server" Text=""></asp:Label>
                                <br />
                                Seating Capacity: <asp:Label ID="lblSeatingCapacity" runat="server" Text=""></asp:Label>
                        </div>
                </div>
                <hr />
                <fieldset>
                    <div class="clearfix">
                        <asp:EntityDataSource ID="VehicleEntityDataSource" runat="server" 
                            ConnectionString="name=Entities" DefaultContainerName="Entities" 
                            EnableFlattening="False" EntitySetName="Vehicles" 
                            
                            Select="it.[VIN], it.[Make], it.[Color], it.[Model], it.[Condition], it.[ServiceType], it.[SeatingCapacity]">
                        </asp:EntityDataSource>
                        <label>Vehicle</label><asp:DropDownList ID="ddlVehicleList" 
                            runat="server" AutoPostBack="True" DataSourceID="VehicleEntityDataSource" 
                            DataTextField="VIN" DataValueField="VIN" 
                            onselectedindexchanged="ddlVehicleList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="clearfix">
                        <label>Description</label><asp:TextBox ID="txtDescription" TextMode="MultiLine" Columns="90" Rows="5" runat="server"></asp:TextBox>
                    </div>
                </fieldset>
                <hr />
                <asp:Button  class="button button-green" ID="btnSubmitMakeRentalRequest" 
                    runat="server" Text="Make Rental Request" 
                    onclick="btnSubmitMakeRentalRequest_Click" />
            </div>
        </div>
    </div>
    <div class="columns leading">
        <div class="grid_8 first">
            <div class="panel">
                <div><h2>Pending rental requests</h2></div>
                <div class="rental-requests">
                <% if (WebUser.GetInstance().RentalRequests.Count > 0)
                   { %>
                <% foreach (Model.RentalRequest rentalRequest in WebUser.GetInstance().RentalRequests)
                   { %>
                        <div class="rental-request">
                            <div>
                                Vehicle
                                <br />
                                Vin: <%= rentalRequest.Vehicle.VIN%>
                                <br />
                                Make: <%= rentalRequest.Vehicle.Make%>
                                <br />
                                Model: <%= rentalRequest.Vehicle.Model%>
                                <br />
                                Color: <%= rentalRequest.Vehicle.Color%>
                                <br />
                                Condition: <%= rentalRequest.Vehicle.Condition%>
                                <br />
                                Seating Capacity: <%= rentalRequest.Vehicle.SeatingCapacity%>
                            </div>
                            <div>Description: <%= rentalRequest.Description%></div>
                            <% if(rentalRequest.Status == 2) { %>
                                <div class="">
                                    Rental request rejected
                                    <% if (rentalRequest.Message != null && rentalRequest.Message.Length > 0)
                                       { %>
                                    <br />
                                    Reason: <%=rentalRequest.Message%>
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
                <div><h2>All Rentals</h2></div>
                <div class="rentals">
                <% if (WebUser.GetInstance().Rentals.Count > 0)
                   { %>
                <% foreach (Model.Rental rental in WebUser.GetInstance().Rentals)
                   { %>
                        <div class="rental">
                            <div>Cost: <%= rental.Cost%></div>
                            <div>Rental Date: <%= rental.RentalDate.ToString() %></div>
                            <div>Return Date: <%= rental.RentalDate.ToString() %></div>
                            <div>
                                Vehicle
                                <br />
                                Vin: <%= rental.Vehicle.VIN%>
                                <br />
                                Make: <%= rental.Vehicle.Make%>
                                <br />
                                Model: <%= rental.Vehicle.Model%>
                                <br />
                                Color: <%= rental.Vehicle.Color%>
                                <br />
                                Condition: <%= rental.Vehicle.Condition%>
                                <br />
                                Seating Capacity: <%= rental.Vehicle.SeatingCapacity%>
                            </div>
                        </div>
                <% } %>
                <% }
                   else
                   { %>
                   <div class="message">No rental requests.</div>
                <%} %>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>

