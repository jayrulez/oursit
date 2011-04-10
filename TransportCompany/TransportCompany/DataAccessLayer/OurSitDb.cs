using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;


namespace TransportCompany.DataAccessLayer
{
    class OurSitDb
    {
        private SqlConnection oursitdbconnection = new SqlConnection((string)(Application.Current.Properties["LocalConnectionString"]));
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

        public SqlDataReader GetCustomerById(string Id)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText = "exec sp_SearchCustomer";
            int ParsedId;
            Int32.TryParse(Id, out ParsedId);
            oursitdbcommand.Parameters.AddWithValue("@Id", Id);
            SqlDataReader GetCustomerReader = null;
            MessageBoxResult status;
            try
            {
                oursitdbcommand.Connection.Open();
                status = MessageBox.Show("connection is open");
                try
                {
                    status = MessageBox.Show("Before Reader");
                    GetCustomerReader = oursitdbcommand.ExecuteReader();
                    status = MessageBox.Show("After Reader");
                }
                catch (Exception)
                {
                }
                oursitdbcommand.Connection.Close();
            }
            catch (Exception)
            {
                status = MessageBox.Show("connection.open() failed.");
            }
            return GetCustomerReader;
        }
    }
}
