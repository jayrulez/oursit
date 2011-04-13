using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

/// <summary>
/// Summary description for WebUser
/// </summary>
public class WebUser
{
    const string CustomerKey = "customerId";

    protected Customer Instance;

	public WebUser(int customerId)
	{
        Entities dbContext = new Entities();
        this.Instance = dbContext.Customers.Single(c => c.Id == customerId);
	}

    public static Customer GetInstance()
    {
        int userId = HttpContext.Current.Request.Cookies.Get(WebUser.CustomerKey) != null ? Convert.ToInt32(HttpContext.Current.Request.Cookies.Get(WebUser.CustomerKey).Value) : 0;
        WebUser user = new WebUser(userId);
        return user.Instance;
    }

    public bool Validate(string EmailAddress, string Password)
    {
        Entities dbContext = new Entities();
        Customer customer = dbContext.Customers.Single(c => c.EmailAddress == EmailAddress && c.Password == WebUser.HashPassword(Password));
        return customer != null;
    }

    public static string HashPassword(string password)
    {
        return System.Security.Cryptography.MD5.Create(password).ToString();
    }

    public static void Login(string EmailAddress, string Password, bool RememberMe = false)
    {
        Entities dbContext = new Entities();
        Customer customer = dbContext.Customers.Single(c => c.EmailAddress == EmailAddress && c.Password == WebUser.HashPassword(Password));
        if (customer != null)
        {
            HttpCookie cookie = new HttpCookie(WebUser.CustomerKey);
            cookie.Value = customer.Id.ToString();

            if (RememberMe)
            {
                cookie.Expires = DateTime.Now.AddDays(30);
            }
            else {
                cookie.Expires = DateTime.Now.AddHours(1);
            }

            HttpContext.Current.Request.Cookies.Add(cookie);
        }
    }

    public void Logout()
    {
        HttpContext.Current.Request.Cookies.Remove(WebUser.CustomerKey);
    }

    public static bool IsLoggedIn()
    {
        return HttpContext.Current.Request.Cookies.Get(WebUser.CustomerKey) != null;
    }
}