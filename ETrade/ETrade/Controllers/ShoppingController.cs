using ETrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETrade.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: Shopping
        Context db;

        public ShoppingController()
        {
            db = new Context();
        }
        public ActionResult WishList()
        {
            Session["CartCount"] = db.OrderDetails.Where(x => x.IsCompleted == false && x.CustomerID == TemporaryUserData.UserID).Count();
            Session["WishListCount"] = db.WishLists.Where(x => x.IsActive == true && x.CustomerID == TemporaryUserData.UserID).Count();
            return View(db.WishLists.Where(x=>x.IsActive == true && x.CustomerID == TemporaryUserData.UserID).ToList());
        }
        public ActionResult RemoveFromList(int id) 
        {
            WishList wishlist = db.WishLists.Find(id);
            wishlist.IsActive = false;
            db.SaveChanges();
            Session["WishListCount"] = db.WishLists.Where(x => x.IsActive == true && x.CustomerID == TemporaryUserData.UserID).Count();
            return RedirectToAction("Wishlist","Shopping");
        
        }

        public ActionResult AddToCartFromWishList(int id)
        {
            int productId = db.WishLists.Find(id).ProductID;
            ControlCart(productId);
            return RedirectToAction("Wishlist", "Shopping");

        }

        public ActionResult Cart()
        {
            Session["CartCount"] = db.OrderDetails.Where(x => x.IsCompleted == false && x.CustomerID == TemporaryUserData.UserID).Count();
            Session["WishListCount"] = db.WishLists.Where(x => x.IsActive == true && x.CustomerID == TemporaryUserData.UserID).Count();
            return View(db.OrderDetails.Where(x=> x.IsCompleted == false && x.CustomerID == TemporaryUserData.UserID).ToList());
        }

        public ActionResult RemoveFromCart(int id)
        {
            db.OrderDetails.Remove(db.OrderDetails.Find(id));
            db.SaveChanges();
            Session["CartCount"] = db.OrderDetails.Where(x => x.IsCompleted == false && x.CustomerID == TemporaryUserData.UserID).Count();
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult AddWishListFromCart(int id)
        {
            int productId = db.OrderDetails.Find(id).ProductID;
            db.OrderDetails.Remove(db.OrderDetails.Find(id));
                        ControlWishList(productId);

            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPost]
        public ActionResult UpdateQuantity(int id, FormCollection frm)
        {
            OrderDetail od = db.OrderDetails.Find(id);
            od.Quantity = int.Parse(frm["quantity"]);
            od.TotalAmount = od.Quantity * od.UnitPrice * (1 - od.Discount);
            db.SaveChanges();

            return RedirectToAction("Cart","Shopping");
        }
        public ActionResult ShoppingAddToCart(int id, FormCollection frm)
        {
            if(Session["OnlineKullanici"] == null)
            {
                return RedirectToAction("Login","Login");
            }

            int miktar = Convert.ToInt32(frm["quantity"]);

            ControlCart(id,miktar);
            return RedirectToAction("ProductDetail","Product",new { id = id });


        }

        public ActionResult AddWishList(int id)
        {
            if (Session["OnlineKullanici"] == null)
            {
                return RedirectToAction("Login", "Login");
            }


            ControlWishList(id);
            return RedirectToAction("ProductDetail", "Product", new { id = id });

        }

        public ActionResult GoToPayment()
        {
            List<OrderDetail> cart = db.OrderDetails.Where(x => x.IsCompleted == false && x.CustomerID == TemporaryUserData.UserID).ToList();

            foreach (var item in cart)
            {
                if(item.Product.UnitInStock < item.Quantity)
                {
                    return RedirectToAction("Cart","Shopping");
                }
            }

            ViewBag.OrderDetails = cart;
            ViewBag.PaymentTypes = db.PaymentTypes.ToList();
            return View(db.Customers.Find(TemporaryUserData.UserID));
        }

        #region Methods

        public void ControlCart(int id, int miktar = 1)
        {
            OrderDetail od = db.OrderDetails.Where(x => x.ProductID == id && x.IsCompleted == false && x.CustomerID == TemporaryUserData.UserID).FirstOrDefault();

            if(od == null)
            {
                od = new OrderDetail();
                od.ProductID = id;
                od.CustomerID = TemporaryUserData.UserID;
                od.IsCompleted = false;
                od.UnitPrice = db.Products.Find(id).UnitPrice;
                od.Discount = db.Products.Find(id).Discount;
                od.OrderDate = DateTime.Now;

                if(db.Products.Find(id).UnitInStock >= miktar)
                {
                    od.Quantity = miktar;
                }
                else
                {
                    od.Quantity = db.Products.Find(id).UnitInStock;
                }
                od.TotalAmount = od.Quantity * od.UnitPrice * (1 - od.Discount);
                db.OrderDetails.Add(od);
            }
            else
            {
                if(db.Products.Find(id).UnitInStock < od.Quantity + miktar)
                {
                    od.Quantity += miktar;
                    od.TotalAmount = od.Quantity * od.UnitPrice * (1 - od.Discount);
                }
            }
            Session["CartCount"] = db.OrderDetails.Where(x => x.IsCompleted == false && x.CustomerID == TemporaryUserData.UserID).Count();
            Session["WishListCount"] = db.WishLists.Where(x => x.IsActive == true && x.CustomerID == TemporaryUserData.UserID).Count();

            db.SaveChanges();
        }

        public void ControlWishList(int id)
        {
            WishList wishlist = db.WishLists.FirstOrDefault(x => x.ProductID == id && x.CustomerID == TemporaryUserData.UserID && x.IsActive == true);
            if(wishlist == null)
            {
                wishlist = new WishList();
                wishlist.ProductID = id;
                wishlist.CustomerID = TemporaryUserData.UserID;
                wishlist.IsActive = true;
                db.WishLists.Add(wishlist);
                db.SaveChanges();
            }
            Session["CartCount"] = db.OrderDetails.Where(x => x.IsCompleted == false && x.CustomerID == TemporaryUserData.UserID).Count();
            Session["WishListCount"] = db.WishLists.Where(x => x.IsActive == true && x.CustomerID == TemporaryUserData.UserID).Count();

        }

        #endregion


    }
}