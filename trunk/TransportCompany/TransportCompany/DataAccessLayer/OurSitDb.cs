using System;
using System.Windows;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;


namespace TransportCompany.DataAccessLayer
{
    class OurSitDb
    {
        private SqlConnection oursitdbconnection = new SqlConnection((string)(App.Current.Properties["LocalConnectionString"]));
        public SqlConnection OurSitDbConnection
        {
            get
            {
                return oursitdbconnection;
            }
            set
            {
                oursitdbconnection = value;
            }
        }
        private SqlCommand oursitdbcommand = new SqlCommand();
        public SqlCommand OurSitDbCommand
        {
            get
            {
                return oursitdbcommand;
            }
            set
            {
                oursitdbcommand = value;
            }
        }

        public OurSitDb()
        {
            
        }
        public SqlDataReader GetCustomer(string Id, string FirstName, string LastName, string EmailAddress)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText="sp_SearchCustomer";
            if(String.IsNullOrEmpty(Id))
            {
                oursitdbcommand.Parameters.AddWithValue("@Id",System.DBNull.Value);
            }
            else
            {   
                int ParsedId;
                if(Int32.TryParse(Id, out ParsedId))
                {
                    oursitdbcommand.Parameters.AddWithValue("@Id",ParsedId);
                }
                else
                {
                    throw new FormatException("Customer Id not in the correct Format.");
                }
            }
            if(String.IsNullOrEmpty(FirstName))
            {
                oursitdbcommand.Parameters.AddWithValue("@FirstName",System.DBNull.Value);
            }
            if(String.IsNullOrEmpty(LastName))
            {
                oursitdbcommand.Parameters.AddWithValue("@LastName",System.DBNull.Value);
            }
            if(String.IsNullOrEmpty(EmailAddress))
            {
                oursitdbcommand.Parameters.AddWithValue("@EmailAddress",System.DBNull.Value);
            }
            SqlDataReader GetCustomerReader = null;
            try
            {
                oursitdbcommand.Connection.Open();
                try
                {
                    GetCustomerReader = oursitdbcommand.ExecuteReader();
                }
                catch (Exception)
                {
                    
                }
                oursitdbcommand.Connection.Close();
            }
            catch (Exception)
            {
                
            }
            return GetCustomerReader;
        }

        public DataTable GetCustomerById(string Id)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText = "sp_GetCustomerById";
            int ParsedId;
            Int32.TryParse(Id, out ParsedId);
            oursitdbcommand.Parameters.AddWithValue("@Id", ParsedId);
            SqlDataReader GetCustomerReader = null;
            DataTable CustomerDataTable = new DataTable("Customer");
            MessageBoxResult status;
            try
            {
                oursitdbcommand.Connection = oursitdbconnection;
                oursitdbcommand.Connection.Open();
                status = MessageBox.Show("connection is open");
                try
                {
                    status = MessageBox.Show("Before Reader");
                    GetCustomerReader = oursitdbcommand.ExecuteReader();
                    status = MessageBox.Show("After Reader");
                    if (GetCustomerReader.HasRows)
                    {
                        CustomerDataTable.Load(GetCustomerReader);
                    }
                }
                catch (Exception ex)
                {
                    status = MessageBox.Show(ex.Message + " Stack trace: " + ex.StackTrace + " Target Site: " + ex.TargetSite);
                }
                oursitdbcommand.Connection.Close();
            }
            catch (Exception ex)
            {
                status = MessageBox.Show(ex.Message + " Stack trace: " + ex.StackTrace + " Target Site: " + ex.TargetSite);
            }
            return CustomerDataTable ;
        }
    }
}
