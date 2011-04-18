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
    /// Interaction logic for ViewCharterRequest.xaml
    /// </summary>
    using DataAccessLayer;
    public partial class ViewCharterRequest : Page
    {
        public ViewCharterRequest()
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
                lblViewCharterRequest.Content = "No Charter Request data found.";
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
                lblViewCharterRequest.Content = Convert.ToString(count) + " Requests" + ext + " found.";
                //SearchDriverDataGrid.AutoGenerateColumns = true;
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[0]).Binding = new Binding("Id");
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[1]).Binding = new Binding("CustomerId");
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[2]).Binding = new Binding("Description");
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[3]).Binding = new Binding("PassengerNum");

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

        private void AcceptRequest_click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            OurSitDb OurSitSchema1 = new OurSitDb();
            OurSitDb OurSitSchema2 = new OurSitDb();
            OurSitDb OurSitSchema3 = new OurSitDb();
            DataRowView rowBeingSelected = SearchCharterDataGrid.CurrentItem as DataRowView;
            //int CurrentRowIndex = SearchRentalDataGrid.Items.If
            int Id = Convert.ToInt32(rowBeingSelected[0]);
            string Message = txtReason.Text;

            if (OurSitSchema.UpdateCharterRequest(Id, 1, Message))
            {
                //int CustomerId,int DriverId,string VehicleId, int PassengerNum, float Cost, DateTime DispatchTime, DateTime ReturnTime, string DispatchLocation
                if (OurSitSchema1.AddCharter(Convert.ToInt32(rowBeingSelected[1]),0 ,string.Empty,Convert.ToInt32(rowBeingSelected[3]),0,DateTime.MaxValue,DateTime.MaxValue,string.Empty))
                {
                    if (OurSitSchema2.DeleteCharterRequest(Id))
                    {
                        btnViewCharter_Click(sender, e);
                        MessageBox.Show("Customer Charter Request Accepted.", "Success!");
                    }
                }
                else
                {
                    OurSitSchema3.UpdateRentalRequest(Id, 0, Message);
                }
            }
        }

        private void CancelRequest_click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            DataRowView rowBeingSelected = SearchCharterDataGrid.CurrentItem as DataRowView;
            string Message = txtReason.Text;
            int Id = Convert.ToInt32(rowBeingSelected[0]);
            if (OurSitSchema.UpdateRentalRequest(Id, 2, Message))
            {
                rowBeingSelected[4] = "Cancelled";
                rowBeingSelected[5] = Message;
                MessageBox.Show("Customer Charter Request Cancelled.", "Success!");
            }
        }
    }
}
