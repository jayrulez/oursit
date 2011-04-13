using System;
using System.Data;
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
    /// Interaction logic for ViewRental.xaml
    /// </summary>
    using DataAccessLayer;
    public partial class ViewRental : Page
    {
        public ViewRental()
        {
            InitializeComponent();
        }
        private void btnViewRental_Click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            DataTable RequestResult;
            if ((bool)chbxViewAll.IsChecked)
            {
                RequestResult = OurSitSchema.SearchRental(string.Empty);
            }
            else
            {
                RequestResult = OurSitSchema.SearchRentalRequest(txtCustomerId.Text.Trim());
            }
            if (RequestResult == null)
            {
                lblViewRentalRequest.Content = "No Rental data found.";
            }
            else
            {
                int count = RequestResult.Rows.Count;
                string ext;
                if (count > 1)
                {
                    ext = "s";
                }
                else
                {
                    ext = "";
                }
                lblViewRentalRequest.Content = Convert.ToString(count) + " Rental" + ext + " found.";
                //SearchDriverDataGrid.AutoGenerateColumns = true;
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[0]).Binding = new Binding("Id");
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[1]).Binding = new Binding("CustomerId");
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[2]).Binding = new Binding("VehicleId");
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[3]).Binding = new Binding("RentalDate");
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[3]).Binding = new Binding("ReturnDate");
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[3]).Binding = new Binding("Cost");

                SearchRentalDataGrid.AutoGenerateColumns = false;
                SearchRentalDataGrid.ItemsSource = RequestResult.DefaultView;
            }
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
