using ETrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETrade.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context db;
        public ProductController()
        {
            db = new Context();
        }
        public ActionResult Product(int id)
        {
            Session["CartCount"] = db.OrderDetails.Where(x => x.IsCompleted == false && x.CustomerID == TemporaryUserData.UserID).Count();
            Session["WishListCount"] = db.WishLists.Where(x => x.IsActive == true && x.CustomerID == TemporaryUserData.UserID).Count();
            return View(db.Products.Where(x=>x.SubCategoryID == id).ToList());
        }

        public ActionResult ProductDetail(int id)
        {
            ViewData["Reviews"] = db.Reviews.Where(x=>x.ProductID == id && x.IsDeleted == false).ToList();
            Product product = db.Products.Find(id);
            Session["CartCount"] = db.OrderDetails.Where(x => x.IsCompleted == false && x.CustomerID == TemporaryUserData.UserID).Count();
            Session["WishListCount"] = db.WishLists.Where(x => x.IsActive == true && x.CustomerID == TemporaryUserData.UserID).Count();
            return View(product);
        }

        public ActionResult AddReview(int id, FormCollection frm)
        {
            Review review = new Review()
            {
                Comment = frm["review"],
                CustomerID = TemporaryUserData.UserID,
                DateTime = DateTime.Now,
                ProductID = id,
                Name = frm["name"] == "" ? "Anonim" : frm["name"],
                Rate = int.Parse(frm["rate"])
                
            };
            db.Reviews.Add(review);
            db.SaveChanges();
            return RedirectToAction("ProductDetail", new { id = id });
        }

       
    }
}