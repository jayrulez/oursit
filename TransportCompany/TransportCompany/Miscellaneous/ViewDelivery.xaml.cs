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
    /// Interaction logic for ViewDelivery.xaml
    /// </summary>
    using DataAccessLayer;
    public partial class ViewDelivery : Page
    {
        DataRowView rowBeingEdited = null;
        string CurrentColumnHeader;
        string CurrentColumnData;
        int CurrentColumnIndex;
        public ViewDelivery()
        {
            InitializeComponent();
        }
        private void btnViewDelivery_Click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            DataTable RequestResult;
            if ((bool)chbxViewAll.IsChecked)
            {
                RequestResult = OurSitSchema.SearchDelivery(string.Empty);
            }
            else
            {
                RequestResult = OurSitSchema.SearchDeliveryRequest(txtCustomerId.Text.Trim());
            }
            if (RequestResult == null)
            {
                lblViewDeliveryRequest.Content = "No Customer Delivery data found.";
            }
            else
            {
                int count = RequestResult.Rows.Count;
                string ext;
                if (count > 1)
                {
                    ext = "Deliveries";
                }
                else
                {
                    ext = "Delivery";
                }
                lblViewDeliveryRequest.Content = Convert.ToString(count) + " Customer " + ext + " found.";
                //SearchDeliveryDataGrid.AutoGenerateColumns = true;
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[0]).Binding = new Binding("Id");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[1]).Binding = new Binding("CustomerId");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[2]).Binding = new Binding("DriverId");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[3]).Binding = new Binding("VehicleId");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[4]).Binding = new Binding("ItemDemension");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[5]).Binding = new Binding("ItemQuantity");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[6]).Binding = new Binding("FromLocation");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[7]).Binding = new Binding("Destination");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[8]).Binding = new Binding("Cost");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[9]).Binding = new Binding("DispatchTime");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[10]).Binding = new Binding("ArrivalTime");
                ((DataGridTextColumn)SearchDeliveryDataGrid.Columns[11]).Binding = new Binding("ReturnTime");

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

        private void SearchDeliveryDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataRowView rowView = e.Row.Item as DataRowView;
            rowBeingEdited = rowView;
        }

        private void SearchDeliveryDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (rowBeingEdited != null)
            {
                OurSitDb OurSitSchema = new OurSitDb();
                MessageBoxResult Result;
                if (!string.IsNullOrEmpty(rowBeingEdited[1].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[2].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[3].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[6].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[7].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[8].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[9].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[10].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[11].ToString()))
                {
                    //int Id ,int CustomerId, int DriverId, string VehicleId, string ItemDimension, int ItemQuantity, string FromLocation, string Destination, float Cost, DateTime DispatchTime, DateTime ArrivalTime, DateTime ReturnTime
                    if (OurSitSchema.UpdateDelivery(Convert.ToInt32(rowBeingEdited[0]), Convert.ToInt32(rowBeingEdited[1]), Convert.ToInt32(rowBeingEdited[2]), rowBeingEdited[3].ToString(), Convert.ToString(rowBeingEdited[4]), Convert.ToInt32(rowBeingEdited[5]), rowBeingEdited[6].ToString(), rowBeingEdited[7].ToString(), (float)rowBeingEdited[8], Convert.ToDateTime(rowBeingEdited[9]), Convert.ToDateTime(rowBeingEdited[10]), Convert.ToDateTime(rowBeingEdited[11])))
                    {
                    }
                }
                else
                {
                    rowBeingEdited.CancelEdit();
                    Result = MessageBox.Show("\"" + CurrentColumnHeader + "\"" + " must contain data.");
                    rowBeingEdited[CurrentColumnIndex] = CurrentColumnData;
                }
                rowBeingEdited.EndEdit();
            }
        }

        private void SearchDeliveryDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            CurrentColumnHeader = SearchDeliveryDataGrid.CurrentColumn.Header.ToString();
            DataRowView rowView = e.Row.Item as DataRowView;
            CurrentColumnIndex = e.Column.DisplayIndex;
            CurrentColumnData = rowView[CurrentColumnIndex].ToString();
        }

    }
}
