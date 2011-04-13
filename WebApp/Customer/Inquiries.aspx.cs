using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

public partial class Customer_Inquiries : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!WebUser.IsLoggedIn())
        {
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void btnSubmitMakeInquiry_Click(object sender, EventArgs e)
    {
        try
        {
            Entities dbContext = new Entities();

            Inquiry inquiry = new Inquiry();
            inquiry.CustomerId = WebUser.GetInstance().Id;
            inquiry.Subject = txtSubject.Text;
            inquiry.Body = txtBody.Text;
            inquiry.CreatedAt = DateTime.Now;

            dbContext.Inquiries.AddObject(inquiry);

            dbContext.SaveChanges();

            lblFormResponse.Text = "Your inquiry was submitted. An operator will provide feedback as soon as possible.";

        }catch(Exception ex)
        {
            lblFormResponse.Text = ex.Message;
        }
    }
}