using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebUser.IsLoggedIn())
        {
            Response.Redirect("~/Customer/Default.aspx");
        }
    }

    protected void btnSubmitLogin_Click(object sender, EventArgs e)
    {
        try
        {
            WebUser.Login(txtEmailAddress.Text, txtPassword.Text, chkboxRememberMe.Checked);
            Response.Redirect("~/Customer/Default.aspx");
        }catch(Exception ex)
        {
            lblFormResponse.Text = ex.Message;
        }
    }
}