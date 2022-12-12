using ABCHardwareSystem.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ABCHardwareSystem.TechnicalServices
{
    public class Items
    {
        public bool AddItem(string itemCode, string itemDescription, decimal unitPrice)
        {
            bool Success = false;

            SqlConnection DataSource = new();

            DataSource.ConnectionString = @"Persist Security Info=false;Database=csmall8;User ID=csmall8;Password=wtF5689!@#;server=dev1.baist.ca";

            DataSource.Open();

            SqlCommand AddCommand = new();
            AddCommand.Connection = DataSource;
            AddCommand.CommandType = CommandType.StoredProcedure;
            AddCommand.CommandText = "ABCHardwareSales.AddItem";

            SqlParameter CommandParameter;

            CommandParameter = new()
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = itemCode
            };
            AddCommand.Parameters.Add(CommandParameter);

            CommandParameter = new()
            {
                ParameterName = "@ItemDescription",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = itemDescription
            };
            AddCommand.Parameters.Add(CommandParameter);

            CommandParameter = new()
            {
                ParameterName = "@UnitPrice",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = unitPrice
            };
            AddCommand.Parameters.Add(CommandParameter);

            AddCommand.ExecuteNonQuery();
            DataSource.Close();

            Success = true;
            return Success;
        }

        public List<Item> GetItems()
        {
            List<Item> ExistingItems = new();
            SqlConnection MyDataSource = new();

            MyDataSource.ConnectionString = @"Persist Security Info=false;Database=csmall8;User ID=csmall8;Password=wtF5689!@#;server=dev1.baist.ca";
            MyDataSource.Open();

            SqlCommand Command = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ABCHardwareSales.GetItems"
            };

            SqlDataReader DataReader;
            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    Item ExistingItem = new();
                    ExistingItem.ItemCode = (string)DataReader["ItemCode"];
                    ExistingItem.ItemDescription = (string)DataReader["ItemDescription"];
                    ExistingItem.UnitPrice = (decimal)DataReader["UnitPrice"];
                    ExistingItems.Add(ExistingItem);
                }
            }
            DataReader.Close();
            MyDataSource.Close();

            return ExistingItems;
        }

        public Item GetItem(string itemCode)
        {
            Item ExistingItem = new();

            SqlConnection DataSource = new();

            DataSource.ConnectionString = @"Persist Security Info=false;Database=csmall8;User ID=csmall8;Password=wtF5689!@#;server=dev1.baist.ca";
            DataSource.Open();

            SqlCommand Command = new()
            {
                Connection = DataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ABCHardwareSales.GetItemByItemCode"
            };

            SqlParameter CommandParameter;

            CommandParameter = new()
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = itemCode
            };
            Command.Parameters.Add(CommandParameter);

            SqlDataReader DataReader;
            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows)
            {
                DataReader.Read();
                ExistingItem.ItemCode = (string)DataReader["ItemCode"];
                ExistingItem.ItemDescription = (string)DataReader["ItemDescription"];
                ExistingItem.UnitPrice = (decimal)DataReader["UnitPrice"];
            }
            DataReader.Close();
            DataSource.Close();
            return ExistingItem;
        }

        public bool UpdateItem(string itemCode, string itemDescription, decimal unitPrice)
        {
            bool Success = false;

            SqlConnection DataSource = new();

            DataSource.ConnectionString = @"Persist Security Info=false;Database=csmall8;User ID=csmall8;Password=wtF5689!@#;server=dev1.baist.ca";

            DataSource.Open();

            SqlCommand AddCommand = new();
            AddCommand.Connection = DataSource;
            AddCommand.CommandType = CommandType.StoredProcedure;
            AddCommand.CommandText = "ABCHardwareSales.UpdateItem";

            SqlParameter CommandParameter;

            CommandParameter = new()
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = itemCode
            };
            AddCommand.Parameters.Add(CommandParameter);

            CommandParameter = new()
            {
                ParameterName = "@ItemDescription",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = itemDescription
            };
            AddCommand.Parameters.Add(CommandParameter);

            CommandParameter = new()
            {
                ParameterName = "@UnitPrice",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = unitPrice
            };
            AddCommand.Parameters.Add(CommandParameter);

            AddCommand.ExecuteNonQuery();
            DataSource.Close();

            Success = true;
            return Success;
        }

        public bool DeleteItem(string itemCode)
        {
            bool Success = false;

            SqlConnection DataSource = new();

            DataSource.ConnectionString = @"Persist Security Info=false;Database=csmall8;User ID=csmall8;Password=wtF5689!@#;server=dev1.baist.ca";
            DataSource.Open();

            SqlCommand AddCommand = new();
            AddCommand.Connection = DataSource;
            AddCommand.CommandType = CommandType.StoredProcedure;
            AddCommand.CommandText = "ABCHardwareSales.DeleteItem";

            SqlParameter CommandParameter;

            CommandParameter = new()
            {
                ParameterName = "@ItemCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = itemCode
            };
            AddCommand.Parameters.Add(CommandParameter);

            AddCommand.ExecuteNonQuery();
            DataSource.Close();

            Success = true;
            return Success;
        }
    }
}
