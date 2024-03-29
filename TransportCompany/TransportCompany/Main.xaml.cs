﻿using System;
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
            if (string.Compare(Application.Current.Properties["UserType"].ToString(), "admin",true) == 0)
            {
                AdministrationUltilities.IsEnabled = true;
                AdministrationUltilities.Visibility = Visibility.Visible;   
            }
            else
            {
                AdministrationUltilities.IsEnabled = false;
                AdministrationUltilities.Visibility = Visibility.Hidden; 
            }
            lblLoginStatus.Content = "Logged in as: ";
            lblLoginName.FontSize = 14;
            lblLoginName.FontWeight = FontWeights.SemiBold;
            lblLoginName.FontFamily = new FontFamily("Comic Sans MS");
            lblLoginName.Content = Application.Current.Properties["Username"].ToString();
            MainContentFrame.Source = new Uri("./Miscellaneous/Start.xaml", UriKind.Relative);
        }

        private void MenuExit_click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void MenuLogout_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["Username"] = string.Empty;
            Application.Current.Properties["UserType"] = string.Empty;
            login LoginWindow = new login();
            LoginWindow.Show();
            Close();
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
            MainContentFrame.Source = new Uri("./Miscellaneous/InquiryReview.xaml", UriKind.Relative);
        }
        public void selected_RentalRequest(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Source = new Uri("./Miscellaneous/ViewRentalRequest.xaml", UriKind.Relative);
        }
        public void selected_AddOperator(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Source = new Uri("./Miscellaneous/AddOperator.xaml", UriKind.Relative);

        }
        public void selected_DeliveryRequest(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Source = new Uri("./Miscellaneous/ViewDeliveryRequest.xaml", UriKind.Relative);
        }
        public void selected_CharterRequest(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Source = new Uri("./Miscellaneous/ViewCharterRequest.xaml", UriKind.Relative);
        }
        public void selected_ViewDelivery(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Source = new Uri("./Miscellaneous/ViewDelivery.xaml", UriKind.Relative);
        }
        public void selected_ViewRental(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Source = new Uri("./Miscellaneous/ViewRental.xaml", UriKind.Relative);
        }
        public void selected_ViewCharter(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Source = new Uri("./Miscellaneous/ViewCharter.xaml", UriKind.Relative);
        }

    }
}
