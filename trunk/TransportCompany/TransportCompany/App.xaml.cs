using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace TransportCompany
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            string LocalConnectionString = @"Data Source=.\SQLEXPRESS;Database=oursitdb.mdf;Integrated Security=True;User Instance=True;";
            Application.Current.Properties["LocalConnectionString"] = LocalConnectionString;
        }
    }
}
