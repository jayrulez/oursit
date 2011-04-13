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
    /// Interaction logic for ViewCharter.xaml
    /// </summary>
    using DataAccessLayer;
    public partial class ViewCharter : Page
    {
        public ViewCharter()
        {
            InitializeComponent();
        }
        private void btnViewCharter_Click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            DataTable RequestResult;
            if ((bool)chbxViewAll.IsChecked)
            {
                RequestResult = OurSitSchema.SearchCharterRequest(string.Empty);
            }
            else
            {
                RequestResult = OurSitSchema.SearchCharterRequest(txtCustomerId.Text.Trim());
            }
            if (RequestResult == null)
            {
                lblViewCharterRequest.Content = "No Customer Charter data found.";
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
                lblViewCharterRequest.Content = Convert.ToString(count) + " Customer Charter" + ext + " found.";
                //SearchDriverDataGrid.AutoGenerateColumns = true;
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[0]).Binding = new Binding("Id");
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[1]).Binding = new Binding("CustomerId");
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[3]).Binding = new Binding("DriverId");
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[3]).Binding = new Binding("PassengerNum");
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[3]).Binding = new Binding("Cost");
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[3]).Binding = new Binding("DispatchTime");
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[3]).Binding = new Binding("DispatchLocation");
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[3]).Binding = new Binding("ReturnTime");

                SearchCharterDataGrid.AutoGenerateColumns = false;
                SearchCharterDataGrid.ItemsSource = RequestResult.DefaultView;
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
