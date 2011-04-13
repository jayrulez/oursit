using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

public partial class Customer_Trips : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!WebUser.IsLoggedIn())
        {
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void btnSubmitMakeTripRequest_Click(object sender, EventArgs e)
    {
        try
        {
            Entities dbContext = new Entities();

            TripRequest tripRequest = new TripRequest();
            int pNum;
            bool pNumIsNum = int.TryParse(txtPassengerNum.Text, out pNum);
            tripRequest.CustomerId = WebUser.GetInstance().Id;

            if (pNumIsNum)
            {
                tripRequest.PassengerNum = pNum;
            }
            else {
                throw new Exception("Number of passengers should be a valid integer.");
            }

            tripRequest.Description = txtDescription.Text;

            dbContext.TripRequests.AddObject(tripRequest);

            dbContext.SaveChanges();

            lblFormResponse.Text = "Your trip request was submitted. Your trip will appear in your Trips List when accepted by an operator.";

        }
        catch (Exception ex)
        {
            lblFormResponse.Text = ex.Message;
        }
    }
}