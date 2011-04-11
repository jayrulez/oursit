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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    using DataAccessLayer;
    public partial class AddCustomer : Page
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = txtFirstName.Text;
            string LastName = txtLastName.Text;
            string EmailAddress = txtEmailAddress.Text;
            string ContactNumber = txtContactNumber.Text;
            string Password = "pass123";
            OurSitDb OurSitSchema = new OurSitDb();
            MessageBoxResult Result;
            if (OurSitSchema.AddCustomer(FirstName, LastName, EmailAddress, Password, ContactNumber))
            {
                Result = MessageBox.Show(FirstName + " " + LastName + " was added successfully.");
            }
            else
            {
                lblAddCustomerStatus.Content = "Customer data was not added.";
            }
        }
    }
}
