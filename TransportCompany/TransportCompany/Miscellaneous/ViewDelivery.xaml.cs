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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TransportCompany.Miscellaneous
{
    /// <summary>
    /// Interaction logic for ViewDelivery.xaml
    /// </summary>
    public partial class ViewDelivery : Page
    {
        public ViewDelivery()
        {
            InitializeComponent();
        }
        private void btnViewDelivery_Click(object sender, RoutedEventArgs e)
        {
        }
        private void chbxViewAll_Checked(object sender, RoutedEventArgs e)
        {
            txtCustomerId.IsEnabled = false;
        }

        private void chbxViewAll_UnChecked(object sender, RoutedEventArgs e)
        {
            txtCustomerId.IsEnabled = true;
        }
    }
}
