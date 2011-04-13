using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// Summary description for WebUser
/// </summary>
public class WebUser
{
    const string CustomerKey = "cusId";

    protected Customer Instance;

	public WebUser(int customerId)
	{
        Entities dbContext = new Entities();

        this.Instance = dbContext.Customers.SingleOrDefault(c => c.Id == customerId);
	}

    public static Customer GetInstance()
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[WebUser.CustomerKey];

        int customerId = cookie != null ? Convert.ToInt32(cookie.Value) : 0;
        
        return WebUser.GetCustomerById(customerId);
    }

    public static Customer GetCustomerById(int customerId)
    {
        WebUser customer = new WebUser(customerId);
        return customer.Instance;
    }

    public static Customer GetCustomerByEmailAddress(string EmailAddress)
    {
        Entities dbContext = new Entities();

        Customer customer = dbContext.Customers.SingleOrDefault(c => c.EmailAddress == EmailAddress);

        return customer;
    }

    public static string HashPassword(string password)
    {
        return password.Trim();
    }

    public static void Login(string EmailAddress, string Password, bool RememberMe = false)
    {
        Customer customer = WebUser.GetCustomerByEmailAddress(EmailAddress);

        if (customer != null)
        {
            if (customer.Password == WebUser.HashPassword(Password))
            {
                HttpCookie cookie = new HttpCookie(WebUser.CustomerKey, customer.Id.ToString());

                if (RememberMe)
                {
                    cookie.Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddHours(1);
                }

                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else {
                throw new Exception("Password is incorrect.");
            }
        }
        else {
            throw new Exception("Email address not found.");
        }
    }

    public static void Logout()
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[WebUser.CustomerKey];
        if (cookie != null)
        {
            cookie.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }

    public static bool IsLoggedIn()
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[WebUser.CustomerKey];

        Customer customer = null;

        if(cookie != null)
        {
            customer = WebUser.GetCustomerById(Convert.ToInt32(cookie.Value));
        }

        return customer != null;
    }
}