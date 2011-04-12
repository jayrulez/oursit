using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Data;
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
    /// Interaction logic for SearchDriver.xaml
    /// </summary>
    using DataAccessLayer;
    public partial class SearchDriver : Page
    {
        DataRowView rowBeingEdited = null;
        string CurrentColumnHeader;
        string CurrentColumnData;
        int CurrentColumnIndex;
        public SearchDriver()
        {
            InitializeComponent();
        }

        private void btnSearchDriver_Click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            DataTable DriverResult = OurSitSchema.SearchDriver(txtId.Text.Trim(),txtNis.Text.Trim(),txtTrn.Text.Trim());
            if (DriverResult == null)
            {
                lblSearchStatus.Content = "No Driver data found.";
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
                lblSearchStatus.Content = Convert.ToString(count) + " Driver" + ext + " found.";
                //SearchDriverDataGrid.AutoGenerateColumns = true;
                ((DataGridTextColumn)SearchDriverDataGrid.Columns[0]).Binding = new Binding("Id");
                ((DataGridTextColumn)SearchDriverDataGrid.Columns[1]).Binding = new Binding("FirstName");
                ((DataGridTextColumn)SearchDriverDataGrid.Columns[2]).Binding = new Binding("LastName");
                ((DataGridTextColumn)SearchDriverDataGrid.Columns[3]).Binding = new Binding("TRN");
                ((DataGridTextColumn)SearchDriverDataGrid.Columns[4]).Binding = new Binding("NIS");
                ((DataGridTextColumn)SearchDriverDataGrid.Columns[5]).Binding = new Binding("District");
                ((DataGridTextColumn)SearchDriverDataGrid.Columns[6]).Binding = new Binding("Parish");
                ((DataGridTextColumn)SearchDriverDataGrid.Columns[7]).Binding = new Binding("ContactNumber");
                
                SearchDriverDataGrid.AutoGenerateColumns = false;
                SearchDriverDataGrid.ItemsSource = DriverResult.DefaultView;
            }
        }

        private void btnClearFields_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchDriverDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataRowView rowView = e.Row.Item as DataRowView;
            rowBeingEdited = rowView;
        }

        private void SearchDriverDataGrid_CurrentCellChanged(object sender, EventArgs e)
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
        private void SearchDriverDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            CurrentColumnHeader = SearchDriverDataGrid.CurrentColumn.Header.ToString();
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
