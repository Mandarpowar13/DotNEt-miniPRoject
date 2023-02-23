using ShoppingApp.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ShoppingApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        AdminOperations opr = new AdminOperations();
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult addnew(Models.AdminModel.AdminPoco a)
        {
            if (ModelState.IsValid)
            {
                int result = opr.addnewAdmin(a);
                if (result > 0)
                {
                    ViewBag.a1 = "Admin saved";

                    ModelState.Clear();
                }
                else
                    ViewBag.a1 = "data cannot be saved";
            }
            return View();
        }
    }
}