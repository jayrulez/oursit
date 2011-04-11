using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TransportCompany.Miscellaneous
{
    /// <summary>
    /// Interaction logic for SearchCustomer.xaml
    /// </summary>
    /// 
    using DataAccessLayer;
    public partial class SearchCustomer : Page
    {
        
        public SearchCustomer()
        {
            InitializeComponent();
        }

        private void btnSearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            DataTable CustomerResult = OurSitSchema.GetCustomerById(Convert.ToString(txtId.Text));//OurSitSchema.GetCustomer(Convert.ToString(txtId.Text), Convert.ToString(txtFirstName.Text), Convert.ToString(txtLastName.Text), Convert.ToString(txtEmailAddress.Text));
            if (CustomerResult == null)
            {
                lblSearchStatus.Content = "No customer data found.";
            }
            else
            {
                lblSearchStatus.Content = "";
                //SearchCustomerDataGrid.AutoGenerateColumns = true;
                SearchCustomerDataGrid.ItemsSource = CustomerResult.DefaultView;
            }
        }
    }
}
