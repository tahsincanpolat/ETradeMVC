using ETrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETrade.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context db;
        public LoginController()
        {
            db = new Context();
        }

        public ActionResult Login()
        {
            TemporaryUserData.ReturnUrl = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            string kullaniciAdi = frm["username"];
            string sifre = frm["password"];
            Customer customer = db.Customers.FirstOrDefault(x=>x.UserName == kullaniciAdi && x.Password == sifre);
            if(customer != null)
            {
                Session["OnlineKullanici"] = customer.UserName;
                TemporaryUserData.UserID = customer.CustomerID;
                customer.LastLogin = DateTime.Now;
                if (TemporaryUserData.ReturnUrl.Contains("Register"))
                {
                    return RedirectToAction("Index","Home");
                }
                return Redirect(TemporaryUserData.ReturnUrl);
            }
            return View();
        }

        public ActionResult Logout()
        {
            db.Customers.Find(TemporaryUserData.UserID).LastLogin = DateTime.Now;
            db.SaveChanges();
            Session["OnlineKullanici"] = null;
            TemporaryUserData.UserID = 0;
            return RedirectToAction("Index","Home");
        }

        public ActionResult Register()
        {
            TemporaryUserData.ReturnUrl = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection frm)
        {
            string kullaniciAdi = frm["username"];
            Customer customer = db.Customers.FirstOrDefault(x=>x.UserName == kullaniciAdi);

            if(customer != null)
            {
                return View();
            }
            else
            {
                customer = new Customer()
                {
                    FirstName = frm["name"],
                    LastName = frm["surname"],
                    UserName = kullaniciAdi,
                    Password = frm["password"],
                    Gender = frm["gender"] == "true" ? true : false,
                    BirthDate = DateTime.Parse(frm["birthdate"]),
                    CreateDate = DateTime.Now,
                    LastLogin = DateTime.Now,
                };
                db.Customers.Add(customer);
                db.SaveChanges();
                Session["OnlineKullanici"] = kullaniciAdi;
                TemporaryUserData.UserID = customer.CustomerID;
                return RedirectToAction("Index","Home");
            }
        }
    }
}