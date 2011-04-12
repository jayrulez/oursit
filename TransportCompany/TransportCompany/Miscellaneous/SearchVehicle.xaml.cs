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
    /// Interaction logic for SearchVehicle.xaml
    /// </summary>
    using DataAccessLayer;
    public partial class SearchVehicle : Page
    {
        DataRowView rowBeingEdited = null;
        string CurrentColumnHeader;
        string CurrentColumnData;
        int CurrentColumnIndex;
        public SearchVehicle()
        {
            InitializeComponent();
        }

        private void btnSearchVehicle_Click(object sender, RoutedEventArgs e)
        {
            string ServiceType = "";
            if ((bool)rbtnTypeCharter.IsChecked)
            {
                ServiceType = "charter";
            }
            else if ((bool)rbtnTypeDelivery.IsChecked)
            {
                ServiceType = "delivery";
            }
            else if ((bool)rbtnTypeRental.IsChecked)
            {
                ServiceType = "rental";
            }
            else if ((bool)rbtnTypeAll.IsChecked)
            {
                ServiceType = "all";
            }

            OurSitDb OurSitSchema = new OurSitDb();
            DataTable DriverResult = OurSitSchema.SearchVehicle(txtVIN.Text.Trim(),ServiceType.Trim(),txtSeatingCapacity.Text.Trim());
            if (DriverResult == null)
            {
                lblSearchVehicleStatus.Content = "No Driver data found.";
            }
            else
            {
                int count = DriverResult.Rows.Count;
                string ext;
                if (count > 1)
                {
                    ext = "s";
                }
                else
                {
                    ext = "";
                }
                lblSearchVehicleStatus.Content = Convert.ToString(count) + " Driver" + ext + " found.";
                //SearchVehicleDataGrid.AutoGenerateColumns = true;
                ((DataGridTextColumn)SearchVehicleDataGrid.Columns[0]).Binding = new Binding("Id");
                ((DataGridTextColumn)SearchVehicleDataGrid.Columns[1]).Binding = new Binding("FirstName");
                ((DataGridTextColumn)SearchVehicleDataGrid.Columns[2]).Binding = new Binding("LastName");
                ((DataGridTextColumn)SearchVehicleDataGrid.Columns[3]).Binding = new Binding("TRN");
                ((DataGridTextColumn)SearchVehicleDataGrid.Columns[4]).Binding = new Binding("NIS");
                ((DataGridTextColumn)SearchVehicleDataGrid.Columns[5]).Binding = new Binding("District");
                ((DataGridTextColumn)SearchVehicleDataGrid.Columns[6]).Binding = new Binding("Parish");
                ((DataGridTextColumn)SearchVehicleDataGrid.Columns[7]).Binding = new Binding("ContactNumber");
                
                SearchVehicleDataGrid.AutoGenerateColumns = false;
                SearchVehicleDataGrid.ItemsSource = DriverResult.DefaultView;
            }
        }

        private void btnClearFields_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchVehicleDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataRowView rowView = e.Row.Item as DataRowView;
            rowBeingEdited = rowView;
        }

        private void SearchVehicleDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (rowBeingEdited != null)
            {
                OurSitDb OurSitSchema = new OurSitDb();
                MessageBoxResult Result;
                if (!string.IsNullOrEmpty(rowBeingEdited[1].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[2].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[3].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[4].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[5].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[6].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[7].ToString()))
                {
                    if (OurSitSchema.UpdateDriver(Convert.ToInt32(rowBeingEdited[0]), rowBeingEdited[1].ToString(), rowBeingEdited[2].ToString(), rowBeingEdited[4].ToString(), Convert.ToInt32(rowBeingEdited[3]), rowBeingEdited[5].ToString(), rowBeingEdited[6].ToString(), rowBeingEdited[7].ToString()))
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

        private void SearchVehicleDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            CurrentColumnHeader = SearchVehicleDataGrid.CurrentColumn.Header.ToString();
            DataRowView rowView = e.Row.Item as DataRowView;
            CurrentColumnIndex = e.Column.DisplayIndex;
            CurrentColumnData = rowView[CurrentColumnIndex].ToString();

        }

        private void SearchCustomerForm_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !App.IsTextAllowed(e.Text);
        }
    }
}
