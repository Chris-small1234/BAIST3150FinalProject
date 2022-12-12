using ABCHardwareSystem.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ABCHardwareSystem.TechnicalServices
{
    public class Customers
    {
        public bool AddCustomer(int customerNumber, string customerFirstName, string customerLastName, string customerAddress, string city, string province, string postalCode)
        {
            bool Success = false;

            SqlConnection DataSource = new();

            DataSource.ConnectionString = @"Persist Security Info=false;Database=csmall8;User ID=csmall8;Password=wtF5689!@#;server=dev1.baist.ca";

            DataSource.Open();

            SqlCommand AddCommand = new();
            AddCommand.Connection = DataSource;
            AddCommand.CommandType = CommandType.StoredProcedure;
            AddCommand.CommandText = "ABCHardwareSales.AddCustomer";

            SqlParameter CommandParameter;

            CommandParameter = new()
            {
                ParameterName = "@CustomerNumber",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = customerNumber
            };
            AddCommand.Parameters.Add(CommandParameter);

            CommandParameter = new()
            {
                ParameterName = "@CustomerFirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = customerFirstName
            };
            AddCommand.Parameters.Add(CommandParameter);

            CommandParameter = new()
            {
                ParameterName = "@CustomerLastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = customerLastName
            };
            AddCommand.Parameters.Add(CommandParameter);

            CommandParameter = new()
            {
                ParameterName = "@CustomerAddress",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = customerAddress
            };
            AddCommand.Parameters.Add(CommandParameter);

            CommandParameter = new()
            {
                ParameterName = "@City",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = city
            };
            AddCommand.Parameters.Add(CommandParameter);

            CommandParameter = new()
            {
                ParameterName = "@Province",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = province
            };
            AddCommand.Parameters.Add(CommandParameter);

            CommandParameter = new()
            {
                ParameterName = "@PostalCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = postalCode
            };
            AddCommand.Parameters.Add(CommandParameter);

            AddCommand.ExecuteNonQuery();
            DataSource.Close();

            Success = true;
            return Success;
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> ExistingCustomers = new();
            SqlConnection MyDataSource = new();

            MyDataSource.ConnectionString = @"Persist Security Info=false;Database=csmall8;User ID=csmall8;Password=wtF5689!@#;server=dev1.baist.ca";
            MyDataSource.Open();

            SqlCommand Command = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ABCHardwareSales.GetCustomers"
            };

            SqlDataReader DataReader;
            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    Customer ExistingCustomer = new();
                    ExistingCustomer.CustomerNumber = (int)DataReader["CustomerNumber"];
                    ExistingCustomer.CustomerFirstName = (string)DataReader["CustomerFirstName"];
                    ExistingCustomer.CustomerLastName = (string)DataReader["CustomerLastName"];
                    ExistingCustomer.CustomerAddress = (string)DataReader["CustomerAddress"];
                    ExistingCustomer.City = (string)DataReader["City"];
                    ExistingCustomer.Province = (string)DataReader["Province"];
                    ExistingCustomer.PostalCode = (string)DataReader["PostalCode"];
                    ExistingCustomers.Add(ExistingCustomer);
                }
            }
            DataReader.Close();
            MyDataSource.Close();

            return ExistingCustomers;
        }

        public Customer GetCustomer(int customerNumber)
        {
            Customer ExistingCustomer = new();

            SqlConnection DataSource = new();

            DataSource.ConnectionString = @"Persist Security Info=false;Database=csmall8;User ID=csmall8;Password=wtF5689!@#;server=dev1.baist.ca";
            DataSource.Open();

            SqlCommand Command = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ABCHardwareSales.GetCustomerByCustomerNumber"
            };

            SqlParameter CommandParameter;

            CommandParameter = new()
            {
                ParameterName = "@CustomerNumber",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = customerNumber
            };
            Command.Parameters.Add(CommandParameter);

            SqlDataReader DataReader;
            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows)
            {
                DataReader.Read();
                ExistingCustomer.CustomerNumber = (int)DataReader["CustomerNumber"];
                ExistingCustomer.CustomerFirstName = (string)DataReader["CustomerFirstName"];
                ExistingCustomer.CustomerLastName = (string)DataReader["CustomerLastName"];
                ExistingCustomer.CustomerAddress = (string)DataReader["CustomerAddress"];
                ExistingCustomer.City = (string)DataReader["City"];
                ExistingCustomer.Province = (string)DataReader["Province"];
                ExistingCustomer.PostalCode = (string)DataReader["PostalCode"];
            }
            DataReader.Close();
            DataSource.Close();
            return ExistingCustomer;
        }

        public bool UpdateCustomer(int customerNumber, string customerFirstName, string customerLastName, string customerAddress, string city, string province, string postalCode)
        {
            bool Success = false;

            SqlConnection DataSource = new();

            DataSource.ConnectionString = @"Persist Security Info=false;Database=csmall8;User ID=csmall8;Password=wtF5689!@#;server=dev1.baist.ca";

            DataSource.Open();

            SqlCommand AddCommand = new();
            AddCommand.Connection = DataSource;
            AddCommand.CommandType = CommandType.StoredProcedure;
            AddCommand.CommandText = "ABCHardwareSales.UpdateCustomer";

            SqlParameter CommandParameter;

            CommandParameter = new()
            {
                ParameterName = "@CustomerNumber",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = customerNumber
            };
            AddCommand.Parameters.Add(CommandParameter);

            CommandParameter = new()
            {
                ParameterName = "@CustomerFirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = customerFirstName
            };
            AddCommand.Parameters.Add(CommandParameter);

            CommandParameter = new()
            {
                ParameterName = "@CustomerLastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = customerLastName
            };
            AddCommand.Parameters.Add(CommandParameter);

            CommandParameter = new()
            {
                ParameterName = "@CustomerAddress",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = customerAddress
            };
            AddCommand.Parameters.Add(CommandParameter);

            CommandParameter = new()
            {
                ParameterName = "@City",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = city
            };
            AddCommand.Parameters.Add(CommandParameter);

            CommandParameter = new()
            {
                ParameterName = "@Province",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = province
            };
            AddCommand.Parameters.Add(CommandParameter);

            CommandParameter = new()
            {
                ParameterName = "@PostalCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = postalCode
            };
            AddCommand.Parameters.Add(CommandParameter);

            AddCommand.ExecuteNonQuery();
            DataSource.Close();

            Success = true;
            return Success;
        }

        public bool DeleteCustomer(int customerNumber)
        {
            bool Success = false;

            SqlConnection DataSource = new();

            DataSource.ConnectionString = @"Persist Security Info=false;Database=csmall8;User ID=csmall8;Password=wtF5689!@#;server=dev1.baist.ca";
            DataSource.Open();

            SqlCommand AddCommand = new();
            AddCommand.Connection = DataSource;
            AddCommand.CommandType = CommandType.StoredProcedure;
            AddCommand.CommandText = "ABCHardwareSales.DeleteCustomer";

            SqlParameter CommandParameter;

            CommandParameter = new()
            {
                ParameterName = "@CustomerNumber",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = customerNumber
            };
            AddCommand.Parameters.Add(CommandParameter);

            AddCommand.ExecuteNonQuery();
            DataSource.Close();

            Success = true;
            return Success;
        }
    }
}
