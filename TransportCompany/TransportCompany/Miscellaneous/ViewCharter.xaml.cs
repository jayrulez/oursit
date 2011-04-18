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
        DataRowView rowBeingEdited = null;
        string CurrentColumnHeader;
        string CurrentColumnData;
        int CurrentColumnIndex;
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
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[2]).Binding = new Binding("DriverId");
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[3]).Binding = new Binding("VehicleId");
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[4]).Binding = new Binding("PassengerNum");
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[5]).Binding = new Binding("Cost");
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[6]).Binding = new Binding("DispatchTime");
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[7]).Binding = new Binding("DispatchLocation");
                ((DataGridTextColumn)SearchCharterDataGrid.Columns[8]).Binding = new Binding("ReturnTime");

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
                if (!string.IsNullOrEmpty(rowBeingEdited[1].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[2].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[3].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[5].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[6].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[7].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[8].ToString()))
                {
                    //int Id ,int CustomerId, int DriverId, string VehicleId, string ItemDimension, int ItemQuantity, string FromLocation, string Destination, float Cost, DateTime DispatchTime, DateTime ArrivalTime, DateTime ReturnTime
                    if (OurSitSchema.UpdateCharter(Convert.ToInt32(rowBeingEdited[0]), Convert.ToInt32(rowBeingEdited[1]), Convert.ToInt32(rowBeingEdited[2]), rowBeingEdited[3].ToString(), Convert.ToInt32(rowBeingEdited[4]), Convert.ToDecimal(rowBeingEdited[5]), Convert.ToDateTime(rowBeingEdited[6]), Convert.ToDateTime(rowBeingEdited[8].ToString()), (string)rowBeingEdited[7]))
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
            CurrentColumnHeader = SearchCharterDataGrid.CurrentColumn.Header.ToString();
            DataRowView rowView = e.Row.Item as DataRowView;
            CurrentColumnIndex = e.Column.DisplayIndex;
            CurrentColumnData = rowView[CurrentColumnIndex].ToString();
        }
    }

}
