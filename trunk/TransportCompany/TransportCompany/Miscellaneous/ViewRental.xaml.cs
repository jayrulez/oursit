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
        DataRowView rowBeingEdited = null;
        string CurrentColumnHeader;
        string CurrentColumnData;
        int CurrentColumnIndex;
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
                RequestResult = OurSitSchema.SearchRental(txtCustomerId.Text.Trim());
            }
            if (RequestResult == null)
            {
                lblViewRentalRequest.Content = "No Customer Rental data found.";
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
                lblViewRentalRequest.Content = Convert.ToString(count) + " Customer Rental" + ext + " found.";
                //SearchDriverDataGrid.AutoGenerateColumns = true;
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[0]).Binding = new Binding("Id");
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[1]).Binding = new Binding("CustomerId");
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[2]).Binding = new Binding("VehicleId");
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[3]).Binding = new Binding("RentalDate");
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[4]).Binding = new Binding("ReturnDate");
                ((DataGridTextColumn)SearchRentalDataGrid.Columns[5]).Binding = new Binding("Cost");

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
        private void SearchRentalDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataRowView rowView = e.Row.Item as DataRowView;
            rowBeingEdited = rowView;
        }

        private void SearchRentalDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (rowBeingEdited != null)
            {
                OurSitDb OurSitSchema = new OurSitDb();
                MessageBoxResult Result;
                if (!string.IsNullOrEmpty(rowBeingEdited[1].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[2].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[3].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[4].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[5].ToString()))
                {
                    //int Id ,int CustomerId, int DriverId, string VehicleId, string ItemDimension, int ItemQuantity, string FromLocation, string Destination, float Cost, DateTime DispatchTime, DateTime ArrivalTime, DateTime ReturnTime
                    if (OurSitSchema.UpdateRental(Convert.ToInt32(rowBeingEdited[0]), Convert.ToInt32(rowBeingEdited[1]), Convert.ToString(rowBeingEdited[2]), Convert.ToDateTime(rowBeingEdited[3]), Convert.ToDateTime(rowBeingEdited[4]), (float)(rowBeingEdited[5])))
                    {
                    }
                    else
                    {
                        rowBeingEdited.CancelEdit();
                        if (CurrentColumnIndex == 4)
                        {
                            rowBeingEdited[CurrentColumnIndex] = Convert.ToDateTime(CurrentColumnData);
                        }
                        else
                        {
                            rowBeingEdited[CurrentColumnIndex] = CurrentColumnData;
                        }
                    }
                }
                else
                {
                    rowBeingEdited.CancelEdit();
                    Result = MessageBox.Show("\"" + CurrentColumnHeader + "\"" + " must contain data.");
                    if (CurrentColumnIndex == 4)
                    {
                        rowBeingEdited[CurrentColumnIndex] = Convert.ToDateTime(CurrentColumnData);
                    }
                    else
                    {
                        rowBeingEdited[CurrentColumnIndex] = CurrentColumnData;
                    }
                }
                rowBeingEdited.EndEdit();
            }
        }

        private void SearchRentalDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            CurrentColumnHeader = SearchRentalDataGrid.CurrentColumn.Header.ToString();
            DataRowView rowView = e.Row.Item as DataRowView;
            CurrentColumnIndex = e.Column.DisplayIndex;
            CurrentColumnData = rowView[CurrentColumnIndex].ToString();
        }
    }
}
