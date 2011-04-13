using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for SecurePage
/// </summary>
public class SecurePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!WebUser.IsLoggedIn())
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}