using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

public partial class Operator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Entities dbContext = new Entities();
            Model.Operator op = new Model.Operator();
            op.Username = "admin";
            op.Password = "pass";
            op.Type = "admin";
            dbContext.Operators.AddObject(op);
            dbContext.SaveChanges();
            Response.Write(op.Id.ToString());
        }catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}