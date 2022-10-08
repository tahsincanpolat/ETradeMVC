using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        
        [Required,ForeignKey("PaymentType")]
        public int Type { get; set; }

        public decimal CreditAmount { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal Balance { get; set; }
        public DateTime PaymentDateTime { get; set; }

        // Orders, PaymentType
        public virtual ICollection<Order> Orders { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}