using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingApp.Models
{
    public class OrderDet
    {
        public int OrderDetID { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Uniteprice { get; set; }
        public virtual Item Item { get; set; }
        public Order Order { get; set; }

    }
}