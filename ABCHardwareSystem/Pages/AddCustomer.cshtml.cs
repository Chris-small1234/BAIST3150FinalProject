using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCHardwareSystem.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABCHardwareSystem.Pages
{
    public class AddCustomerModel : PageModel
    {
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

        public AHS RequestDirector = new();

        public string Message { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            bool Confirmation;
            if (ModelState.ErrorCount == 0)
            {
                Confirmation = RequestDirector.AddCustomer(CustomerNumberField, CustomerFirstNameField, CustomerLastNameField, CustomerAddressField, CityField, ProvinceField, PostalCodeField);

                if (Confirmation)
                {
                    Message = "Customer Successfully Added!";
                }
                else
                {
                    Message = "Error adding customer";
                }
            }
        }
    }
}
