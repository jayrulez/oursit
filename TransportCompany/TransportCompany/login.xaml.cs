using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Media;
namespace TransportCompany
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    using DataAccessLayer;
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void MenuExit_click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OurSitDb OurSitSchema = new OurSitDb();
            DataTable LoginDetail = new DataTable();
            string UserName = txtUsername.Text.Trim() ;
            string Password = txtPassword.Password;
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                LoginDetail = OurSitSchema.GetOperatorByUsername(UserName);
                if (LoginDetail.Rows.Count == 1)
                {
                    string Id = LoginDetail.Rows[0][0].ToString();
                    string ActualUsername = LoginDetail.Rows[0][1].ToString();
                    string ActualPassword = LoginDetail.Rows[0][2].ToString();
                    string UserType = LoginDetail.Rows[0][3].ToString();
                    if (string.Compare(Password, ActualPassword, false) == 0)
                    {
                        //MessageBox.Show("pw: " + ActualPassword + " username: " + ActualUsername + " user type: " + UserType);
                        Application.Current.Properties["Username"] = ActualUsername;
                        Application.Current.Properties["UserType"] = UserType;
                        Main MainWindow = new Main();
                        MainWindow.Show();
                        Close();
                    }
                    else
                    {
                        lblLoginStatus.Content = "Username or Password is incorrect.";
                    }
                }
                else
                {
                    lblLoginStatus.Content = "Username or Password is incorrect.";
                }
            }
            else
            {
                lblLoginStatus.Content = string.Empty;
            }
        }
    }
}
