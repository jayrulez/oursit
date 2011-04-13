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
    /// Interaction logic for ViewDeliveryRequest.xaml
    /// </summary>
    using DataAccessLayer;
    public partial class ViewDeliveryRequest : Page
    {
        public ViewDeliveryRequest()
        {
            InitializeComponent();
        }

        private void btnViewDelivery_Click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            DataTable RequestResult;
            if ((bool)chbxViewAll.IsChecked)
            {
                RequestResult = OurSitSchema.SearchDeliveryRequest(string.Empty);
            }
            else
            {
                RequestResult = OurSitSchema.SearchDeliveryRequest(txtCustomerId.Text.Trim());
            }
            if (RequestResult == null)
            {
                lblViewDeliveryRequest.Content = "No Delivery Request data found.";
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
                lblViewDeliveryRequest.Content = Convert.ToString(count) + " Requests" + ext + " found.";
                //SearchDriverDataGrid.AutoGenerateColumns = true;
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[0]).Binding = new Binding("Id");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[1]).Binding = new Binding("CustomerId");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[2]).Binding = new Binding("Description");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[3]).Binding = new Binding("ItemDemension");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[4]).Binding = new Binding("ItemQuantity");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[5]).Binding = new Binding("FromLocation");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[6]).Binding = new Binding("Destination");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[6]).Binding = new Binding("Cost");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[7]).Binding = new Binding("DispatchTime");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[8]).Binding = new Binding("ArrivalTime");

                SearchDeliveryDataGrid.AutoGenerateColumns = false;
                SearchDeliveryDataGrid.ItemsSource = RequestResult.DefaultView;
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
