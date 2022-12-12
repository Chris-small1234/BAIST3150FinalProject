using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCHardwareSystem.Domain
{
    public class Item
    {
        public string ItemCode { get; set; }

        public string ItemDescription { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
