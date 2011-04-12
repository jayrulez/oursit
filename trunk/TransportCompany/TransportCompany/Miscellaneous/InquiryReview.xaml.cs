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
    /// Interaction logic for ViewInquire.xaml
    /// </summary>
    using DataAccessLayer;
    public partial class InquiryReview : Page
    {
        public InquiryReview()
        {
            InitializeComponent();
        }

        private void btnViewInquiry_Click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            DataTable InquiryResult = OurSitSchema.SearchInquiry(txtCustomerId.Text.Trim(),txtInquiryDate.Text.Trim());
            if (InquiryResult == null)
            {
                lblViewInquiryStatus.Content = "No Inquiry data found.";
            }
            else
            {
                int count = InquiryResult.Rows.Count;
                string ext;
                if (count > 1)
                {
                    ext = "s";
                }
                else
                {
                    ext = "";
                }
                lblViewInquiryStatus.Content = Convert.ToString(count) + " Inquiry" + ext + " found.";
                //SearchInquiryDataGrid.AutoGenerateColumns = true;
                ((DataGridTextColumn)SearchInquiryDataGrid.Columns[0]).Binding = new Binding("Id");
                ((DataGridTextColumn)SearchInquiryDataGrid.Columns[1]).Binding = new Binding("CustomerId");
                ((DataGridTextColumn)SearchInquiryDataGrid.Columns[2]).Binding = new Binding("Suject");
                ((DataGridTextColumn)SearchInquiryDataGrid.Columns[3]).Binding = new Binding("Body");
                ((DataGridTextColumn)SearchInquiryDataGrid.Columns[4]).Binding = new Binding("CreatedAt");

                SearchInquiryDataGrid.AutoGenerateColumns = false;
                SearchInquiryDataGrid.ItemsSource = InquiryResult.DefaultView;
            }
        }
        private void SearchInquiryDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
 
        }
    }
}
