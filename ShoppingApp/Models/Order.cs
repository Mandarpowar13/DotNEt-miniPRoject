using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string UsesrName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public decimal Total { get; set; }
        public List<OrderDet> OrderDetails { get; set; }
    }
}