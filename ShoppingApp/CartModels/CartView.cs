using ShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingApp.CartModels
{
    public class CartView
    {
        public List<Cart> cartIt { get; set; }
        public decimal cartTot { get; set; }
    }
}