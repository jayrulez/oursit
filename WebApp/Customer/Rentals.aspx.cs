using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

public partial class Customer_Rentals : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!WebUser.IsLoggedIn())
        {
            Response.Redirect("~/Default.aspx");
        }
        if (!IsPostBack)
        {
            ddlVehicleList.DataBind();
            this.SetSelectedVehicle();
        }
    }

    public void SetSelectedVehicle()
    {
        string VIN = ddlVehicleList.SelectedValue;

        Entities dbContext = new Entities();
        Vehicle vehicle = dbContext.Vehicles.FirstOrDefault(v => v.VIN == VIN);
        if (vehicle != null)
        {
            lblVin.Text = vehicle.VIN;
            lblMake.Text = vehicle.Make;
            lblModel.Text = vehicle.Model;
            lblColor.Text = vehicle.Color;
            lblCondition.Text = vehicle.Condition;
            lblSeatingCapacity.Text = vehicle.SeatingCapacity.ToString();
        }
        else {
            lblFormResponse.Text = "There are no vehicles available for rental at this time.";
        }
    }
    protected void btnSubmitMakeRentalRequest_Click(object sender, EventArgs e)
    {
        try
        {
            Entities dbContext = new Entities();
            RentalRequest rentalRequest = new RentalRequest();
            rentalRequest.CustomerId = WebUser.GetInstance().Id;
            rentalRequest.VehicleId = ddlVehicleList.SelectedValue;
            rentalRequest.Description = txtDescription.Text;
            rentalRequest.Status = 0;

            dbContext.RentalRequests.AddObject(rentalRequest);

            dbContext.SaveChanges();

            lblFormResponse.Text = "Your rental request was submitted. Your rental will appear in your Rentals List when accepted by an operator.";

        }
        catch (Exception ex)
        {
            lblFormResponse.Text = ex.Message;
        }
    }
    protected void ddlVehicleList_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SetSelectedVehicle();
    }
}