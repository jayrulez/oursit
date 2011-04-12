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
            DataTable CustomerResult = OurSitSchema.GetCustomerById(Convert.ToString(txtId.Text));//OurSitSchema.GetCustomer(Convert.ToString(txtId.Text), Convert.ToString(txtFirstName.Text), Convert.ToString(txtLastName.Text), Convert.ToString(txtEmailAddress.Text));
            if (CustomerResult == null)
            {
                lblSearchStatus.Content = "No customer data found.";
            }
            else
            {
                int count = CustomerResult.Rows.Count;
                string ext;
                if (count > 1)
                {
                    ext = "s";
                }
                else
                {
                    ext = "";
                }
                lblSearchStatus.Content = Convert.ToString(count) + " customer" + ext + " found.";
                //SearchDriverDataGrid.AutoGenerateColumns = true;
                ((DataGridTextColumn)SearchDriverDataGrid.Columns[0]).Binding = new Binding("Id");
                ((DataGridTextColumn)SearchDriverDataGrid.Columns[1]).Binding = new Binding("FirstName");
                ((DataGridTextColumn)SearchDriverDataGrid.Columns[2]).Binding = new Binding("LastName");
                ((DataGridTextColumn)SearchDriverDataGrid.Columns[3]).Binding = new Binding("EmailAddress");
                ((DataGridTextColumn)SearchDriverDataGrid.Columns[4]).Binding = new Binding("ContactNumber");
                ((DataGridTextColumn)SearchDriverDataGrid.Columns[5]).Binding = new Binding("CreatedAt");
                SearchDriverDataGrid.AutoGenerateColumns = false;
                SearchDriverDataGrid.ItemsSource = CustomerResult.DefaultView;
            }
        }

        private void btnClearFields_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchDriverDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //MessageBox.Show("editing " + SearchDriverDataGrid.CurrentColumn.Header.ToString());
            DataRowView rowView = e.Row.Item as DataRowView;
            rowBeingEdited = rowView;
        }

        private void SearchDriverDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (rowBeingEdited != null)
            {
                OurSitDb OurSitSchema = new OurSitDb();
                MessageBoxResult Result;
                if (!string.IsNullOrEmpty(rowBeingEdited[1].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[2].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[3].ToString()) && !string.IsNullOrEmpty(rowBeingEdited[4].ToString()))
                {
                    if (OurSitSchema.UpdateCustomer(Convert.ToInt32(rowBeingEdited[0]), rowBeingEdited[1].ToString(), rowBeingEdited[2].ToString(), rowBeingEdited[3].ToString(), rowBeingEdited[4].ToString()))
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
    }
}
