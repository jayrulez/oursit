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
        public DataTable GetCustomer(string Id, string FirstName, string LastName, string EmailAddress)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText="sp_SearchCustomer";
            MessageBoxResult status;
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
                    status = MessageBox.Show("Id must be numeric", "field data format");
                    return null;
                }
            }
            if (String.IsNullOrEmpty(FirstName))
            {
                oursitdbcommand.Parameters.AddWithValue("@FirstName", System.DBNull.Value);
            }
            else
            {
                oursitdbcommand.Parameters.AddWithValue("@FirstName", FirstName);
            }
            if (String.IsNullOrEmpty(LastName))
            {
                oursitdbcommand.Parameters.AddWithValue("@LastName", System.DBNull.Value);
            }
            else
            {
                oursitdbcommand.Parameters.AddWithValue("@LastName", LastName);
            }
            if (String.IsNullOrEmpty(EmailAddress))
            {
                oursitdbcommand.Parameters.AddWithValue("@EmailAddress", System.DBNull.Value);
            }
            else
            {
                oursitdbcommand.Parameters.AddWithValue("@EmailAddress", EmailAddress);
            }
            SqlDataReader GetCustomerReader = null;
            DataTable CustomerDataTable = new DataTable("Customer");
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
            
            MessageBoxResult status;
            try
            {
                oursitdbcommand.Connection = oursitdbconnection;
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

        public bool UpdateVehicle(string VIN, string Make, string Model, string Color, string Condition, string ServiceType, int SeatingCapacity)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText = "sp_UpdateVehicle";
            oursitdbcommand.Parameters.AddWithValue("@VIN", VIN);
            oursitdbcommand.Parameters.AddWithValue("@Make", Make);
            oursitdbcommand.Parameters.AddWithValue("@Model", Model);
            oursitdbcommand.Parameters.AddWithValue("@Color", Color);
            oursitdbcommand.Parameters.AddWithValue("@Condition", Condition);
            oursitdbcommand.Parameters.AddWithValue("@ServiceType", ServiceType);
            oursitdbcommand.Parameters.AddWithValue("@SeatingCapacity", SeatingCapacity);

            MessageBoxResult status;
            try
            {
                oursitdbcommand.Connection = oursitdbconnection;
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

        public DataTable SearchVehicle(string VIN, string ServiceType, string SeatingCapacity)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText = "sp_SearchVehicle";
            MessageBoxResult status;
            SqlDataReader GetDriverReader = null;
            DataTable VehicleDataTable = new DataTable("Driver");

            if (String.IsNullOrEmpty(VIN))
            {
                oursitdbcommand.Parameters.AddWithValue("@VIN", System.DBNull.Value);
            }
            else
            {
                oursitdbcommand.Parameters.AddWithValue("@VIN", VIN);
            }
            if (String.IsNullOrEmpty(ServiceType))
            {
                oursitdbcommand.Parameters.AddWithValue("@ServiceType", System.DBNull.Value);
            }
            else
            {
                if (ServiceType == "all")
                {
                    oursitdbcommand.Parameters.AddWithValue("@ServiceType", System.DBNull.Value);
                }
                else
                {
                    oursitdbcommand.Parameters.AddWithValue("@ServiceType", ServiceType);
                }
            }
            if (String.IsNullOrEmpty(SeatingCapacity))
            {
                oursitdbcommand.Parameters.AddWithValue("@SeatingCapacity", System.DBNull.Value);
            }
            else
            {
                int ParsedSeatingCapacity;
                if (Int32.TryParse(SeatingCapacity, out ParsedSeatingCapacity))
                {
                    oursitdbcommand.Parameters.AddWithValue("@SeatingCapacity", ParsedSeatingCapacity);
                }
                else
                {
                    status = MessageBox.Show("Seating Capacity must be numeric.", "Field Format");
                    return VehicleDataTable;
                }
            }

            try
            {
                oursitdbcommand.Connection = oursitdbconnection;
                oursitdbcommand.Connection.Open();
                try
                {
                    GetDriverReader = oursitdbcommand.ExecuteReader();
                    if (GetDriverReader.HasRows)
                    {
                        VehicleDataTable.Load(GetDriverReader);
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
            return VehicleDataTable;
        }

        public DataTable SearchInquiry(string CustomerId, string InquiryDate)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText = "sp_SearchInquiry";
            MessageBoxResult status;
            if (String.IsNullOrEmpty(CustomerId))
            {
                oursitdbcommand.Parameters.AddWithValue("@CustomerId", System.DBNull.Value);
            }
            else
            {
                int ParsedId;
                if (Int32.TryParse(CustomerId, out ParsedId))
                {
                    oursitdbcommand.Parameters.AddWithValue("@CustomerId", ParsedId);

                }
                else
                {
                    status = MessageBox.Show("Customer Id must be numeric.", "field format error");
                    return null;
                }
            }

            if (String.IsNullOrEmpty(InquiryDate))
            {
                oursitdbcommand.Parameters.AddWithValue("@CreatedAt", System.DBNull.Value);
            }
            else
            {
                DateTime ParsedInquiryDate; //must fix
                if (DateTime.TryParse(InquiryDate, out ParsedInquiryDate))
                {
                    oursitdbcommand.Parameters.AddWithValue("@CreatedAt", ParsedInquiryDate);
                }
                else
                {
                    status = MessageBox.Show("Date is not in the correct format.", "field format error.");
                }
            }
            SqlDataReader GetInquiryReader = null;
            DataTable InquiryDataTable = new DataTable("Inquiry");
            try
            {
                oursitdbcommand.Connection = oursitdbconnection;
                oursitdbcommand.Connection.Open();
                try
                {
                    GetInquiryReader = oursitdbcommand.ExecuteReader();
                    if (GetInquiryReader.HasRows)
                    {
                        InquiryDataTable.Load(GetInquiryReader);
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
            return InquiryDataTable;
        }

        public DataTable SearchDeliveryRequest(string CustomerId)
        {
            MessageBoxResult status;
            DataTable SearchRequestTable = new DataTable("DeliveryRequest");
            SqlDataReader SearchRequestReader;

            SearchRequestTable.Columns.Add("Id", typeof(Int32));
            SearchRequestTable.Columns.Add("CustomerId", typeof(Int32));
            SearchRequestTable.Columns.Add("Description", typeof(string));
            SearchRequestTable.Columns.Add("ItemDimension", typeof(string));
            SearchRequestTable.Columns.Add("ItemQuantity", typeof(Int32));
            SearchRequestTable.Columns.Add("FromLocation", typeof(string));
            SearchRequestTable.Columns.Add("Destination", typeof(string));
            SearchRequestTable.Columns.Add("DispatchTime", typeof(DateTime));
            SearchRequestTable.Columns.Add("ArrivalTime", typeof(DateTime));
            SearchRequestTable.Columns.Add("Status", typeof(string));
            SearchRequestTable.Columns.Add("Message", typeof(string));

            oursitdbcommand.CommandText = "sp_SearchDeliveryRequest";
            oursitdbcommand.CommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(CustomerId))
            {
                oursitdbcommand.Parameters.AddWithValue("@CustomerId", DBNull.Value);
            }
            else
            {
                int ParsedId;
                if (Int32.TryParse(CustomerId, out ParsedId))
                {
                    oursitdbcommand.Parameters.AddWithValue("@CustomerId", ParsedId);
                }
                else
                {
                    MessageBox.Show("Customer Id must me numeric","field format error");
                    return null;
                }
            }
            oursitdbcommand.Connection = oursitdbconnection;
            try
            {
                oursitdbcommand.Connection.Open();
                try
                {
                    SearchRequestReader = oursitdbcommand.ExecuteReader();
                    if (SearchRequestReader.HasRows)
                    {
                        DataRow TempRow = SearchRequestTable.NewRow();
                        while (SearchRequestReader.Read())
                        {
                            TempRow["Id"] = SearchRequestReader[0];
                            TempRow["CustomerId"] = SearchRequestReader[1];
                            TempRow["Description"] = SearchRequestReader[2];
                            TempRow["ItemDimension"] = SearchRequestReader[3];
                            TempRow["ItemQuantity"] = SearchRequestReader[4];
                            TempRow["FromLocation"] = SearchRequestReader[5];
                            TempRow["Destination"] = SearchRequestReader[6];
                            TempRow["DispatchTime"] = SearchRequestReader[7];
                            TempRow["ArrivalTime"] = SearchRequestReader[8];
                            TempRow["Message"] = SearchRequestReader[10];
                            if (Convert.ToInt32(SearchRequestReader[9]) == 1)
                            {
                                TempRow["Status"] = "Accepted";
                            }
                            else if (Convert.ToInt32(SearchRequestReader[9]) == 2)
                            {
                                TempRow["Status"] = "Cancelled";
                            }
                            else
                            {
                                TempRow["Status"] = "Pending";
                            }
                            SearchRequestTable.Rows.Add(TempRow);
                        }
                    }
                    oursitdbcommand.Connection.Close();
                }
                catch (Exception)
                {
                    oursitdbcommand.Connection.Close();
                    MessageBox.Show("An error occured while attempting to retreive Delivery Request data. Please contact administrator");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.");
            }
            return SearchRequestTable;
        }

        public DataTable SearchRentalRequest(string CustomerId)
        {
            MessageBoxResult status;
            DataTable SearchRequestTable = new DataTable("RentalRequest");
            
            SearchRequestTable.Columns.Add("Id",typeof(Int32));
            SearchRequestTable.Columns.Add("CustomerId", typeof(Int32));
            SearchRequestTable.Columns.Add("VehicleId", typeof(string));
            SearchRequestTable.Columns.Add("Description", typeof(string));
            SearchRequestTable.Columns.Add("Status", typeof(string));
            SearchRequestTable.Columns.Add("Message", typeof(string));
            SqlDataReader SearchRequestReader;

            oursitdbcommand.CommandText = "sp_SearchRentalRequest";
            oursitdbcommand.CommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(CustomerId))
            {
                oursitdbcommand.Parameters.AddWithValue("@CustomerId", DBNull.Value);
            }
            else
            {
                int ParsedId;
                if (Int32.TryParse(CustomerId, out ParsedId))
                {
                    oursitdbcommand.Parameters.AddWithValue("@CustomerId", ParsedId);
                }
                else
                {
                    MessageBox.Show("Customer Id must me numeric", "field format error");
                    return null;
                }
            }
            oursitdbcommand.Connection = oursitdbconnection;
            try
            {
                oursitdbcommand.Connection.Open();
                try
                {
                    SearchRequestReader = oursitdbcommand.ExecuteReader();
                    if (SearchRequestReader.HasRows)
                    {
                        DataRow TempRow = SearchRequestTable.NewRow();
                        while (SearchRequestReader.Read())
                        {
                            TempRow["Id"] = SearchRequestReader[0];
                            TempRow["CustomerId"] = SearchRequestReader[1];
                            TempRow["VehicleId"] = SearchRequestReader[2];
                            TempRow["Description"] = SearchRequestReader[3];
                            if (Convert.ToInt32(SearchRequestReader[4]) == 1)
                            {
                                TempRow["Status"] = "Accepted";
                            }
                            else if (Convert.ToInt32(SearchRequestReader[4]) == 2)
                            {
                                TempRow["Status"] = "Cancelled";
                            }
                            else
                            {
                                TempRow["Status"] = "Pending";
                            }
                            TempRow["Message"] = SearchRequestReader[5];
                            SearchRequestTable.Rows.Add(TempRow);
                        }
                        //SearchRequestTable.Load(SearchRequestReader);
                    }
                    oursitdbcommand.Connection.Close();
                }
                catch (Exception)
                {
                    oursitdbcommand.Connection.Close();
                    MessageBox.Show("An error occured while attempting to retreive Rental Request data. Please contact administrator");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.");
            }
            return SearchRequestTable;
        }

        public DataTable SearchCharterRequest(string CustomerId)
        {
            MessageBoxResult status;
            DataTable SearchRequestTable = new DataTable("CharterRequest");
            SqlDataReader SearchRequestReader;
            SearchRequestTable.Columns.Add("Id", typeof(Int32));
            SearchRequestTable.Columns.Add("CustomerId", typeof(Int32));
            SearchRequestTable.Columns.Add("Description", typeof(string));
            SearchRequestTable.Columns.Add("PassengerNum", typeof(int));
            SearchRequestTable.Columns.Add("Status", typeof(string));
            SearchRequestTable.Columns.Add("Message", typeof(string));
            oursitdbcommand.CommandText = "sp_SearchCharterRequest";
            oursitdbcommand.CommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(CustomerId))
            {
                oursitdbcommand.Parameters.AddWithValue("@CustomerId", DBNull.Value);
            }
            else
            {
                int ParsedId;
                if (Int32.TryParse(CustomerId, out ParsedId))
                {
                    oursitdbcommand.Parameters.AddWithValue("@CustomerId", ParsedId);
                }
                else
                {
                    MessageBox.Show("Customer Id must me numeric", "field format error");
                    return null;
                }
            }
            oursitdbcommand.Connection = oursitdbconnection;
            try
            {
                oursitdbcommand.Connection.Open();
                try
                {
                    SearchRequestReader = oursitdbcommand.ExecuteReader();
                    if (SearchRequestReader.HasRows)
                    {
                        DataRow TempRow = SearchRequestTable.NewRow();
                        while (SearchRequestReader.Read())
                        {
                            TempRow["Id"] = SearchRequestReader[0];
                            TempRow["CustomerId"] = SearchRequestReader[1];
                            
                            TempRow["Description"] = SearchRequestReader[2];
                            TempRow["PassengerNum"] = SearchRequestReader[3];
                            if (Convert.ToInt32(SearchRequestReader[4]) == 1)
                            {
                                TempRow["Status"] = "Accepted";
                            }
                            else if (Convert.ToInt32(SearchRequestReader[4]) == 2)
                            {
                                TempRow["Status"] = "Cancelled";
                            }
                            else
                            {
                                TempRow["Status"] = "Pending";
                            }
                            TempRow["Message"] = SearchRequestReader[5];
                            SearchRequestTable.Rows.Add(TempRow);
                        }
                    }
                    oursitdbcommand.Connection.Close();
                }
                catch (Exception)
                {
                    oursitdbcommand.Connection.Close();
                    MessageBox.Show("An error occured while attempting to retreive Charter Request data. Please contact administrator");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.");
            }
            return SearchRequestTable;
        }
        public DataTable SearchDelivery(string CustomerId)
        {
            MessageBoxResult status;
            DataTable SearchRequestTable = new DataTable("Delivery");
            SqlDataReader SearchRequestReader;

            oursitdbcommand.CommandText = "sp_SearchDelivery";
            oursitdbcommand.CommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(CustomerId))
            {
                oursitdbcommand.Parameters.AddWithValue("@CustomerId", DBNull.Value);
            }
            else
            {
                int ParsedId;
                if (Int32.TryParse(CustomerId, out ParsedId))
                {
                    oursitdbcommand.Parameters.AddWithValue("@CustomerId", ParsedId);
                }
                else
                {
                    MessageBox.Show("Customer Id must me numeric", "field format error");
                    return null;
                }
            }
            oursitdbcommand.Connection = oursitdbconnection;
            try
            {
                oursitdbcommand.Connection.Open();
                try
                {
                    SearchRequestReader = oursitdbcommand.ExecuteReader();
                    if (SearchRequestReader.HasRows)
                    {
                        SearchRequestTable.Load(SearchRequestReader);
                    }
                    oursitdbcommand.Connection.Close();
                }
                catch (Exception)
                {
                    oursitdbcommand.Connection.Close();
                    MessageBox.Show("An error occured while attempting to retreive Customer Delivery data. Please contact administrator");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.");
            }
            return SearchRequestTable;
        }

        public DataTable SearchRental(string CustomerId)
        {
            MessageBoxResult status;
            DataTable SearchRequestTable = new DataTable("Rental");
            SqlDataReader SearchRequestReader;

            oursitdbcommand.CommandText = "sp_SearchRental";
            oursitdbcommand.CommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(CustomerId))
            {
                oursitdbcommand.Parameters.AddWithValue("@CustomerId", DBNull.Value);
            }
            else
            {
                int ParsedId;
                if (Int32.TryParse(CustomerId, out ParsedId))
                {
                    oursitdbcommand.Parameters.AddWithValue("@CustomerId", ParsedId);
                }
                else
                {
                    MessageBox.Show("Customer Id must me numeric", "field format error");
                    return null;
                }
            }
            oursitdbcommand.Connection = oursitdbconnection;
            try
            {
                oursitdbcommand.Connection.Open();
                try
                {
                    SearchRequestReader = oursitdbcommand.ExecuteReader();
                    if (SearchRequestReader.HasRows)
                    {
                        SearchRequestTable.Load(SearchRequestReader);
                    }
                    oursitdbcommand.Connection.Close();
                }
                catch (Exception)
                {
                    oursitdbcommand.Connection.Close();
                    MessageBox.Show("An error occured while attempting to retreive Rental Request data. Please contact administrator");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.");
            }
            return SearchRequestTable;
        }

        public DataTable SearchCharter(string CustomerId)
        {
            MessageBoxResult status;
            DataTable SearchRequestTable = new DataTable("Charter");
            SqlDataReader SearchRequestReader;

            oursitdbcommand.CommandText = "sp_SearchCharter";
            oursitdbcommand.CommandType = CommandType.StoredProcedure;
            if (string.IsNullOrEmpty(CustomerId))
            {
                oursitdbcommand.Parameters.AddWithValue("@CustomerId", DBNull.Value);
            }
            else
            {
                int ParsedId;
                if (Int32.TryParse(CustomerId, out ParsedId))
                {
                    oursitdbcommand.Parameters.AddWithValue("@CustomerId", ParsedId);
                }
                else
                {
                    MessageBox.Show("Customer Id must me numeric", "field format error");
                    return null;
                }
            }
            oursitdbcommand.Connection = oursitdbconnection;
            try
            {
                oursitdbcommand.Connection.Open();
                try
                {
                    SearchRequestReader = oursitdbcommand.ExecuteReader();
                    if (SearchRequestReader.HasRows)
                    {
                        SearchRequestTable.Load(SearchRequestReader);
                    }
                    oursitdbcommand.Connection.Close();
                }
                catch (Exception)
                {
                    oursitdbcommand.Connection.Close();
                    MessageBox.Show("An error occured while attempting to retreive Charter Request data. Please contact administrator");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.");
            }
            return SearchRequestTable;
        }


        public bool UpdateRentalRequest(int Id, int Status, string Message)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.Text;
            oursitdbcommand.CommandText = "update RentalRequest set Status = @Status, Message = @Message where Id = @Id;";
            oursitdbcommand.Parameters.AddWithValue("@Id", Id);
            oursitdbcommand.Parameters.AddWithValue("@Status", Status);
            oursitdbcommand.Parameters.AddWithValue("@Message", Message);
      
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
                    status = MessageBox.Show("An error occured while attempting to update Customer Rental Request data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }

        public bool DeleteRentalRequest(int Id)
        {
            //MessageBox.Show(Id.ToString());
            oursitdbcommand.CommandType = System.Data.CommandType.Text;
            oursitdbcommand.CommandText = "delete from RentalRequest where Id = @Id;";
            oursitdbcommand.Parameters.AddWithValue("@Id", Id);

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
                    status = MessageBox.Show("An error occured while attempting to Remove Customer Rental Request data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }
        public bool AddRental(int CustomerId, string VehicleId,DateTime RentalDate, DateTime ReturnDate,float Cost)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.Text;
            oursitdbcommand.CommandText = "insert into Rental (CustomerId,VehicleId,RentalDate,ReturnDate,Cost) values (@CustomerId,@VehicleId,@RentalDate,@ReturnDate,@Cost);";
            oursitdbcommand.Parameters.AddWithValue("@CustomerId", CustomerId);
            oursitdbcommand.Parameters.AddWithValue("@VehicleId", VehicleId);
            oursitdbcommand.Parameters.AddWithValue("@RentalDate", RentalDate);
            if (DateTime.Compare(ReturnDate,DateTime.MinValue)==0)
            {
                oursitdbcommand.Parameters.AddWithValue("@ReturnDate", DBNull.Value);
            }
            else
            {
                oursitdbcommand.Parameters.AddWithValue("@ReturnDate", ReturnDate);
            }
            oursitdbcommand.Parameters.AddWithValue("@Cost", Cost);
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
                    status = MessageBox.Show("An error occured while attempting to save Customer Rental data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }

        public bool UpdateCharterRequest(int Id, int Status, string Message)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.Text;
            oursitdbcommand.CommandText = "update TripRequest set Status = @Status, Message = @Message where Id = @Id;";
            oursitdbcommand.Parameters.AddWithValue("@Id", Id);
            oursitdbcommand.Parameters.AddWithValue("@Status", Status);
            oursitdbcommand.Parameters.AddWithValue("@Message", Message);

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
                    status = MessageBox.Show("An error occured while attempting to update Customer Charter Request data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }

        public bool UpdateDeliveryRequest(int Id, int Status, string Message)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.Text;
            oursitdbcommand.CommandText = "update DeliveryRequest set Status = @Status, Message = @Message where Id = @Id;";
            oursitdbcommand.Parameters.AddWithValue("@Id", Id);
            oursitdbcommand.Parameters.AddWithValue("@Status", Status);
            oursitdbcommand.Parameters.AddWithValue("@Message", Message);

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
                    status = MessageBox.Show("An error occured while attempting to update Customer Delivery Request data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }

        public bool AddDelivery(int CustomerId, int DriverId, string VehicleId, string ItemDimension, int ItemQuantity, string FromLocation, string Destination,float Cost, DateTime DispatchTime, DateTime ArrivalTime, DateTime ReturnTime)
        {

            oursitdbcommand.CommandType = System.Data.CommandType.Text;
            oursitdbcommand.CommandText = "insert into Delivery (CustomerId,DriverId,VehicleId,ItemDimension,ItemQuantity,FromLocation,Destination,Cost,DispatchTime,ArrivalTime,ReturnTime) values (@CustomerId,@DriverId,@VehicleId,@ItemDimension,@ItemQuantity,@FromLocation,@Destination,@Cost,@DispatchTime,@ArrivalTime,@ReturnTime);";
            oursitdbcommand.Parameters.AddWithValue("@CustomerId", CustomerId);
            oursitdbcommand.Parameters.AddWithValue("@VehicleId", VehicleId);
            oursitdbcommand.Parameters.AddWithValue("@DriverId", DriverId);
            oursitdbcommand.Parameters.AddWithValue("@ArrivalTime", ArrivalTime);
            oursitdbcommand.Parameters.AddWithValue("@ReturnTime", ReturnTime);
            oursitdbcommand.Parameters.AddWithValue("@ItemDimension", ItemDimension);
            oursitdbcommand.Parameters.AddWithValue("@ItemQuantity", ItemQuantity);
            oursitdbcommand.Parameters.AddWithValue("@FromLocation", FromLocation);
            oursitdbcommand.Parameters.AddWithValue("@Destination", Destination);
            oursitdbcommand.Parameters.AddWithValue("@DispatchTime", DispatchTime);
            oursitdbcommand.Parameters.AddWithValue("@Cost", Cost);
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
                    status = MessageBox.Show("An error occured while attempting to save Customer Delivery data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }

        public bool AddCharter(int CustomerId,int DriverId,string VehicleId, int PassengerNum, float Cost, DateTime DispatchTime, DateTime ReturnTime, string DispatchLocation)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.Text;
            oursitdbcommand.CommandText = "insert into Trip (CustomerId,VehicleId,DriverId,PassengerNum,Cost, DispatchTime, DispatchLocation, ReturnTime) values (@CustomerId, @VehicleId,DriverId,@PassengerNum,@Cost, @DispatchTime, @DispatchLocation, @ReturnTime);";
            oursitdbcommand.Parameters.AddWithValue("@CustomerId", CustomerId);
            oursitdbcommand.Parameters.AddWithValue("@VehicleId", VehicleId);
            oursitdbcommand.Parameters.AddWithValue("@DriverId", DriverId);
            oursitdbcommand.Parameters.AddWithValue("@PassengerNum", PassengerNum);
            oursitdbcommand.Parameters.AddWithValue("@DispatchTime", DispatchTime);
            oursitdbcommand.Parameters.AddWithValue("@Cost", Cost);
            oursitdbcommand.Parameters.AddWithValue("@DispatchLocation", DispatchLocation);
            oursitdbcommand.Parameters.AddWithValue("@ReturnTime", ReturnTime);
            oursitdbcommand.Parameters.AddWithValue("@Cost", Cost);
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
                    status = MessageBox.Show("An error occured while attempting to save Customer Charter data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }

        public bool DeleteCharterRequest(int Id)
        {
            //MessageBox.Show(Id.ToString());
            oursitdbcommand.CommandType = System.Data.CommandType.Text;
            oursitdbcommand.CommandText = "delete From TripRequest where Id = @Id;";
            oursitdbcommand.Parameters.AddWithValue("@Id", Id);

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
                    status = MessageBox.Show("An error occured while attempting to Remove Customer Charter Request data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }

        public bool DeleteDeliveryRequest(int Id)
        {
            //MessageBox.Show(Id.ToString());
            oursitdbcommand.CommandType = System.Data.CommandType.Text;
            oursitdbcommand.CommandText = "delete From DeliveryRequest where Id = @Id;";
            oursitdbcommand.Parameters.AddWithValue("@Id", Id);

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
                    status = MessageBox.Show("An error occured while attempting to Remove Customer Delivery Request data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }

        public bool UpdateDelivery(int Id ,int CustomerId, int DriverId, string VehicleId, string ItemDimension, int ItemQuantity, string FromLocation, string Destination, float Cost, DateTime DispatchTime, DateTime ArrivalTime, DateTime ReturnTime)
        {

            oursitdbcommand.CommandType = System.Data.CommandType.Text;
            oursitdbcommand.CommandText = "Update Delivery set CustomerId = @CustomerId, DriverId = @DriverId, VehicleId = @VehicleId, ItemDimension = @ItemDimension, ItemQuantity = @ItemQuantity,FromLocation = @FromLocation,Destination = @Destination,Cost = @Cost,DispatchTime = @DispatchTime,ArrivalTime = @ArrivalTime,ReturnTime = @ReturnTime where Id = Id;";
            oursitdbcommand.Parameters.AddWithValue("@Id",Id);
            oursitdbcommand.Parameters.AddWithValue("@CustomerId", CustomerId);
            oursitdbcommand.Parameters.AddWithValue("@VehicleId", VehicleId);
            oursitdbcommand.Parameters.AddWithValue("@DriverId", DriverId);
            oursitdbcommand.Parameters.AddWithValue("@ArrivalTime", ArrivalTime);
            oursitdbcommand.Parameters.AddWithValue("@ReturnTime", ReturnTime);
            oursitdbcommand.Parameters.AddWithValue("@ItemDimension", ItemDimension);
            oursitdbcommand.Parameters.AddWithValue("@ItemQuantity", ItemQuantity);
            oursitdbcommand.Parameters.AddWithValue("@FromLocation", FromLocation);
            oursitdbcommand.Parameters.AddWithValue("@Destination", Destination);
            oursitdbcommand.Parameters.AddWithValue("@DispatchTime", DispatchTime);
            oursitdbcommand.Parameters.AddWithValue("@Cost", Cost);
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
                    status = MessageBox.Show("An error occured while attempting to save Update Delivery data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }

        public bool UpdateCharter(int Id,int CustomerId, int DriverId, string VehicleId, int PassengerNum, decimal Cost, DateTime DispatchTime, DateTime ReturnTime, string DispatchLocation)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.Text;
            oursitdbcommand.CommandText = "Update Trip set CustomerId = @CustomerId,VehicleId = VehicleId, DriverId = @DriverId,PassengerNum = @PassengerNum,Cost = @Cost, DispatchTime = @DispatchTime, DispatchLocation = @DispatchLocation, ReturnTime = @ReturnTime where Id = @id;";
            oursitdbcommand.Parameters.AddWithValue("@Id", Id);
            oursitdbcommand.Parameters.AddWithValue("@CustomerId", CustomerId);
            oursitdbcommand.Parameters.AddWithValue("@VehicleId", VehicleId);
            oursitdbcommand.Parameters.AddWithValue("@DriverId", DriverId);
            oursitdbcommand.Parameters.AddWithValue("@PassengerNum", PassengerNum);
            oursitdbcommand.Parameters.AddWithValue("@DispatchTime", DispatchTime);
            oursitdbcommand.Parameters.AddWithValue("@Cost", Cost);
            oursitdbcommand.Parameters.AddWithValue("@DispatchLocation", DispatchLocation);
            oursitdbcommand.Parameters.AddWithValue("@ReturnTime", ReturnTime);
            oursitdbcommand.Parameters.AddWithValue("@Cost", Cost);
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
                    status = MessageBox.Show("An error occured while attempting to Update Customer Charter data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }

        public bool UpdateRental(int Id, int CustomerId, string VehicleId, DateTime RentalDate, DateTime ReturnDate, float Cost)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.Text;
            oursitdbcommand.CommandText = "Update Rental (CustomerId = @CustomerId,VehicleId = @VehicleId,RentalDate = @RentalDate,ReturnDate = @ReturnDate,Cost = @Cost where Id = @Id;";
            oursitdbcommand.Parameters.AddWithValue("@Id", Id);
            oursitdbcommand.Parameters.AddWithValue("@CustomerId", CustomerId);
            oursitdbcommand.Parameters.AddWithValue("@VehicleId", VehicleId);
            oursitdbcommand.Parameters.AddWithValue("@RentalDate", RentalDate);
            oursitdbcommand.Parameters.AddWithValue("@ReturnDate", ReturnDate);
            oursitdbcommand.Parameters.AddWithValue("@Cost", Cost);
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
                    status = MessageBox.Show("An error occured while attempting to Update Customer Rental data. Please contact administrator", "Data Connectivity");
                }
            }
            catch (Exception)
            {
                status = MessageBox.Show("Error occured while attempting to access the database. Please contact Administrator.", "Data Connectivity");
            }
            return false;
        }

        public bool AddInquiryFeedBack(int InquiryId, string Body)
        {
            oursitdbcommand.CommandType = System.Data.CommandType.StoredProcedure;
            oursitdbcommand.CommandText = "insert into InquiryFeedback (InquiryId, Body, CreatedAt) values (@InquiryId, @body, GETDATE());";
            oursitdbcommand.Parameters.AddWithValue("@InquiryId", InquiryId);
            oursitdbcommand.Parameters.AddWithValue("@Body", Body);
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
                    status = MessageBox.Show("An error occured while attempting to save Inquiry Feedback data. Please contact administrator", "Data Connectivity");
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


