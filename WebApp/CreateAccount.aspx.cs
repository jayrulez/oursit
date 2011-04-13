using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

public partial class CreateAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebUser.IsLoggedIn())
        {
            Response.Redirect("~/Customer/Default.aspx");
        }
    }

    protected void btnSubmitCreateAccount_Click(object sender, EventArgs e)
    {
        try
        {
            Entities dbContext = new Entities();

            Customer customer = new Customer();
            customer.FirstName = txtFirstName.Text;
            customer.LastName = txtLastName.Text;
            customer.EmailAddress = txtEmailAddress.Text;
            customer.Password = WebUser.HashPassword(txtPassword.Text);
            customer.ContactNumber = txtContactNumber.Text;
            customer.CreatedAt = DateTime.Now;

            dbContext.Customers.AddObject(customer);

            dbContext.SaveChanges();

            lblFormResponse.Text = "Your account was sucessfully created. You may <a href=\"" + Request.ApplicationPath.TrimEnd('/') + "/Default.aspx\">login</a> now.";

            // temporary
            //Response.Redirect("~/Default.aspx");
        }
        catch (EntityDataSourceValidationException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {
            lblFormResponse.Text = ex.Message;
        }
    }
}