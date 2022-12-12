using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCHardwareSystem.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABCHardwareSystem.Pages
{
    public class AddItemModel : PageModel
    {
        [BindProperty]
        public string ItemCodeField { get; set; }
        [BindProperty]
        public string ItemDescriptionField { get; set; }
        [BindProperty]
        public decimal UnitPriceField { get; set; }

        public AHS RequestDirector = new();

        public string Message { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            bool Confirmation;

            if (ItemCodeField == null || ItemCodeField.Length > 10)
            {
                ModelState.AddModelError("ItemCodeField", "Item Code is not valid");
            }
            if (ItemDescriptionField == null)
            {
                ItemDescriptionField = "";
            }
            if (ItemDescriptionField.Length > 100)
            {
                ModelState.AddModelError("ItemDescriptionField", "Item Description is too long");
            }
            if (ModelState.ErrorCount == 0)
            {

                Confirmation = RequestDirector.AddItem(ItemCodeField, ItemDescriptionField, UnitPriceField);

                if (Confirmation)
                {
                    Message = "Item Successfully Added!";
                }
                else
                {
                    Message = "Error adding item";
                }
            }
        }
    }
}
