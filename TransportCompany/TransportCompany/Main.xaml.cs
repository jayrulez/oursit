using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TransportCompany
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            if (string.Compare(Application.Current.Properties["UserType"].ToString(), "admin", true) == 0)
            {
                AdministrationUltilities.IsEnabled = true;
                AdministrationUltilities.Visibility = Visibility.Hidden;
               
            }
            else
            {
                AdministrationUltilities.IsEnabled = false;
                AdministrationUltilities.Visibility = Visibility.Hidden; 
            }
        }

        public void selected_AddCustomer(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Source = new Uri("./Miscellaneous/AddCustomer.xaml", UriKind.Relative);
        }

        public void selected_SearchCustomer(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Source = new Uri("./Miscellaneous/SearchCustomer.xaml", UriKind.Relative);
        }

        public void selected_AddDriver(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Source = new Uri("./Miscellaneous/AddDriver.xaml", UriKind.Relative);
        }
        public void selected_SearchDriver(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Source = new Uri("./Miscellaneous/SearchDriver.xaml", UriKind.Relative);
        }

        public void selected_AddVehicle(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Source = new Uri("./Miscellaneous/AddVehicle.xaml", UriKind.Relative);
        }
        public void selected_SearchVehicle(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Source = new Uri("./Miscellaneous/SearchVehicle.xaml", UriKind.Relative);
        }

        public void selected_InquiryReview(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Source = new Uri("./Miscellaneous/AddCustomer.xaml", UriKind.Relative);
        }
        public void selected_RentalRequest(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Source = new Uri("./Miscellaneous/RentalRequest.xaml", UriKind.Relative);
        }
        public void selected_AddOperator(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Source = new Uri("./Miscellaneous/AddOperator.xaml", UriKind.Relative);
        }
    }
}
