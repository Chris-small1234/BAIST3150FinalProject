using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCHardwareSystem.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABCHardwareSystem.Pages
{
    public class UpdateCustomerModel : PageModel
    {
        public string Message { get; set; }

        public List<Customer> Customers = new();
        public AHS RequestDirector = new();

        [BindProperty]
        public string Submit { get; set; }

        public Customer ExistingCustomer = new();

        public bool Confirmation;

        [BindProperty]
        public int CustomerListEntry { get; set; }

        [BindProperty]
        public int CustomerNumberField { get; set; }
        [BindProperty]
        public string CustomerFirstNameField { get; set; }
        [BindProperty]
        public string CustomerLastNameField { get; set; }
        [BindProperty]
        public string CustomerAddressField { get; set; }
        [BindProperty]
        public string CityField { get; set; }
        [BindProperty]
        public string ProvinceField { get; set; }
        [BindProperty]
        public string PostalCodeField { get; set; }

        public void OnGet()
        {
            Customers = RequestDirector.GetCustomers();
        }

        public void OnPost()
        {
            switch (Submit)
            {
                case "Find":
                    ExistingCustomer = RequestDirector.GetCustomer(CustomerListEntry);
                    if (ExistingCustomer != null)
                    {
                        Confirmation = true;
                    }
                    else
                    {
                        Message = "Could not find that Item";
                    }
                    
                    break;
                case "Update":

                    Confirmation = RequestDirector.UpdateCustomer(CustomerNumberField, CustomerFirstNameField, CustomerLastNameField, CustomerAddressField, CityField, ProvinceField, PostalCodeField);

                    if (Confirmation)
                    {
                        Message = "Customer Successfully Updated!";
                    }
                    else
                    {
                        Message = "Error updating customer";
                    }
                    break;
            }
        }
    }
}
