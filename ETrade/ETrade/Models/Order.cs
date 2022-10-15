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

        [Required, ForeignKey("OrderDetail")]
        public int OrderDetailID { get; set; }

        [Required, ForeignKey("Payment")]
        public int PaymentID { get; set; }

        [Required, ForeignKey("ShippingDetail")]
        public int ShippingID { get; set; }

        public decimal Discount { get; set; }
        public decimal? Taxes { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Dispatched { get; set; }
        public DateTime DispatchDate { get; set; }
        public bool Shipped { get; set; }
        public DateTime ShippedDate { get; set; }
        public bool Deliver { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Notes { get; set; }
        public bool CancelOrder { get; set; }

        // OrderDetail,Payment,Shipping Detail
        public virtual OrderDetail OrderDetail { get; set;  }
        public virtual Payment Payment { get; set; }
        public virtual ShippingDetail ShippingDetail { get; set; }

    }
}