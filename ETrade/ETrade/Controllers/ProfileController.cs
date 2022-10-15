using ETrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETrade.Controllers
{
    public class ProfileController : Controller
    {
        Context db;
        public ProfileController()
        {
            db = new Context();
        }
        public ActionResult Profile()
        {
            List<OrderDetail> orderDetail = db.OrderDetails.Where(x=>x.IsCompleted == true && x.CustomerID == TemporaryUserData.UserID).ToList();
            ViewBag.orderID = orderDetail;
            List<Order> order = db.Orders.Where(x => x.IsCompleted == true).ToList();
            ViewBag.Order = order;
            return View(db.Customers.Find(TemporaryUserData.UserID));
        }

        public ActionResult UpdateProfile(FormCollection frm)
        {
            Customer customer = db.Customers.Find(TemporaryUserData.UserID);

            customer.FirstName = frm["FirstName"];
            customer.LastName = frm["LastName"];
            customer.Password = frm["Password"];
            customer.Gender = frm["Gender"] == "true" ? true:false;
            customer.BirthDate = DateTime.Parse(frm["BirthDate"]);
            customer.Address = frm["Address"];
            customer.City = frm["City"];
            customer.Country = frm["Country"];

            db.SaveChanges();
            return RedirectToAction("ProfileUpdated","Profile");
        }

        public ActionResult ProfileUpdated()
        {
            return View();
        }

    }
}