using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingApp.Models
{
    public class ShoppingCart
    {
        ShoppingStoreEnt store= new ShoppingStoreEnt(); 
        string cart_id { get; set; }

        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(HttpContextBase context) {
            var cart = new ShoppingCart();
            cart.cart_id = cart.GetCartId(context);
            return cart;
        }

        public static ShoppingCart GetCart(Controller controller) { 
        return GetCart(controller.HttpContext);

        
        }

        public void AddToCart(Item item) {
            

            
            
                var cartItem = new Cart
                {

                    ItemId = item.ItemId,
                    CartId = cart_id,
                    Count = 1,
                    Created = DateTime.Now
                };
                store.Carts.Add(cartItem);

            
            
            store.SaveChanges();
        }

        public int removeFromCart(int id) {
            var cartItem = store.Carts.Single(
                cart => cart.CartId == cart_id && cart.RecordId == id
                );
            int count = 0;

            if (cartItem != null) {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    count = cartItem.Count;
                }
                else {
                    store.Carts.Remove(cartItem);
                
                }
                store.SaveChanges();
            }
            return count;
        
        }


        public void emptyCart() { 
        
        var cartItems = store.Carts.Where(
            
            cart => cart.CartId == cart_id
            );

            foreach (var cartItem in cartItems) { 
            store.Carts.Remove(cartItem);
            }

            store.SaveChanges();
        
        }
        public List<Cart> GetCartItems() {

            return store.Carts.Where(
                 cart => cart.CartId == cart_id).ToList();
                
                
        }

        public int getCount() {
            int? count = (from cartItems in store.Carts
                          where cartItems.CartId == cart_id
                          select (int?)cartItems.Count).Sum();
            return count ?? 0;

        }

        public decimal GetTotal()
        {

            decimal? total = (from cartItems in store.Carts
                              where cartItems.CartId == cart_id
                              select (int?)cartItems.Count *
                              cartItems.Item.Price).Sum();

            return total ?? decimal.Zero;
        }

        public int createOrder(Order order) {
            decimal total = 0;

            var cartItems = GetCartItems();

            foreach (var item in cartItems) {
                var orderDetails = new OrderDet
                {
                    ItemId = item.ItemId,
                    OrderId = order.OrderId,
                    Uniteprice = item.Item.Price,
                    Quantity = item.Count
                };
                total += (item.Count * item.Item.Price);
                store.OrderDetails.Add(orderDetails);
            }
            order.Total = total;

            store.SaveChanges();
            emptyCart();
            return order.OrderId;
        }

        public string GetCartId(HttpContextBase context) {
            if (context.Session[CartSessionKey] == null) {
                if (!string.IsNullOrEmpty(context.User.Identity.Name))
                {

                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else { 
                Guid tempid = Guid.NewGuid();

                    context.Session[CartSessionKey] =(Guid)tempid;
                }
                
            
            }
            return context.Session[CartSessionKey].ToString();
        }
       
    }
}