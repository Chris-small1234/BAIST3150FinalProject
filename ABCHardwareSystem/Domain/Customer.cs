using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCHardwareSystem.Domain
{
    public class Customer
    {

        public int CustomerNumber { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerAddress { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string PostalCode { get; set; }
    }
}
