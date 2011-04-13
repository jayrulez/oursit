using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for GuestPage
/// </summary>
public class GuestPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebUser.IsLoggedIn())
        {
            Response.Redirect("~/Customer/Default.aspx");
        }
    }
}