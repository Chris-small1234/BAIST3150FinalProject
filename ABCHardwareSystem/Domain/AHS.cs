using ABCHardwareSystem.TechnicalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCHardwareSystem.Domain
{
    public class AHS
    {
        public bool AddItem(string itemCode, string itemDescription, decimal unitPrice)
        {
            bool Confirmation;

            Items ItemManager = new();

            try
            {
                Confirmation = ItemManager.AddItem(itemCode, itemDescription, unitPrice);
            } catch (Exception)
            {
                Confirmation = false;
            }
            return Confirmation;
        }

        public List<Item> GetItems()
        {
            Items ItemManager = new();
            List<Item> ExistingItems;

            ExistingItems = ItemManager.GetItems();

            return ExistingItems;
        }

        public Item GetItem(string itemCode)
        {
            Item ExistingItem = new();
            Items ItemManager = new();

            ExistingItem = ItemManager.GetItem(itemCode);

            return ExistingItem;
        }

        public bool UpdateItem(string itemCode, string itemDescription, decimal unitPrice)
        {
            bool Confirmation;

            Items ItemManager = new();

            try
            {
                Confirmation = ItemManager.UpdateItem(itemCode, itemDescription, unitPrice);
            }
            catch (Exception)
            {
                Confirmation = false;
            }
            return Confirmation;
        }

        public bool DeleteItem(string itemCode)
        {
            bool Confirmation;

            Items ItemManager = new();

            try
            {
                Confirmation = ItemManager.DeleteItem(itemCode);
            }
            catch (Exception)
            {
                Confirmation = false;
            }
            return Confirmation;
        }

        public bool AddCustomer(int customerNumber, string customerFirstName, string customerLastName, string customerAddress, string city, string province, string postalCode)
        {
            bool Confirmation;

            Customers CustomerManager = new();

            try
            {
                Confirmation = CustomerManager.AddCustomer(customerNumber, customerFirstName, customerLastName, customerAddress, city, province, postalCode);
            }
            catch (Exception)
            {
                Confirmation = false;
            }
            return Confirmation;
        }

        public List<Customer> GetCustomers()
        {
            Customers CustomerManager = new();
            List<Customer> ExistingCustomers;

            ExistingCustomers = CustomerManager.GetCustomers();

            return ExistingCustomers;
        }

        public Customer GetCustomer(int customerNumber)
        {
            Customer ExistingCustomer = new();
            Customers CustomerManager = new();

            ExistingCustomer = CustomerManager.GetCustomer(customerNumber);

            return ExistingCustomer;
        }

        public bool UpdateCustomer(int customerNumber, string customerFirstName, string customerLastName, string customerAddress, string city, string province, string postalCode)
        {
            bool Confirmation;

            Customers CustomerManager = new();

            try
            {
                Confirmation = CustomerManager.UpdateCustomer(customerNumber, customerFirstName, customerLastName, customerAddress, city, province, postalCode);
            }
            catch (Exception)
            {
                Confirmation = false;
            }
            return Confirmation;
        }

        public bool DeleteCustomer(int customerNumber)
        {
            bool Confirmation;

            Customers CustomerManager = new();

            try
            {
                Confirmation = CustomerManager.DeleteCustomer(customerNumber);
            }
            catch (Exception)
            {
                Confirmation = false;
            }
            return Confirmation;
        }
    }
}
