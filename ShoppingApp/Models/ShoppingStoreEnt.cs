using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace ShoppingApp.Models
{
    public class ShoppingStoreEnt:DbContext
    {
        public DbSet<Item> Items { get; set; }  
        public DbSet<Category> Categories { get; set; }
        public DbSet<Owner> Producers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDet> OrderDetails { get; set; }


    }
}