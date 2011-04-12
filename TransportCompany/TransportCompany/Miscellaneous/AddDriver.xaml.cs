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
    /// Interaction logic for AddDriver.xaml
    /// </summary>
    using DataAccessLayer;
    public partial class AddDriver : Page
    {
        public AddDriver()
        {
            InitializeComponent();
        }

        private void btnAddDriver_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = txtFirstName.Text.Trim();
            string LastName = txtLastName.Text.Trim();
            string TRN = txtTrn.Text.Trim();
            string NIS = txtNis.Text.Trim();
            string District = txtDistrictAddress.Text.Trim();
            string Parish = txtParishAddress.Text.Trim();
            string ContactNumber = txtContactNumber.Text.Trim();
            int ParsedTRN;
            if(!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(TRN) && !string.IsNullOrEmpty(NIS) && !string.IsNullOrEmpty(District) && !string.IsNullOrEmpty(Parish) && !string.IsNullOrEmpty(ContactNumber))
            {
                if(Int32.TryParse(TRN,out ParsedTRN))
                {
                    OurSitDb OurSitSchema = new OurSitDb();
                    MessageBoxResult Result;
                    if (OurSitSchema.AddDriver(FirstName,LastName,NIS,ParsedTRN,District,Parish,ContactNumber))
                    {
                        Result = MessageBox.Show(FirstName + " " + LastName + " was added successfully.");
                    }
                    else
                    {
                        lblAddDriverStatus.Content = "Driver data was not added.";
                    }
                }
            }
            else
            {
                lblAddDriverStatus.Content = "All fields must contain data";
            }
        }
        private void btnClearField_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
