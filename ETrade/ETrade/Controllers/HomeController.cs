using ETrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETrade.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Context db = new Context();
            TempData["Meyve"] = db.Products.Where(x => x.SubCategoryID == 2).OrderBy(x=>Guid.NewGuid()).Take(4).ToList();
            TempData["Sebze"] = db.Products.Where(x => x.SubCategoryID == 3).OrderBy(x => Guid.NewGuid()).Take(4).ToList();
            TempData["Pet"] = db.Products.Where(x => x.SubCategoryID == 4).OrderBy(x => Guid.NewGuid()).Take(4).ToList();
            Session["CartCount"] = db.OrderDetails.Where(x => x.IsCompleted == false && x.CustomerID == TemporaryUserData.UserID).Count();
            Session["WishListCount"] = db.WishLists.Where(x => x.IsActive == true && x.CustomerID == TemporaryUserData.UserID).Count();

            return View();
        }
    }
}