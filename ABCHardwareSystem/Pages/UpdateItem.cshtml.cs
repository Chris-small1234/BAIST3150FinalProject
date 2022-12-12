using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCHardwareSystem.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABCHardwareSystem.Pages
{
    public class UpdateItemModel : PageModel
    {
        public string Message { get; set; }

        public List<Item> Items = new();
        public AHS RequestDirector = new();

        [BindProperty]
        public string Submit { get; set; }

        public Item ExistingItem = new();

        public bool Confirmation;

        [BindProperty]
        public string ItemListEntry { get; set; }

        [BindProperty]
        public string ItemCodeField { get; set; }

        [BindProperty]
        public string ItemDescriptionField { get; set; }

        [BindProperty]
        public decimal UnitPriceField { get; set; }

        public void OnGet()
        {
            Items = RequestDirector.GetItems();
        }

        public void OnPost()
        {
            switch(Submit)
            {
                case "Find":
                    if (ItemListEntry == null)
                    {
                        ModelState.AddModelError("ItemListEntry", "You need to select an Item");
                    } else
                    {
                        ExistingItem = RequestDirector.GetItem(ItemListEntry);
                        if (ExistingItem.ItemCode != null)
                        {
                            Confirmation = true;
                        }
                        else
                        {
                            Message = "Could not find that Item";
                        }
                    }
                    break;
                case "Update":
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
                        Confirmation = RequestDirector.UpdateItem(ItemCodeField, ItemDescriptionField, UnitPriceField);

                        if (Confirmation)
                        {
                            Message = "Item Successfully Updated!";
                        }
                        else
                        {
                            Message = "Error updating item";
                        }
                    }
                    break;
            }
        }
    }
}
