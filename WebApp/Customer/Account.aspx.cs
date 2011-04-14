using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

public partial class Customer_Account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!WebUser.IsLoggedIn())
        {
            Response.Redirect("~/Default.aspx");
        }
        
        if(!IsPostBack)
        {
            Customer customer = WebUser.GetInstance();

            txtFirstName.Text = customer.FirstName;
            txtLastName.Text = customer.LastName;
            txtEmailAddress.Text = customer.EmailAddress;
            txtContactNumber.Text = customer.ContactNumber;
        }
    }
    protected void btnSubmitUpdateAccount_Click(object sender, EventArgs e)
    {
        try
        {
            Entities dbContext = new Entities();
            int customerId = WebUser.GetInstance().Id;
            Customer customer = dbContext.Customers.FirstOrDefault(c => c.Id == customerId);
            if(customer == null)
            {
                throw new Exception("Could not locate the current customer account in the database. Try again or contact administrator.");
            }

            customer.FirstName = txtFirstName.Text;
            customer.LastName = txtLastName.Text;
            customer.EmailAddress = txtEmailAddress.Text;
            customer.ContactNumber = txtContactNumber.Text;
            if(txtPassword.Text.Length > 0)
            {
                customer.Password = WebUser.HashPassword(txtPassword.Text);
            }

            dbContext.SaveChanges();

            lblFormResponse.Text = "Your account was sucessfully updated.";
        }catch(Exception ex)
        {
            lblFormResponse.Text = ex.Message;
        }
    }
}