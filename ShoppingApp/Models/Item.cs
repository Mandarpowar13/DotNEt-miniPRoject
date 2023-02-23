using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingApp.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int OwnerId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string ItemArtUrl { get; set; }
        public virtual Category Category { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual List<OrderDet> OrderDetails { get; set; }

    }
}