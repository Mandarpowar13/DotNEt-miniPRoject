using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingApp.CartModels
{
    public class CartRemove
    {
        public string msg { get; set; }
        public decimal carttot { get; set; }
        public int cartcCount { get; set; }
        public int Itemcaount { get; set; }
        public int delId { get; set; }
    }
}