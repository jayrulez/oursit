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
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[7]).Binding = new Binding("DispatchTime");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[8]).Binding = new Binding("ArrivalTime");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[9]).Binding = new Binding("Status");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[10]).Binding = new Binding("Message");

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

        private void AcceptRequest_click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            OurSitDb OurSitSchema1 = new OurSitDb();
            OurSitDb OurSitSchema2 = new OurSitDb();
            OurSitDb OurSitSchema3 = new OurSitDb();
            DataRowView rowBeingSelected = SearchDeliveryDataGrid.CurrentItem as DataRowView;
            //int CurrentRowIndex = SearchRentalDataGrid.Items.If
            int Id = Convert.ToInt32(rowBeingSelected[0]);
            string Message = txtReason.Text;

            if (OurSitSchema.UpdateDeliveryRequest(Id, 1, Message))
            {
                //int CustomerId, int DriverId, string VehicleId, string ItemDimension, int ItemQuantity, string FromLocation, string Destination,float Cost, DateTime DispatchTime, DateTime ArrivalTime, DateTime ReturnTime)
                if (OurSitSchema1.AddDelivery(Convert.ToInt32(rowBeingSelected[1]),1,"99091",Convert.ToString(rowBeingSelected[3]),Convert.ToInt32(rowBeingSelected[4]),Convert.ToString(rowBeingSelected[5]),Convert.ToString(rowBeingSelected[6]),0,Convert.ToDateTime(rowBeingSelected[7]),Convert.ToDateTime(rowBeingSelected[8]),DateTime.MaxValue))
                {
                    if (OurSitSchema2.DeleteDeliveryRequest(Id))
                    {
                        btnViewDelivery_Click(sender, e);
                        MessageBox.Show("Customer Delivery Request Accepted.", "Success!");
                    }
                }
                else
                {
                    rowBeingSelected[9] = "Pending";
                    OurSitSchema3.UpdateDeliveryRequest(Id, 0, Message);
                }
            }
        }

        private void CancelRequest_click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            DataRowView rowBeingSelected = SearchDeliveryDataGrid.CurrentItem as DataRowView;
            string Message = txtReason.Text;
            int Id = Convert.ToInt32(rowBeingSelected[0]);
            if (OurSitSchema.UpdateDeliveryRequest(Id, 2, Message))
            {
                rowBeingSelected[9] = "Cancelled";
                rowBeingSelected[10] = Message;
                MessageBox.Show("Customer Delivery Request Cancelled.", "Success!");
            }
        }
    }
}
