using ShoppingApp.CartModels;
using ShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingApp.Controllers
{
    public class CartController : Controller
    {
        ShoppingStoreEnt store = new ShoppingStoreEnt();
        // GET: Cart
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var viewModel = new CartView
            {
                cartIt = cart.GetCartItems(),
                cartTot = cart.GetTotal()

            };

            return View(viewModel);
        }
        public ActionResult AddToCart(int id) {
            var add = store.Items.Single(item => item.ItemId == id);
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(add);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult removeFromcart(int id) {

            var cart = ShoppingCart.GetCart(this.HttpContext);

            string itemName = store.Carts.Single(item => item.RecordId == id).Item.Title;
            int itemCount = cart.removeFromCart(id);

            var result = new CartRemove { 
            msg= Server.HtmlEncode(itemName)+ "has been removed from shopping cart.",
            carttot = cart.GetTotal(),
            cartcCount = cart.getCount(),
            Itemcaount = itemCount,
            delId= id
            
            };
            return Json(result);

        }
    }
}