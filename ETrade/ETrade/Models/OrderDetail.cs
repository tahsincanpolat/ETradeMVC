using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        [Required, ForeignKey("Product")]
        public int ProductID { get; set; }
        [Required, ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public bool IsCompleted { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }

        // Order, Customer, Product


    }
}