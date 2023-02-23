using ShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingApp.Controllers
{
    public class WebsiteController : Controller
    {
        ShoppingStoreEnt storeDb = new ShoppingStoreEnt();
        // GET: Website
        public ActionResult Index()
        {
            var catagories = storeDb.Categories.ToList();
            return View(catagories);
        }

        public ActionResult CategoryMenu()
        {
            var catagories = storeDb.Categories.ToList();
            return PartialView(catagories);

        }

        public ActionResult Browse(string category)
        {
            var categoryModel = storeDb.Categories.Include("Items").Single(c=>c.cat_name== category);
            return View(categoryModel);
        }

        public ActionResult Details(int id) {
            var item = storeDb.Items.Find(id);
        return View(item);
        }
    }
}