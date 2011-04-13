using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

public partial class CreateAccount : GuestPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //base.Page_Load(sender, e);
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Entities dbContext = new Entities();

        Customer customer = new Customer();
        customer.FirstName = txtFirstName.Text;
        customer.LastName = txtLastName.Text;
        customer.EmailAddress = txtLastName.Text;
        customer.Password = WebUser.HashPassword(txtPassword.Text);
        customer.CreatedAt = DateTime.Now;

        dbContext.Customers.AddObject(customer);

        dbContext.SaveChanges();

        WebUser.Login(customer.EmailAddress, customer.Password);

        // temporary
        Response.Redirect("~/Customer/Default.aspx");

    }
}