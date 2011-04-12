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
        public DataTable GetCustomer(string Id, string FirstName, string LastName, string EmailAddress)
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
            DataTable CustomerDataTable = new DataTable("Customer");
            MessageBoxResult status;
            try
            {
                oursitdbcommand.Connection = oursitdbconnection;
                oursitdbcommand.Connection.Open();
                try
                {
                    GetCustomerReader = oursitdbcommand.ExecuteReader();
                    if (GetCustomerReader.HasRows)
                    {
                        CustomerDataTable.Load(GetCustomerReader);
                    }
                }
                catch (Exception)
                {
                    status = MessageBox.Show("An error occured while attempting to retreive customer data. Please contact administrator");
                }
                oursitdbcommand.Connection.Close();
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.");
            }
            return CustomerDataTable;
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
                try
                {
                    GetCustomerReader = oursitdbcommand.ExecuteReader();
       
                    if (GetCustomerReader.HasRows)
                    {
                        CustomerDataTable.Load(GetCustomerReader);
                    }
                }
                catch (Exception)
                {
                    status = MessageBox.Show("An error occured while attempting to retreive customer data. Please contact administrator");
                }
                oursitdbcommand.Connection.Close();
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.");
            }
            return CustomerDataTable ;
        }

        public bool AddCustomer(string FirstName, string LastName, string EmailAddress, string Password, string ContactNumber)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText = "sp_AddCustomer";
            oursitdbcommand.Parameters.AddWithValue("@FirstName", FirstName);
            oursitdbcommand.Parameters.AddWithValue("@LastName", LastName);
            oursitdbcommand.Parameters.AddWithValue("@EmailAddress", EmailAddress);
            oursitdbcommand.Parameters.AddWithValue("@Password", Password);
            oursitdbcommand.Parameters.AddWithValue("@ContactNumber", ContactNumber);
            oursitdbcommand.Connection = oursitdbconnection;
            MessageBoxResult status;
            try
            {
                oursitdbcommand.Connection.Open();
                try
                {
                    int result = oursitdbcommand.ExecuteNonQuery();
                    oursitdbcommand.Connection.Close();
                    if (result == 1)
                    {
                        return true;    
                    }
                }
                catch (Exception)
                {
                    oursitdbcommand.Connection.Close();
                    status = MessageBox.Show("An error occured while attempting to save customer data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.","Data Connectivity");
            }
            return false;
        }

        public DataTable GetOperatorByUsername(string Username)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText = "sp_GetOperatorByUsername";
            oursitdbcommand.Parameters.AddWithValue("@Username", Username);
            oursitdbcommand.Connection = oursitdbconnection;
            SqlDataReader GetOperatorReader = null;
            DataTable OperatorDataTable = new DataTable("Operator");
            MessageBoxResult status;
            try
            {
                oursitdbcommand.Connection.Open();
                try
                {
                    GetOperatorReader = oursitdbcommand.ExecuteReader();
                    if (GetOperatorReader.HasRows)
                    {
                        OperatorDataTable.Load(GetOperatorReader);
                    }
                    oursitdbcommand.Connection.Close();
                }
                catch (Exception)
                {
                    status = MessageBox.Show("An error occured while attempting to save operator data. Please contact administrator","Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.","Data Access");
            }
            return OperatorDataTable;
        }
        public bool AddOperator(string Username, string Password, string Type)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText = "sp_AddOperator";
            oursitdbcommand.Parameters.AddWithValue("@Username",Username);
            oursitdbcommand.Parameters.AddWithValue("@Password", Password);
            oursitdbcommand.Parameters.AddWithValue("@Type", Type);
            oursitdbcommand.Connection = oursitdbconnection;
            MessageBoxResult status;
            try
            {
                oursitdbcommand.Connection.Open();
                try
                {
                    int result = oursitdbcommand.ExecuteNonQuery();
                    oursitdbcommand.Connection.Close();
                    if (result == 1)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    oursitdbcommand.Connection.Close();
                    status = MessageBox.Show("An error occured while attempting to save customer data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }

        public bool UpdateCustomer(int Id,string FirstName, string LastName, string EmailAddress,string ContactNumber)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText = "sp_UpdateCustomer";
            oursitdbcommand.Parameters.AddWithValue("@Id", Id);
            oursitdbcommand.Parameters.AddWithValue("@FirstName", FirstName);
            oursitdbcommand.Parameters.AddWithValue("@LastName", LastName);
            oursitdbcommand.Parameters.AddWithValue("@EmailAddress", EmailAddress);
            oursitdbcommand.Parameters.AddWithValue("@ContactNumber", ContactNumber);
            oursitdbcommand.Connection = oursitdbconnection;
            MessageBoxResult status;
            try
            {
                oursitdbcommand.Connection.Open();
                try
                {
                    int result = oursitdbcommand.ExecuteNonQuery();
                    oursitdbcommand.Connection.Close();
                    if (result == 1)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    oursitdbcommand.Connection.Close();
                    status = MessageBox.Show("An error occured while attempting to update customer data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }

        public bool UpdateDriver(int Id, string FirstName, string LastName, string NIS, int TRN, string District, string Parish, string ContactNumber)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText = "sp_UpdateDriver";
            oursitdbcommand.Parameters.AddWithValue("@Id", Id);
            oursitdbcommand.Parameters.AddWithValue("@FirstName", FirstName);
            oursitdbcommand.Parameters.AddWithValue("@LastName", LastName);
            oursitdbcommand.Parameters.AddWithValue("@NIS", NIS);
            oursitdbcommand.Parameters.AddWithValue("@TRN", TRN);
            oursitdbcommand.Parameters.AddWithValue("@District", District);
            oursitdbcommand.Parameters.AddWithValue("@Parish", Parish);
            oursitdbcommand.Parameters.AddWithValue("@ContactNumber", ContactNumber);
            oursitdbcommand.Connection = oursitdbconnection;
            MessageBoxResult status;
            try
            {
                oursitdbcommand.Connection.Open();
                try
                {
                    int result = oursitdbcommand.ExecuteNonQuery();
                    oursitdbcommand.Connection.Close();
                    if (result == 1)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    oursitdbcommand.Connection.Close();
                    status = MessageBox.Show("An error occured while attempting to update driver data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }

        public bool AddDriver(string FirstName, string LastName, string NIS, int TRN, string District, string Parish, string ContactNumber)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText = "sp_AddDriver";
            oursitdbcommand.Parameters.AddWithValue("@FirstName", FirstName);
            oursitdbcommand.Parameters.AddWithValue("@LastName", LastName);
            oursitdbcommand.Parameters.AddWithValue("@NIS", NIS);
            oursitdbcommand.Parameters.AddWithValue("@TRN", TRN);
            oursitdbcommand.Parameters.AddWithValue("@District", District);
            oursitdbcommand.Parameters.AddWithValue("@Parish", Parish);
            oursitdbcommand.Parameters.AddWithValue("@ContactNumber", ContactNumber);
            oursitdbcommand.Connection = oursitdbconnection;
            MessageBoxResult status;
            try
            {
                oursitdbcommand.Connection.Open();
                try
                {
                    int result = oursitdbcommand.ExecuteNonQuery();
                    oursitdbcommand.Connection.Close();
                    if (result == 1)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    oursitdbcommand.Connection.Close();
                    status = MessageBox.Show("An error occured while attempting to save Driver data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }

        public DataTable GetDriverById(string Id)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText = "sp_GetDriverById";
            int ParsedId;
            Int32.TryParse(Id, out ParsedId);
            oursitdbcommand.Parameters.AddWithValue("@Id", ParsedId);
            SqlDataReader GetDriverReader = null;
            DataTable DriverDataTable = new DataTable("Driver");
            MessageBoxResult status;
            try
            {
                oursitdbcommand.Connection = oursitdbconnection;
                oursitdbcommand.Connection.Open();
                try
                {
                    GetDriverReader = oursitdbcommand.ExecuteReader();

                    if (GetDriverReader.HasRows)
                    {
                        DriverDataTable.Load(GetDriverReader);
                    }
                }
                catch (Exception)
                {
                    status = MessageBox.Show("An error occured while attempting to retreive Driver data. Please contact administrator");
                }
                oursitdbcommand.Connection.Close();
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.");
            }
            return DriverDataTable;
        }

        public DataTable SearchDriver(string Id, string NIS, string TRN)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText = "sp_SearchDriver";
            MessageBoxResult status;
            if (String.IsNullOrEmpty(Id))
            {
                oursitdbcommand.Parameters.AddWithValue("@Id", System.DBNull.Value);
            }
            else
            {
                int ParsedId;   
                if (Int32.TryParse(Id, out ParsedId))
                {
                    oursitdbcommand.Parameters.AddWithValue("@Id", ParsedId);
                    
                }
                else
                {
                    status = MessageBox.Show("Id must be numeric.", "field format error");
                    return null;
                }
            }
            if (String.IsNullOrEmpty(TRN))
            {
                oursitdbcommand.Parameters.AddWithValue("@TRN", System.DBNull.Value);
            }
            else
            {
                int ParsedTRN;
                if (Int32.TryParse(TRN, out ParsedTRN))
                {
                    oursitdbcommand.Parameters.AddWithValue("@TRN", ParsedTRN);
                }
                else
                {
                    status = MessageBox.Show("TRN must be numeric.", "field format error");
                    return null;
                }
            }
            if (String.IsNullOrEmpty(NIS))
            {
                oursitdbcommand.Parameters.AddWithValue("@NIS", System.DBNull.Value);
            }
            else
            {
                oursitdbcommand.Parameters.AddWithValue("@NIS", NIS);
            }
            SqlDataReader GetDriverReader = null;
            DataTable DriverDataTable = new DataTable("Driver");
            try
            {
                oursitdbcommand.Connection = oursitdbconnection;
                oursitdbcommand.Connection.Open();
                try
                {
                    GetDriverReader = oursitdbcommand.ExecuteReader();
                    if (GetDriverReader.HasRows)
                    {
                        DriverDataTable.Load(GetDriverReader);
                    }
                }
                catch (Exception)
                {
                    status = MessageBox.Show("An error occured while attempting to retreive Driver data. Please contact administrator");
                }
                oursitdbcommand.Connection.Close();
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.");
            }
            return DriverDataTable;
        }

        public bool AddVehicle(string VIN, string Make, string Model, string Color, string Condition, string ServiceType, int SeatingCapacity)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText = "sp_AddVehicle";
            oursitdbcommand.Parameters.AddWithValue("@VIN", VIN);
            oursitdbcommand.Parameters.AddWithValue("@Make", Make);
            oursitdbcommand.Parameters.AddWithValue("@Model", Model);
            oursitdbcommand.Parameters.AddWithValue("@Color", Color);
            oursitdbcommand.Parameters.AddWithValue("@Condition", Condition);
            oursitdbcommand.Parameters.AddWithValue("@ServiceType", ServiceType);
            oursitdbcommand.Parameters.AddWithValue("@SeatingCapacity", SeatingCapacity);
            oursitdbcommand.Connection = oursitdbconnection;
            MessageBoxResult status;
            try
            {
                oursitdbcommand.Connection.Open();
                try
                {
                    int result = oursitdbcommand.ExecuteNonQuery();
                    oursitdbcommand.Connection.Close();
                    if (result == 1)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    oursitdbcommand.Connection.Close();
                    status = MessageBox.Show("An error occured while attempting to save Vehicle data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }
    }
}

