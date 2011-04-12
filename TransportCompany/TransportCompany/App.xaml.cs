using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Collections;
using System.Text.RegularExpressions;

namespace TransportCompany
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            string LocalConnectionString = @"Data Source=SYNC-PC\SQLEXPRESS;Initial Catalog=oursitdb;Integrated Security=SSPI";
            Application.Current.Properties["LocalConnectionString"] = LocalConnectionString;
        }
        public static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("0-9"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }
    }
}
