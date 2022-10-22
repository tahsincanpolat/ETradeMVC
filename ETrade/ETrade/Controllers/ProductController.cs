﻿using ETrade.Models;
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
            return View(db.Products.Where(x=>x.SubCategoryID == id).ToList());
        }

        public ActionResult ProductDetail(int id)
        {
            ViewData["Reviews"] = db.Reviews.Where(x=>x.ProductID == id && x.IsDeleted == false).ToList();
            Product product = db.Products.Find(id);
            return View(product);
        }

       
    }
}