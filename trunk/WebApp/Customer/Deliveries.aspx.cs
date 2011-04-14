using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

public partial class Customer_Deliveries : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!WebUser.IsLoggedIn())
        {
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void btnSubmitMakeDeliveryRequest_Click(object sender, EventArgs e)
    {
        try
        {
            Entities dbContext = new Entities();
            DeliveryRequest deliveryRequest = new DeliveryRequest();
            deliveryRequest.CustomerId = WebUser.GetInstance().Id;
            deliveryRequest.Description = txtDescription.Text;
            int iq;
            bool iqIsInt = int.TryParse(txtItemQuantity.Text, out iq);
            if(iqIsInt)
            {
                deliveryRequest.ItemQuantity = iq;
            }else{
                throw new Exception("Item Quantity must be a valid integer");
            }
            deliveryRequest.FromLocation = txtFromLocation.Text;
            deliveryRequest.Destination = txtDestination.Text;

            DateTime dt;
            DateTime at;

            bool isDT = DateTime.TryParse(txtDispatchTime.Text, out dt);

            if(isDT)
            {
                deliveryRequest.DispatchTime = dt;
            }else{
                throw new Exception("Dispatch time must be a valid date time value.");
            }

            isDT = DateTime.TryParse(txtDispatchTime.Text, out at);

            if (isDT)
            {
                deliveryRequest.ArrivalTime = at;
            }
            else
            {
                throw new Exception("Arrival time must be a valid date time value.");
            }

            deliveryRequest.Status = 0;

            dbContext.DeliveryRequests.AddObject(deliveryRequest);

            dbContext.SaveChanges();

            lblFormResponse.Text = "Your delivery request was submitted. Your delivery will appear in your Deliveries List when accepted by an operator.";

        }
        catch (Exception ex)
        {
            lblFormResponse.Text = ex.Message;
        }
    }
}