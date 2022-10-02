using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required,ForeignKey("OrderDetail")]
        public int OrderDetailID { get; set; }
        
        [Required, ForeignKey("Payment")]
        public int PaymentID { get; set; }

        [Required, ForeignKey("ShippingDetail")]
        public int ShippingID { get; set; }

        public decimal Discount { get; set; }
        public decimal? Taxes { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsComplated { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Dispached { get; set; }
        public DateTime DispachDate { get; set; }
        public bool Shipped { get; set; }
        public DateTime ShippedDate { get; set; }
        public bool Deliver { get; set; }
        public DateTime DeliverDate { get; set; }
        public string Notes { get; set; }
        public bool CancelOrder { get; set; }

        // OrderDetail,Payment,Shipping Detail

    }
}