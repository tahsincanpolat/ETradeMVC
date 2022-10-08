using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.Connection.ConnectionString = "Data Source=203EGITMENPC;Initial Catalog=ETicaretDB;Integrated Security=true";
        }
        /* 
         enable-migrations
         add-migration 0
         update-database
         */
        public DbSet<AdminEmployee> AdminEmployees { get; set; }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RecentlyView> RecentlyViews { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<WishList> WishLists { get; set; }

    }
}