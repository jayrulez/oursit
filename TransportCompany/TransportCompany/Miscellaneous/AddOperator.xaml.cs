using System;
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
    /// Interaction logic for AddOperator.xaml
    /// </summary>
    ///
    using DataAccessLayer;
    public partial class AddOperator : Page
    {
        public AddOperator()
        {
            InitializeComponent();
        }

        private void btnAddOperator_Click(object sender, RoutedEventArgs e)
        {
            string Username = txtUsername.Text;
            string Passowrd = txtPassword.Text;
            MessageBoxResult Result;
            if (!String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Passowrd))
            {
                string Type; 
                string Tag;
                
                if ((bool)chbxAdmin.IsChecked)
                {
                    Type = "admin";
                    Tag = "an";
                }
                else
                {
                    Type = "user";
                    Tag = "an";
                }
                OurSitDb OurSitSchema = new OurSitDb();
                if (OurSitSchema.AddOperator(Username.Trim(), Passowrd.Trim(), Type))
                {
                    lblAddOperatorStatus.Content = "The " + Type + " operator \"" + Username + "\" was added.";
                    Result = MessageBox.Show(Username + " has been added as " + Tag + " " + Type + " operator.","Operator Added!");
                }
                else
                {
                    lblAddOperatorStatus.Content = "Unable to add Operator"+ Username +"."; 
                }
            }
        }
    }
}
