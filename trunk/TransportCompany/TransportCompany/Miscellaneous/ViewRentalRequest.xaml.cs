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
    /// Interaction logic for ViewRentalRequest.xaml
    /// </summary>
    using DataAccessLayer;
    public partial class ViewRentalRequest : Page
    {
        //DataRowView rowBeingSelected = null;
        //string CurrentColumnHeader;
       // string CurrentColumnData;
        //int CurrentColumnIndex;
        
        public ViewRentalRequest()
        {
            InitializeComponent();
        }

        private void btnViewRental_Click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            DataTable RequestResult;
            if ((bool)chbxViewAll.IsChecked)
            {
                RequestResult = OurSitSchema.SearchRentalRequest(string.Empty);
            }
            else
            {
                RequestResult = OurSitSchema.SearchRentalRequest(txtCustomerId.Text.Trim());
            }
            if (RequestResult == null)
            {
                lblViewRentalRequest.Content = "No Rental Request data found.";
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
                lblViewRentalRequest.Content = Convert.ToString(count) + " Request" + ext + " found.";
                //SearchDriverDataGrid.AutoGenerateColumns = true;
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[0]).Binding = new Binding("Id");
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[1]).Binding = new Binding("CustomerId");
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[2]).Binding = new Binding("VehicleId");
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[3]).Binding = new Binding("Description");
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[4]).Binding = new Binding("Status");
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[5]).Binding = new Binding("Message");
                
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

        private void AcceptRequest_click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            OurSitDb OurSitSchema1 = new OurSitDb();
            OurSitDb OurSitSchema2 = new OurSitDb();
            OurSitDb OurSitSchema3 = new OurSitDb();
            DataRowView rowBeingSelected = SearchRentalDataGrid.CurrentItem as DataRowView;
            //int CurrentRowIndex = SearchRentalDataGrid.Items.If

            if (rowBeingSelected != null)
            {
                int Id = Convert.ToInt32(rowBeingSelected[0]);
                string Message = txtReason.Text;
                if (OurSitSchema.UpdateRentalRequest(Id, 1, Message))
                {
                    if (OurSitSchema1.AddRental(Convert.ToInt32(rowBeingSelected[1]), Convert.ToString(rowBeingSelected[2]), DateTime.Now, DateTime.MaxValue, 0))
                    {
                        if (OurSitSchema2.DeleteRentalRequest(Id))
                        {
                            btnViewRental_Click(sender, e);
                            MessageBox.Show("Vehicle Rental Request Accepted.", "Success!");
                        }
                    }
                    else
                    {
                        OurSitSchema3.UpdateRentalRequest(Id, 0, Message);
                    }
                }
            }
        }

        private void CancelRequest_click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            DataRowView rowBeingSelected = SearchRentalDataGrid.CurrentItem as DataRowView;
            if (rowBeingSelected != null)
            {
                string Message = txtReason.Text;
                int Id = Convert.ToInt32(rowBeingSelected[0]);
                if (OurSitSchema.UpdateRentalRequest(Id, 2, Message))
                {
                    rowBeingSelected[4] = "Cancelled";
                    rowBeingSelected[5] = Message;
                    MessageBox.Show("Vehicle Rental Request Cancelled.", "Success!");
                }
            }
        }
    }
}
