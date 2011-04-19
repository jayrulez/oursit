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
        private void PostFeedback_click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            OurSitDb OurSitSchema1 = new OurSitDb();
            OurSitDb OurSitSchema2 = new OurSitDb();
            DataRowView rowBeingSelected = SearchInquiryDataGrid.CurrentItem as DataRowView;
            //int CurrentRowIndex = SearchRentalDataGrid.Items.If
            if (rowBeingSelected != null)
            {
                int Id = Convert.ToInt32(rowBeingSelected[0]);
                string Message = txtReason.Text;
                if (!string.IsNullOrEmpty(Message))
                {
                    if (OurSitSchema1.AddInquiryFeedBack(Id, Message))
                    {
                        MessageBox.Show("Inquiry Feedback Posted!", "Success");
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Inquiry Feedback can not be sent with blank body.", "Invalid Operation");
                }
            }
        }
    }
}
