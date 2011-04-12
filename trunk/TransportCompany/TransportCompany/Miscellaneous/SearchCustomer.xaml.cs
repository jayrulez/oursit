using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TransportCompany.Miscellaneous
{
    /// <summary>
    /// Interaction logic for SearchCustomer.xaml
    /// </summary>
    /// 
    using DataAccessLayer;
    public partial class SearchCustomer : Page
    {
        DataRowView rowBeingEdited = null;
        string CurrentColumnHeader;
        string CurrentColumnData;
        int CurrentColumnIndex;
        public SearchCustomer()
        {
            InitializeComponent();
        }

        private void btnSearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            DataTable CustomerResult = OurSitSchema.GetCustomer(txtId.Text.Trim(),txtFirstName.Text.Trim(),txtLastName.Text.Trim(),txtEmailAddress.Text.Trim());//OurSitSchema.GetCustomer(Convert.ToString(txtId.Text), Convert.ToString(txtFirstName.Text), Convert.ToString(txtLastName.Text), Convert.ToString(txtEmailAddress.Text));
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
                //SearchCustomerDataGrid.AutoGenerateColumns = true;
                ((DataGridTextColumn)SearchCustomerDataGrid.Columns[0]).Binding = new Binding("Id");
                ((DataGridTextColumn)SearchCustomerDataGrid.Columns[1]).Binding = new Binding("FirstName");
                ((DataGridTextColumn)SearchCustomerDataGrid.Columns[2]).Binding = new Binding("LastName");
                ((DataGridTextColumn)SearchCustomerDataGrid.Columns[3]).Binding = new Binding("EmailAddress");
                ((DataGridTextColumn)SearchCustomerDataGrid.Columns[4]).Binding = new Binding("ContactNumber");
                ((DataGridTextColumn)SearchCustomerDataGrid.Columns[5]).Binding = new Binding("CreatedAt");
                SearchCustomerDataGrid.AutoGenerateColumns = false;
                SearchCustomerDataGrid.ItemsSource = CustomerResult.DefaultView;
            }
        }
        
        private void SearchCustomerDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //MessageBox.Show("editing " + SearchCustomerDataGrid.CurrentColumn.Header.ToString());
            DataRowView rowView = e.Row.Item as DataRowView;
            rowBeingEdited = rowView;
        }
        
        private void SearchCustomerDataGrid_CurrentCellChanged(object sender, EventArgs e)
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
        private void SearchCustomerDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            CurrentColumnHeader = SearchCustomerDataGrid.CurrentColumn.Header.ToString();
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
