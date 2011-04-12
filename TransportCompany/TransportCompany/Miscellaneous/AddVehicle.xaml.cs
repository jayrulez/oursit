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
    /// Interaction logic for AddVehicle.xaml
    /// </summary>
    using DataAccessLayer;
    public partial class AddVehicle : Page
    {
        public AddVehicle()
        {
            InitializeComponent();
        }

        private void btnAddDriver_Click(object sender, RoutedEventArgs e)
        {
            string VIN = txtVIN.Text.Trim();
            string Make = txtMake.Text.Trim();
            string Model = txtModel.Text.Trim();
            string Color = txtColor.Text.Trim();
            string Condition = txtCondition.Text.Trim();
            string ServiceType=""; 
            if((bool)rbtnTypeCharter.IsChecked)
            {
                ServiceType = "charter";          
            }
            else if ((bool)rbtnTypeDelivery.IsChecked)
            {
                ServiceType = "delivery";
            }
            else if ((bool)rbtnTypeRental.IsChecked)
            {
                ServiceType = "Rental";
            }

            string SeatingCapacity = txtSeatingCapacity.Text.Trim();
            int ParsedSeatingCapacity;
            if (!string.IsNullOrEmpty(Make) && !string.IsNullOrEmpty(Model) && !string.IsNullOrEmpty(Color) && !string.IsNullOrEmpty(ServiceType) && !string.IsNullOrEmpty(SeatingCapacity)  && !string.IsNullOrEmpty(Condition))
            {
                if (Int32.TryParse(SeatingCapacity, out ParsedSeatingCapacity))
                {
                    OurSitDb OurSitSchema = new OurSitDb();
                    MessageBoxResult Result;
                    if (OurSitSchema.AddVehicle(VIN,Make,Model,Color,Condition,ServiceType,ParsedSeatingCapacity))
                    {
                        Result = MessageBox.Show("Vehicle was added successfully.");
                    }
                    else
                    {
                        lblAddVehicleStatus.Content = "Vehicle data was not added.";
                    }
                }
            }
            else
            {
                lblAddVehicleStatus.Content = "All fields must contain data";
            }
        }

        private void btnClearField_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
